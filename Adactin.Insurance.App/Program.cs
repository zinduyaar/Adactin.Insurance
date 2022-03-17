using Adactin.Insurance.Business;
using Adactin.Insurance.Core;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddTransient<IPremiumFacade, PremiumFacade>();
builder.Services.AddTransient<IOccupationRatingService, OccupationRatingService>();
builder.Services.AddTransient<IPremiumService, PremiumService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Localhost4200",
        builder => builder.WithOrigins("http://localhost:4200", "https://localhost:44482")
        .AllowAnyHeader()
        .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("Localhost4200");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
