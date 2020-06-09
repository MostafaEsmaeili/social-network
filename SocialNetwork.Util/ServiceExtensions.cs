﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace SocialNetwork.Util
{
    public static class ServiceExtensions
    {
        public static void ConfigureUtilServices(this IServiceCollection services)
        {
            services.AddSingleton<ICryptoHelper, CryptoHelper>();
            services.AddSingleton<AppConfigHelper>();
        }
    }
}
