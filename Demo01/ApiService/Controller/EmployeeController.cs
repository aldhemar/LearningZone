using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo01.Controller
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmployeeController : ControllerBase
   {

      //localhot:4444/api/employee
      //localhot:4444/api/micontroller
      //demitoooo

      [HttpGet()]
      [Route("")]
      public dynamic Listar()
      {
         List<Employee> employees = Employee.Get();
         return employees;
      }

      [HttpPost()]
      [Route("")]
      public dynamic Crear([FromBody] Employee employee)
      {
         return employee;
      }

      [HttpPut()]
      [Route("")]
      public dynamic Editar([FromBody] Employee employee)
      {
         return employee;
      }

      [HttpDelete()]
      [Route("{employeecode}")]
      public dynamic Eliminar(string employeecode)
      {
         return employeecode;
      }
   }
}
