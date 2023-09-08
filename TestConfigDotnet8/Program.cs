using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TestConfigDotnet8;

Console.WriteLine("Hello, World!");


IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, false)
                .AddJsonFile($"breaking_appsettings.json", false, false); // This config can come from the keyvault (Manual mistake)


IConfigurationRoot config = builder.Build();


List<MyCustomObjectSetting>? myCustomObjectSettings = config.GetSection("MyCustomObjectSettings")
    .Get<List<MyCustomObjectSetting>>();


if(myCustomObjectSettings == null)
{
    throw new Exception("should work!");
}

for(int i = 0; i < myCustomObjectSettings.Count; i++)
{
    var setting = myCustomObjectSettings[i];
    Console.WriteLine($"idx: {i} Settings found: {setting?.MyProperty}");
}