using Microsoft.EntityFrameworkCore;
using testeiel.Data;
using testeiel.Repository;
using testeiel.Security.DTOs;
using testeiel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMapperPerfil));

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IRelatorioRepository, RelatorioService>();
builder.Services.AddScoped<IHomeRepository, HomeService>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteService>();
builder.Services.AddScoped<IApiCepRepository, ApiCepService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.UseSwagger();
// app.UseSwaggerUI();

// app.Use(async (context, next) => 
// {
//     if (context.Request.Path == "/")
//     {
//         context.Response.Redirect("swagger/index.html");
//         return;
//     }
//     await next();
// });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
