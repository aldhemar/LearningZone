using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library
{
    public class Jwt
    {
      public string? Key { get; set; }
      public string? Issuer { get; set; }
      public string? Audience { get; set; }
      public string? Subject { get; set; }

      public dynamic Login(string CompanyCode, dynamic request, dynamic jwt)
      {
         ClientResponseBAD responseBad = new();
         ClientResponseOK responseOK = new();
         Client eClient;
         DataSet? dataset = null;

         try
         {
            eClient = JsonSerializer.Deserialize<Client>(request.ToString());
            if (eClient.EmployeeCode == String.Empty && eClient.Password == String.Empty)
               throw new ExceptionRMS("datos de login vacio");
            dataset = DataAccess.MSSQL.GetDataSetQry(DataAccess.Connection.ConnectionStringAdmin, "SELECT * FROM CLIENT WHERE CompanyCode = '" + CompanyCode + "'");
            if (dataset.Tables[0].Rows.Count == 0)
               throw new ExceptionHeader("Unauthorized");

            eClient.DataBase = (string)dataset.Tables[0].Rows[0]["DataBase"];
            eClient.DBLogin = (string)dataset.Tables[0].Rows[0]["DBLogin"];
            eClient.DBPassword = (string)dataset.Tables[0].Rows[0]["DbPassword"];
            eClient.Datasource = (string)dataset.Tables[0].Rows[0]["DataSource"];
            eClient.ClientName = (string)dataset.Tables[0].Rows[0]["ClientName"];

            var claims = new[]
            {
               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim("Datasource", eClient.Datasource),
               new Claim("DataBase", eClient.DataBase),
               new Claim("DBLogin", eClient.DBLogin),
               new Claim("DBPassword", eClient.DBPassword),
               new Claim("EmployeeCode", eClient.EmployeeCode),
               new Claim("Password", eClient.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               jwt.Issuer,
               jwt.Audience,
               claims,
               expires: DateTime.Now.AddMinutes((int)dataset.Tables[0].Rows[0]["TokenExpiresInMinutes"])
            );

            responseOK.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            responseOK.ExpiresIn = (int)dataset.Tables[0].Rows[0]["TokenExpiresInMinutes"];
            responseOK.TokenType = "Bearer";

            return responseOK;
         }
         catch (ExceptionHeader ex)
         {
            responseBad.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            responseBad.Error = ex.Message;
            return responseBad;
         }
         catch (ExceptionRMS ex)
         {
            responseBad.Error = ex.Message;
            return responseBad;
         }
         catch (Exception ex)
         {
            responseBad.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            responseBad.Error = ex.Message;
            return responseBad;
         }
         finally
         {
            if (dataset != null) dataset.Dispose();
         }
      }
   }
}
