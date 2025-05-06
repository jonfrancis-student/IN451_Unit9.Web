using IN451_Unit9.Services;
using IN451_Unit9.Services.Interfaces;
using IN451_Unit9.DataAccess.Data;
using Microsoft.Win32;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IHttpContextAccessor for accessing session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Register session and session storage -- this helps store connection string for service/data layers
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
});


// Retrieve the connection string from appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registering Customer, Employee, and Order Service layers OLD CODE
//builder.Services.AddScoped<ICustomerService>(provider => new CustomerService(connectionString));
//builder.Services.AddScoped<IEmployeeService>(provider => new EmployeeService(connectionString));
//builder.Services.AddScoped<IOrderService>(provider => new OrderService(connectionString));

// Register services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Register DataAccess
builder.Services.AddScoped<DataAccess>();




var app = builder.Build();

// Enable session middleware
app.UseSession(); // Make sure this is placed before UseRouting()


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");


app.Run();

