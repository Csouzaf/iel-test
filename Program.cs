using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddScoped<IUsuarioRepository, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


builder.Services.AddCors();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;

    })
    .AddJwtBearer(options =>
    {
       string masterKey = "66bfde1acdd9b8c228a8b8d66100c5734188d64d917dd5c5bfbbd92b39b5a0cc";
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateAudience = false,
  
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromHexString(masterKey)),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

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
