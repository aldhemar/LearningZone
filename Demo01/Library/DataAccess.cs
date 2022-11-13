using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library
{

   public class DataAccess
   {
      #region Preperties
      public string ConnectionString { get; set; } = string.Empty;
      #endregion

      #region Constructor
      public DataAccess(string ConnectionString) => this.ConnectionString = ConnectionString;
      #endregion

      #region Public Functions
      public DataSet GetDataSetSP(string StoreProcedure, params object[] Parameters)
      {
         return (DataSet)ExecSP<DataSet>(ConnectionString, StoreProcedure, Parameters);
      }

      public int ExecuteActionSP(string StoreProcedure, params object[] Parameters)
      {
         return (int)ExecSP<int>(ConnectionString, StoreProcedure, Parameters);
      }

      public DataSet GetDataSetQry(string cmdText)
      {
         return (DataSet)ExecQry<DataSet>(ConnectionString, cmdText);
      }

      public int ExecuteActionQry(string cmdText)
      {
         return (int)ExecQry<int>(ConnectionString, cmdText);
      }

      public int PostTransaction(ref DataSet dataSet)
      {
         return ExecTransaction(ConnectionString, ref dataSet);
      }
      #endregion

      #region Public Static Functions
      public static DataSet GetDataSetSP(string ConnectionString, string StoreProcedure, params object[] Parameters)
      {
         return (DataSet)ExecSP<DataSet>(ConnectionString, StoreProcedure, Parameters);
      }

      public static int ExecuteActionSP(string ConnectionString, string StoreProcedure, params object[] Parameters)
      {
         return (int)ExecSP<int>(ConnectionString, StoreProcedure, Parameters);
      }

      public static DataSet GetDataSetQry(string ConnectionString, string cmdText)
      {
         return (DataSet)ExecQry<DataSet>(ConnectionString, cmdText);
      }

      public static int ExecuteActionQry(string ConnectionString, string cmdText)
      {
         return (int)ExecQry<int>(ConnectionString, cmdText);
      }

      public static int PostTransaction(string Connectionstring, ref DataSet dataSet)
      {
         return ExecTransaction(Connectionstring, ref dataSet);
      }



      #endregion

      #region Private Static Functions
      private static object ExecSP<T>(string ConnectionString, string StoreProcedure, params object[] Parameters)
      {
         using SqlConnection sqlConnection = new(ConnectionString);
         sqlConnection.Open();
         return ExecSP<T>(sqlConnection, StoreProcedure, Parameters);
      }

      private static object ExecSP<T>(SqlConnection connection, string StoreProcedure, params object[] Parameters)
      {
         object oReturn = null;
         DataSet dsReturn;
         int iReturn;
         Type tReturnType = typeof(T);
         SqlCommand sqlCommand = null;
         SqlDataAdapter adapter = null;
         try
         {
            if (connection.State != ConnectionState.Open)
               connection.Open();

            sqlCommand = new(StoreProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters.Length > 0)
            {
               SqlCommandBuilder.DeriveParameters(sqlCommand);
               int i = 1;
               int nParameters = Parameters.Length;
               while (i <= nParameters)
               {
                  if (Parameters[i - 1].GetType() == typeof(DataTable))
                     sqlCommand.Parameters[i].TypeName = sqlCommand.Parameters[i].TypeName.Replace(connection.Database + '.', "");

                  sqlCommand.Parameters[i].Value = RuntimeHelpers.GetObjectValue(Parameters[i - 1]);
                  i += 1;
               }
            }

            if (tReturnType == typeof(int))
            {
               iReturn = sqlCommand.ExecuteNonQuery();
               oReturn = iReturn;
            }
            else if (tReturnType == typeof(DataSet))
            {
               dsReturn = new DataSet();
               adapter = new SqlDataAdapter(sqlCommand);
               adapter.Fill(dsReturn);
               oReturn = dsReturn;
            }
         }
         catch (Exception ex)
         {
            throw new Exception(ex.TargetSite.Name + Environment.NewLine + ex.Message);
         }
         finally
         {
            if (adapter != null) adapter.Dispose();
            if (sqlCommand != null) sqlCommand.Dispose();
         }
         return oReturn;
      }

      private static object ExecQry<T>(string ConnectionString, string cmdText)
      {
         object obj = null;
         int iReturn;
         DataSet dsReturn;
         SqlCommand command = null;
         SqlConnection sqlConnection = null;
         Type tReturnType = typeof(T);
         SqlDataAdapter adapter = null;
         try
         {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            command = new SqlCommand(cmdText, sqlConnection);
            command.CommandType = CommandType.Text;

            if (tReturnType == typeof(int))
            {
               iReturn = command.ExecuteNonQuery();
               obj = iReturn;
            }
            else if (tReturnType == typeof(DataSet))
            {
               dsReturn = new DataSet();
               adapter = new SqlDataAdapter(command);
               adapter.Fill(dsReturn);
               obj = dsReturn;
            }
         }
         catch (Exception ex)
         {
            throw new Exception(ex.TargetSite.Name + Environment.NewLine + ex.Message);
         }
         finally
         {
            if (sqlConnection != null) sqlConnection.Dispose();
            if (adapter != null) adapter.Dispose();
            if (command != null) command.Dispose();
         }
         return obj;
      }

      private static int ExecTransaction(string ConnectionString, ref DataSet dataSet, string tableName = "")
      {
         string sQuery;
         DataSet dsPrimaryKeys;
         int iAnswer = 0, iCount = 0;
         StringBuilder stringBuilder = new();
         try
         {
            sQuery = "SELECT KU.table_name as TableName, column_name as ColumnName FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME AND KU.table_name='" + dataSet.Tables[0].TableName + "' ORDER BY KU.TABLE_NAME ,KU.ORDINAL_POSITION";
            dsPrimaryKeys = GetDataSetQry(ConnectionString, sQuery);
            if (dsPrimaryKeys.Tables[0].Rows.Count == 0)
               throw new Exception("La tabla " + dataSet.Tables[0].TableName + " no existe en la BD");

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
               if (dataRow.RowState == DataRowState.Added)
               {
                  sQuery = Post(dataRow);
                  stringBuilder.Append(sQuery);
                  iCount += 1;
               }
               else if (dataRow.RowState == DataRowState.Modified)
               {
                  sQuery = Put(dataRow);
                  stringBuilder.Append(sQuery);
                  iCount += 1;
               }
            }

            if (iCount == 0) return iAnswer;
            iAnswer = ExecuteActionQry(ConnectionString, stringBuilder.ToString());
            if (iAnswer != iCount) throw new Exception("ERROR MSSQL.PostTransaction");
            dataSet.AcceptChanges();
         }
         catch (Exception)
         {
            throw;
         }
         return iAnswer;
      }

      private static string Post(DataRow dataRow)
      {
         string sAnswer;
         StringBuilder sbQuery = new();
         try
         {
            sbQuery.Append("INSERT INTO " + dataRow.Table.TableName + " (");
            foreach (DataColumn dataColumn in dataRow.Table.Columns)
            {
               sbQuery.Append(dataColumn.ColumnName + ",");
            }
            sbQuery = sbQuery.Remove(sbQuery.Length - 1, 1);
            sbQuery.Append(") VALUES (");

            foreach (object item in dataRow.ItemArray)
            {
               switch (Type.GetTypeCode((Type)item))
               {
                  case TypeCode.String:
                  case TypeCode.Boolean:
                     //case TypeCode.Guid:
                     sbQuery.Append("");
                     break;
                  case TypeCode.DateTime:
                     sbQuery.Append("");
                     break;
                  case TypeCode.DBNull:
                     sbQuery.Append("");
                     break;
                  default:
                     sbQuery.Append("");
                     break;
               };
            }
            sbQuery = sbQuery.Remove(sbQuery.Length - 1, 1);
            sbQuery.Append(")" + Environment.NewLine);
            sAnswer = sbQuery.ToString();
         }
         catch (Exception)
         {
            throw;
         }
         return sAnswer;
      }

      private static string Put(DataRow dataRow)
      {
         string sAnswer = string.Empty;
         try
         {

         }
         catch (Exception)
         {
            throw;
         }
         return sAnswer;
      }

      private static List<dynamic> ToDynamic(DataTable dt)
      {
         var dynamicDt = new List<dynamic>();
         foreach (DataRow row in dt.Rows)
         {
            dynamic dyn = new ExpandoObject();
            dynamicDt.Add(dyn);
            foreach (DataColumn column in dt.Columns)
            {
               var dic = (IDictionary<string, object>)dyn;

               if (row[column].ToString().Length == 0)
                  dic[column.ColumnName] = null;
               else
                  dic[column.ColumnName] = row[column];

            }
         }
         return dynamicDt;
      }
      #endregion
   }
}