namespace _01_Avalonia_DBDesk.Core.AppSettings;

public interface IAppSettingsConnection
{
    string ConnectionName { get; set; }
    string Server { get; set; }
    string Database { get; set; }
    string User { get; set; }
    string Password { get; set; }
}
