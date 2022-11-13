namespace Demo01.Controller
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmployeeController : ControllerBase
   {
      Employee? oEmployee;

      [HttpGet()]
      [Route("")]
      public dynamic Listar()
      {
         oEmployee = new();
         return oEmployee.GetList();
      }

      [HttpGet()]
      [Route("{employeecode}")]
      public dynamic GetByEmployeeCode(string employeecode)
      {
         oEmployee = new();
         return oEmployee.GetByEmployeeCode(employeecode);
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
