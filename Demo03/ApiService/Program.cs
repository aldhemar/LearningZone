using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // incluir los controladores que vaya a crear
builder.Services.AddEndpointsApiExplorer(); //incluid todos lo endpoints

/*
 * aqui se implementa la seguridad auth2
 * 
 */
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
   option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
   {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey= true,
      ValidIssuer = builder.Configuration["Jwt:issuer"],
      ValidAudience = builder.Configuration["Jwt:audic"],
      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Jwt:key"))
   };
});

var app = builder.Build();
app.MapGet("/", () => "Servicio OK!");
app.MapControllers();
app.UseAuthentication(); //user atenticacion
app.UseAuthorization(); //user autorizacion
app.UseHttpsRedirection(); //rediccion en caso de enviar token a otros servicios
app.Run();