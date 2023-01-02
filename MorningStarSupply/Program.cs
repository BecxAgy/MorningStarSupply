using Microsoft.EntityFrameworkCore;
using MorningStarSupply.Context;
using MorningStarSupply.Repositories;
using MorningStarSupply.Repositories.Interfaces;
using MorningStarSupply.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMercadoriaRepository, MercadoriaRepository>();
builder.Services.AddTransient<IEntradaRepository, EntradaRepository>();
builder.Services.AddTransient<ISaidaRepository, SaidaRepository>();
builder.Services.AddScoped<RelatorioService>();
builder.Services.AddScoped<GraficoService>();


builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
