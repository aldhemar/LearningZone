var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // incluir los controladores que vaya a crear
builder.Services.AddEndpointsApiExplorer(); //incluid todos lo endpoints

/*
 * aqui se implementa la seguridad auth2
 * 
 */

var app = builder.Build();
app.MapGet("/", () => "Servicio OK!");
app.MapControllers();
app.Run();