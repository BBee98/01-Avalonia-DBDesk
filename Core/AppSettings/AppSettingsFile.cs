namespace _01_Avalonia_DBDesk.Core.AppSettings;

using System.Text.Json;
using System.IO;
using System;

public static class AppSettingsFile
{
    public static string RootFile { get; set; } = "";

    public static void AddDefaultConnection()
    {
        try
        {
            IAppSettingsConnection defaultConnection = new AppSettingsConnection
            {
                ConnectionName = "Default",
                Server = "localhost",
                Database = "sqy_db",
                User = "root",
                Password = "root"
            }; 
            var formattedConnection = "{" + AppSettingsConnection.Build(defaultConnection) +"}";
            File.WriteAllText(RootFile, $@"{{ ""ConnectionStrings"": {formattedConnection} }}");
            Console.WriteLine($"formattedConnection {formattedConnection}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something happened and I could not create {RootFile}: {e.Message}");
        }
    }

    public static void AddConnection(IAppSettingsConnection appSettingsConnection)
    {
        var newConnection = AppSettingsConnection.Build(appSettingsConnection);
        try
        {
            File.AppendAllText(RootFile, newConnection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something happened and I could not add {newConnection} to {RootFile}: {e.Message}");
        }
    }

    public static bool ConnectionExists(string newConnection)
    {
        var data = File.ReadAllText(RootFile);
        var dataJson = JsonSerializer.Deserialize<AppSettingsJsonFile>(data);
        if (dataJson != null && !dataJson.ConnectionStrings.Equals(null) &&
            dataJson.ConnectionStrings.ToString().Equals(null))
        {
            return dataJson.ConnectionStrings.ToString().Contains(newConnection);
        }

        return false;
    }
}

class AppSettingsJsonFile
{
    public Object ConnectionStrings { get; set; } = "";
}