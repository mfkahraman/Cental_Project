using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<IBannerDal, EfBannerDal>();
            
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();
            
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICarDal, EfCarDal>();            
            
            services.AddScoped<IUserSocialService, UserSocialManager>();
            services.AddScoped<IUserSocialDal, EfUserSocialDal>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EfBookingDal>();            
            
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EfServiceDal>();          
            
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageDal, EfMessageDal>();

            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IImageService, ImageService>();

        }
    }
}
