using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using _01_Avalonia_DBDesk.Core.AppSettings;

namespace _01_Avalonia_DBDesk.Core;

public static class FileSystem
{
    public static IConfigurationRoot ConfigurationBuilder { get; private set; }

    public static void SaveAppSettingsPath()
    {
        var currentPath = AppContext.BaseDirectory;
        for (var i = 0; i < 4; i++)
        {
            var parent = Directory.GetParent(currentPath);
            if (parent != null)
            {
                currentPath = parent.FullName;
            }
        }
        AppSettingsFile.RootFile = $"{currentPath}/appsettings.json";
    }

    public static void InitAppSettingsJson()
    {
        CreateAppSettingsJson();
        ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(AppSettingsFile.RootFile, optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }

    private static void CreateAppSettingsJson()
    {
        AppSettingsFile.AddDefaultConnection();
    }
}