using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {

      Receipt oReceipt;

      [Route("")]
      [HttpGet]
      public dynamic Get()
      {
         oReceipt = new();
         return oReceipt.GetData();
      }

      [Route("docnumber/{docnumber}")]
      [HttpGet]
      public dynamic GetByDocNumber(string docnumber)
      {
         oReceipt = new();
         return oReceipt.GetData("DocNumber = '" + docnumber + "'");
      }

      [Route("entre/{fecha1}_{fecha2}")]
      [HttpGet]
      public dynamic Entre(string fecha1, string fecha2)
      {
         oReceipt = new();
         return oReceipt.GetData("SalesDate between '" + fecha1 +"' and '" + fecha2 +"'");
      }


      [Route("date/{date}")]
      [HttpGet]
      public dynamic GetByDate(string date)
      {
         oReceipt = new();
         return oReceipt.GetData("SalesDate = '" + date + "'");
      }
    }
}
