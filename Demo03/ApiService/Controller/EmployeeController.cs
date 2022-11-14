using System.Net;

namespace Demo01.Controller
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmployeeController : ControllerBase
   {
      Employee? oEmployee;

      [HttpGet()]
      [Route("")]
      public dynamic Listar(string token)
      {
         if (token == null | token != "123456")
         {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new {
               error = "no implmento token"
            };
            
         }
         else
         {
            oEmployee = new();
            return oEmployee.GetList();
         }
      }

      [HttpGet()]
      [Route("listar2")]
      public dynamic Listar2([FromHeader] string token)
      {
         if (token == null | token != "99999999")
         {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new
            {
               error = "no implmento token"
            };

         }
         else
         {
            oEmployee = new();
            return oEmployee.GetList();
         }
      }

      [HttpGet()]
      [Route("listar3")]
      public dynamic Listar3([FromHeader] string employeecode, [FromHeader]string password)
      {

         try
         {
            oEmployee = new();
            oEmployee.ApiLogin(employeecode, password);
            return oEmployee.GetList();
         }
         catch(Exception ex)
         {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new
            {
               error = ex.Message
            };
         }
      }


      [HttpGet()]
      [Route("{employeecode}")]
      public dynamic GetByEmployeeCode(string token,string employeecode)
      {

         


         oEmployee = new();
         return oEmployee.GetByEmployeeCode(employeecode);
      }

      [HttpPost()]
      [Route("")]
      public dynamic Crear([FromBody] Employee employee)
      {
         oEmployee = new();
         oEmployee.Post(employee);
         return employee;
      }

      [HttpPut()]
      [Route("")]
      public dynamic Editar([FromBody] Employee employee)
      {
         oEmployee = new();
         oEmployee.Put(employee);
         return employee;
      }

      [HttpDelete()]
      [Route("{employeecode}")]
      public dynamic Eliminar(string employeecode)
      {
         return employeecode;
      }


      [HttpPost()]
      [Route("auth2")]
      public dynamic Auth2([FromHeader] string employeecode, [FromHeader] string password)
      {

         try
         {
            oEmployee = new();
            oEmployee.ApiLogin(employeecode, password);
            return oEmployee.GetList();
         }
         catch (Exception ex)
         {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new
            {
               error = ex.Message
            };
         }
      }

   }
}
