﻿using BookLibrary.Data;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Repositories;
using BookLibrary.WebApi.Services.Implements;
using BookLibrary.WebApi.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace BookLibrary.WebApi.Extensions;

public static class ConfigureServicesExtension
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IBorrowRequestRepository, BorrowRequestRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IBorrowRequestService, BorrowRequestService>();
        services.AddTransient<IUserService, UserService>();
    }

    public static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Book Library",
                Contact = new OpenApiContact
                {
                    Name = "Minh Tran",
                    Url = new Uri("https://lowkeycode.me")
                }
            });
        });
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
}