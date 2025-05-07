using ProjetoLivro.Context;
using ProjetoLivro.Interface;
using ProjetoLivro.Repository;

var builder = WebApplication.CreateBuilder(args);
//avisa que o app usa controllers
builder.Services.AddControllers();
// avisa que o app usa 
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LivrosContext>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

var app = builder.Build();
//avisa .net que eu tenho controllers
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
//opcional
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix=string.Empty;
//});


app.Run();
