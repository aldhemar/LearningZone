using System.Collections.Generic;

namespace Library
{
   public class Employee : IEmployee<object>
   {
      public string? EmployeeCode { get; set; }
      public string? FirstName { get; set; }
      public string? LastName { get; set; }
      public string? MaidenName { get; set; }
      public int LanguageId { get; set; }
      public string? Password { get; set; }
      public byte[]? Picture { get; set; }
      public string? SSN { get; set; }
      public string? FullName { get; set; }
      public string? Phone1 { get; set; }
      public string? Phone2 { get; set; }
      public string? Address1 { get; set; }
      public string? Address2 { get; set; }
      public string? City { get; set; }
      public string? State { get; set; }
      public string? ZipCode { get; set; }
      public string? JobCodeId { get; set; }
      public string? ExternalID { get; set; }
      public string? DepartmentId { get; set; }
      public string? Email { get; set; }
      public string? StatusCode { get; set; }
      public string? PunchId { get; set; }
      public int FileNo { get; set; }
      public bool Deleted { get; set; }
      public int ShiftNo { get; set; }
      public DateTime HireDate { get; set; }
      public DateTime LeaveDate { get; set; }
      public string? Notes { get; set; }
      public string? Info1 { get; set; }
      public string? Info2 { get; set; }
      public string? Info3 { get; set; }
      public string? Info4 { get; set; }
      public double CommissionPercent { get; set; }
      public string? PIN { get; set; }
      public DateTime DOB { get; set; }
      public string? Gender { get; set; }
      public byte[]? FingerPrint { get; set; }
      public decimal MaxDiscountPercent { get; set; }
      public int CustomerNoReference { get; set; }
      public int HomeStoreNo { get; set; }
      public string? CreatedBy { get; set; }
      public DateTime CreationDate { get; set; }
      public string? ModifiedBy { get; set; }
      public DateTime ChangeDate { get; set; }
      public bool ChangePassword { get; set; }
      public DateTime PasswordExpDate { get; set; }
      public string? JobPosition { get; set; }
      public string? JobTypeCode { get; set; }
      public bool PreAllocationMultipleCells { get; set; }
      public bool PostAllocationMultipleCells { get; set; }
      public bool StockBalanceMultipleCells { get; set; }
      public bool StockBalanceShowQtyInput { get; set; }
      public bool StockBalanceShowSoldQty { get; set; }
      public bool StockBalanceShowOnHandQty { get; set; }
      public bool StockBalanceShowOnOrderQty { get; set; }
      public bool StockBalanceShowMinQty { get; set; }
      public bool StockBalanceShowMaxQty { get; set; }
      public bool StockBalanceShowTransferQty { get; set; }
      public bool StockBalanceShowInTransitQty { get; set; }
      public bool StockBalanceShowCommittedQty { get; set; }
      public bool StockBalanceShowAvailableQty { get; set; }
      public bool StockBalanceShowDaysInStock { get; set; }
      public bool StockBalanceShowROI { get; set; }
      public DateTime PasswordDate { get; set; }
      public int UDF1 { get; set; }
      public int UDF2 { get; set; }
      public int UDF3 { get; set; }
      public bool PollCreated { get; set; }
      public bool POApprover1 { get; set; }
      public bool POApprover2 { get; set; }
      public bool POApprover3 { get; set; }
      public byte PollStatusCode { get; set; }
      public byte ResetPollStatusCode { get; set; }

      public void Delete(object employee)
      {
         throw new NotImplementedException();
      }

      public List<object> GetByEmployeeCode(string sEmployeeCode)
      {
         return Get("EmployeeCode = '" + sEmployeeCode + "'");
      }

      public List<object> GetList()
      {
         return Get();
      }

      public void Post(object employee)
      {
         string conexion = "uid=RetailUser;password=retail;database=RetailData;server=127.0.0.1;Connect Timeout=180;pooling=false";
         //String sQuery = Library.Properties.Resources.UpdateEmployee;
         //sQuery = string.Format(sQuery, employee.EmployeeCode, employee.FirstName, employee.LastName, employee.MaidenName, employee.Phone1, employee.Address1, employee.EmployeeCode, employee.Notes);
         //DataAccess.ExecuteActionQry(conexion, sQuery);
      }

      public void Put(Employee employee)
      {
         string conexion = "uid=RetailUser;password=retail;database=RetailData;server=127.0.0.1;Connect Timeout=180;pooling=false";
         String sQuery = Library.Properties.Resources.UpdateEmployee;
         sQuery = string.Format(sQuery, employee.EmployeeCode, employee.FirstName, employee.LastName, employee.MaidenName, employee.Phone1, employee.Address1, employee.EmployeeCode, employee.Notes);
         DataAccess.ExecuteActionQry(conexion, sQuery);
      }

        public void Put(object employee)
        {
            throw new NotImplementedException();
        }

        private List<object> Get(string sCriteria = "1=1")
      {
         string conexion = "uid=RetailUser;password=retail;database=RetailData;server=127.0.0.1;Connect Timeout=180;pooling=false";
         DataSet dataSet = DataAccess.GetDataSetQry(conexion, "SELECT * FROM EMPLOYEE WHERE " + sCriteria);
         var obj = Functions.ToDynamic(dataSet.Tables[0]);
         return obj;
      }


      public void ApiLogin(string sEmployeeCode, string sPassword)
      {
         string conexion = "uid=RetailUser;password=retail;database=RetailData;server=127.0.0.1;Connect Timeout=180;pooling=false";
         DataSet dataSet = DataAccess.GetDataSetQry(conexion, "SELECT * FROM EMPLOYEE WHERE EmployeeCode = '" + sEmployeeCode +"' and Password = '" + sPassword + "'");
         if (dataSet == null) throw new Exception("No existe empleado");
         if (dataSet.Tables[0].Rows.Count == 0) throw new Exception("No existe empleado");
      }
   }
}
