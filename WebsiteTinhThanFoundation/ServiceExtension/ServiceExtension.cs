﻿using WebsiteTinhThanFoundation.Data;
using WebsiteTinhThanFoundation.Repository.Interface;
using WebsiteTinhThanFoundation.Repository.UnitOfWork;
using WebsiteTinhThanFoundation.Repository;
using Microsoft.EntityFrameworkCore;
using WebsiteTinhThanFoundation.Services.Interface;
using WebsiteTinhThanFoundation.Services;

namespace WebsiteTinhThanFoundation.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IBlogArticleCommentRepository, BlogArticleCommentRepository>();
            services.AddScoped<IBlogArticleRepository, BlogArticleRepository>();
            services.AddScoped<IBlogArticleTagRepository, BlogArticleTagRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IRegisteredVolunteerRepository, RegisteredVolunteerRepository>();
            //

            //Service
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IBlogArticleService), typeof(BlogArticleService));
            services.AddScoped(typeof(ITagService), typeof(TagService));
            services.AddScoped(typeof(IRegisteredvolunteerService), typeof(RegisteredvolunteerService));
            return services;
        }
    }
}
