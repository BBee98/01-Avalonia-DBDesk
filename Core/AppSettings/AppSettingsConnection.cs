using System;

namespace _01_Avalonia_DBDesk.Core.AppSettings;

public class AppSettingsConnection : IAppSettingsConnection
{
    public string ConnectionName { get; set; } = "";
    public string Server { get; set; } = "";
    public string Database { get; set; } = "";
    public string User { get; set; } = "";
    public string Password { get; set; } = "";

    public static string Build(IAppSettingsConnection newConnection)
    {
        Console.WriteLine($"Formatting connection for: {newConnection.ConnectionName}...");
        return $@"""{newConnection.ConnectionName}"":  
""Server={newConnection.Server};Database={newConnection.Database};User={newConnection.User};Password={newConnection.Password}}}""";
    }
}