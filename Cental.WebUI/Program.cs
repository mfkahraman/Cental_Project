using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Cental.BusinessLayer.Validators;
using Cental.BusinessLayer.Extensions;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CentalContext>();

//Because we established Identity, we need to add the following line
builder.Services.AddIdentity<AppUser, AppRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
})
                .AddEntityFrameworkStores<CentalContext>()
                .AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddServiceRegistrations();

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<BrandValidator>();

builder.Services.AddControllersWithViews(option=>
{
    option.Filters.Add(new AuthorizeFilter());
});

//We added the lines below to identify the login route and logout route. Otherwise, the system will use Account/Login as the default.
builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Login/Index";
    cfg.LogoutPath = "/Login/Logout";
    cfg.AccessDeniedPath = "/ErrorPage/AccessDenied";
});

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

//Added below line to redirect to the NotFound404 page when a 404 error occurs.
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404");

app.UseRouting();

app.UseAuthentication(); //We added this line to enable the authentication process for  checking the user's identity.

app.UseAuthorization(); //This line checks whether the user is authorized to access the requested page.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
