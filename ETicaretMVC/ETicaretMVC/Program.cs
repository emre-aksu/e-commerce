using BusinessLayer.Abstract;
using BusinessLayer.Managers;
using BusinessLayer.Mapping.Automapper.Profiles;
using BusinessLayer.Validators.FluentValidation;
using DataAccesLayer.Interface;
using DataAccesLayer.Repositories;
using ETicaretMVC.ApiServices;
using FluentValidation;
using ModelLayer.Dtos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddSession();// Session, uygulama genelinde kullanýma açýlýyor
builder.Services.AddHttpContextAccessor();

//HTTPCLIENT ILE API KABERLESMESI ICIN GECERLI
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiService, ApiService>();
//-------------------------------------------------------------------

//IoC'e dependeny injection ile enjekte edileccek nesnelerin neler olduðunu register ediyoruz (Entity framework ile çalýþan Repository objelerini bu arayüzlere yaratýlýp verilmesi gerektiðini söylemiþ oluyoruz.)
//------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
//------------------------------------------------------------------------------------------------------------

//Automapper için;
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//2.yöntem
builder.Services.AddAutoMapper(typeof(ProductProfile));
//------------------------------------------------------------------------------------------------------------

//Login dto tipindeki bir nesnenin validasyonu yapýlmasý gerektiðinde o tipe ait kurallar sýnýfýndan iþletilsin.
builder.Services.AddScoped<IValidator<LogInDto>, LogInDtoValidator>();
builder.Services.AddScoped<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
builder.Services.AddScoped<IValidator<ProductAddDto>, ProductAddDtoValidator>();
builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Session, uygulama genelinde kullanýma açýlýyor

app.UseAuthorization();
//-------------------------------admin için--------------------------------------
app.MapAreaControllerRoute(
    name: "adminPanelDefault",
    areaName: "AdminPanel",
    pattern: "/admin/{controller=Authentication}/{action=LogIn}/{id?}");

//-------------------------------user için--------------------------------------

app.MapAreaControllerRoute(
    name: "userPanelDefault",
    areaName: "UserPanel",
    pattern: "/user/{controller=Authentication}/{action=LogIn}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
