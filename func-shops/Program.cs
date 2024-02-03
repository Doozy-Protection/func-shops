using FluentValidation;
using func_shops.Models;
using func_shops.Services;
using func_shops.Settings;
using func_shops.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        var appSettings = new AppSettings();
        context.Configuration.Bind(appSettings);
        services.AddSingleton(appSettings);
        
        services.AddTransient<IValidator<Shop>, ShopValidator>();
        services.AddTransient<IShopService, ShopService>();
    })
    .Build();

host.Run();