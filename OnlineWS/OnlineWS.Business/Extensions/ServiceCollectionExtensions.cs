using Microsoft.Extensions.DependencyInjection;
using OnlineWS.Business.Contracts;
using OnlineWS.Business.Implementations;
using OnlineWS.Business.Mapping.Automapper.Profiles;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWS.DateAccess.EF.Repositories;

namespace OnlineWS.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            //---------------------PROFİLE---------------------------
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(ProductPhotoProfile));
            services.AddAutoMapper(typeof(EmployeeProfile));
            services.AddAutoMapper(typeof(PaymentProfile));

            //---------------------MANAGER---------------------------
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IUserCategoryManager, UserCategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IUserProductManager, UserProductManager>();
            services.AddScoped<IProductPhotoManager, ProductPhotoManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IPaymentManager,PaymentManager>();

            //---------------------REPOSİTORY REGISTRATIONS---------------------------
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserCategoryRepository, UserCategoryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserProductRepository, UserProductRepository>();
            services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
          
        } 
    }
}
