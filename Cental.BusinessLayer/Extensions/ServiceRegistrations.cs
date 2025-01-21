﻿using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
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
        }
    }
}
