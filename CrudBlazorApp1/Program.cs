using CrudBlazorApp1.Models;
using CrudBlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<PersonContext>(options =>

		options.UseSqlServer("server=.; database = blazorPersonDb2; trusted_connection =true; trust server certificate =true;")
	);




builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
//app.MapRazorPages();

app.MapFallbackToPage("/_Host");

app.Run();
