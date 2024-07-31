using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Add Email Service
builder.Services.AddScoped<IEmailSender, EmailService>();

// DataBase Connection
builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(
    builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

builder.Services.AddIdentity<IdentityUser, IdentityRole>( options => {
	options.SignIn.RequireConfirmedEmail = false;
} ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Access denied Path correction
builder.Services.ConfigureApplicationCookie( options => {
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
} );

void ConfigureServices ( IServiceCollection services ) {
    services.AddRazorPages()
            .AddRazorPagesOptions( options => {
                options.Conventions.AuthorizeAreaFolder( "Identity", "/Account/Manage" );
                options.Conventions.AuthorizeAreaPage( "Identity", "/Account/Logout" );
            } );

    services.ConfigureApplicationCookie( options => {
        options.LoginPath = $"/Identity/Account/Login";
        options.LogoutPath = $"/Identity/Account/Logout";
        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    } );

    services.AddDefaultIdentity<IdentityUser>( options => options.SignIn.RequireConfirmedAccount = true )
            .AddEntityFrameworkStores<ApplicationDbContext>();

}
void Configure ( IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager ) {
    // Your other middleware configuration
    app.UseStaticFiles();
    app.UseEndpoints( endpoints => {
        endpoints.MapRazorPages();

        endpoints.MapControllers();
        endpoints.MapDefaultControllerRoute();
        // Allow unauthenticated access to the images folder
        endpoints.MapFallbackToFile( "images/{*path}", "images/{path}" );
    } );

    //RoleInitializer.InitializeAsync( roleManager ).Wait();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() ) {
	app.UseExceptionHandler( "/Home/Error" );
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}" );
app.MapRazorPages();
app.Run();
