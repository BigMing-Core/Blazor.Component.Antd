﻿using LuanNiao.Blazor.Component.Antd.DatePicker;
using LuanNiao.Blazor.Component.Antd.Tooltip;
using LuanNiao.Blazor.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd
{
    public static class LuanNiaoBlazorAntdExtensions
    {
        public static IServiceCollection AddLuanNiaoBlazorAntdExtensions(this IServiceCollection services)
        {
            services.AddLuanNiaoBlazor();
            services.AddScoped<Message>();
            services.AddScoped<TooltipService>();
            services.AddScoped<DatePickerServer>();
            return services;
        }

    }
}
