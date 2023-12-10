﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Implementations;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Services.Helpers;
using Shipfinity.Services.Implementations;
using Shipfinity.Services.Interfaces;

namespace Shipfinity.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IStringEncoder, StringEncoder>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<INewsletterService, NewsletterService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
