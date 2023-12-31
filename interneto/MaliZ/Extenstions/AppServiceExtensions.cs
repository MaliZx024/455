﻿using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extenstions;

public static class AppServiceExtensions
{
     public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
     {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(conf.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        return services;
     }
}
