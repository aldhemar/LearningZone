using System.Data;
using System.Runtime.InteropServices;

namespace Library
{
   public class Employee
   {
      public string? EmployeeCode { get; set; }
      public string? FirstName { get; set; }
      public string? LastName{ get; set; }
      public DateTime? DOB { get; set; }
      public bool Status { get; set; }
      public int Age { get; set; }


      public static List<Employee> Get()
      {
         string conexion = "uid=RetailUser;password=retail;database=RetailData;server=127.0.0.1;Connect Timeout=180;pooling=false";
         DataSet dataSet = DataAccess.GetDataSetQry(conexion, "SELECT * FROM EMPLOYEE");

         List<Employee> employees = new List<Employee>();
         Employee employee;

         foreach (DataRow dataRow in dataSet.Tables[0].Rows)
         {
            employee = new Employee();
            employee.EmployeeCode = dataRow["EmployeeCode"].ToString();
            employee.FirstName = dataRow["FirstName"].ToString();
            employee.LastName = dataRow["LastName"].ToString();

            if (dataRow["DOB"] == DBNull.Value)
               employee.DOB = null;
            else
               employee.DOB = (DateTime)dataRow["DOB"];

            employee.Status = true;
            employee.Age = 20;
            employees.Add(employee);
         }

         return employees;
      }


	 }
}
