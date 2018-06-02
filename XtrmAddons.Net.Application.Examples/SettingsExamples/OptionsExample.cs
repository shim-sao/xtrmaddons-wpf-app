using System.Diagnostics;
using System.Reflection;
using XtrmAddons.Net.Application.Serializable.Elements.Data;
using XtrmAddons.Net.Application.Serializable.Elements.Remote;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;
using XtrmAddons.Net.Network;

namespace XtrmAddons.Net.Application.Examples.SettingsExamples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples Options.
    /// </summary>
    internal static class OptionsExample
    {
        /// <summary>
        /// Method example of options directories settings adding.
        /// </summary>
        public static void AddStorageDirectories()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));
            Trace.WriteLine("Example of directory placed in the options [\\ApplicationTests\\My Pictures] directory");

            // Example of directory placed in the options [\ApplicationTests\My Pictures] directory
            // C:\Windows\Temp\ApplicationTests\My Pictures
            ApplicationBase.Options.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "My Pictures",
                    RelativePath = "ApplicationTests\\My Pictures",
                    IsRelative = true,
                    Root = "C:\\Windows\\Temp"
                }
            );

            Trace.WriteLine("Example of directory replaced in the options [\\ApplicationTests\\My Pictures] directory");

            // Example of directory placed in the options [\ApplicationTests\My Pictures Replaced] directory
            // C:\Windows\Temp\ApplicationTests\My Pictures Replaced
            ApplicationBase.Options.Storage.Directories.ReplaceKeyFirst
            (
                new Directory
                {
                    Key = "My Pictures",
                    RelativePath = "ApplicationTests\\My Pictures Replaced",
                    IsRelative = true,
                    Root = "C:\\Windows\\Temp"
                }
            );

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Method example of options directories settings adding.
        /// </summary>
        public static void AddDataDatabases()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));
            
            Trace.WriteLine("Example of adding default database settings.");
            Database database = new Database
            {
                Key = "Default",
                Name = "My Database by Default " + ApplicationBase.Options.Data.Databases.Count,
                Host = "localhost",
                Port = "8080",
                UserName = "Root",
                Password = "toor",
                Source = "",
                Type = DatabaseType.MySQL,
                Comment = "Example of database settings"
            };
            ApplicationBase.Options.Data.Databases.AddDefaultSingle(database);
            
            Trace.WriteLine("Example of adding another unique database settings.");
            Database database1 = new Database
            {
                Key = "Another Database",
                Name = "Another Database for example",
                IsDefault = false,
                Host = "localhost",
                Port = "8080",
                UserName = "User1",
                Password = "pass1",
                Source = "C:\\Window\\Temp\\another-database.db",
                Type = DatabaseType.SQLite,
                Comment = "Another example of database settings"
            };
            ApplicationBase.Options.Data.Databases.AddKeySingle(database1);

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");
        }

        /// <summary>
        /// Method to add some servers informations.
        /// </summary>
        public static void AddServersInformations()
        {
            // Get default server in preferences if exists.
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));
            Trace.WriteLine("Initializing HTTP server informations. Please wait...");

            Server server = ApplicationBase.Options.Remote.Servers.FindDefaultFirst();

            // Cheking if the server informations are already set.
            if (server == null || server.Key == null)
            {
                // Create new default server parameters
                ApplicationBase.Options.Remote.Servers.Add(new Server
                {
                    Key = "default",
                    Name = "Server by Default",
                    IsDefault = true,
                    Host = "127.0.0.1",
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of default server informations settings."
                });

                // Retrieve previews set.
                server = ApplicationBase.Options.Remote.Servers.FindDefaultFirst();
                Trace.WriteLine("---- Add()");
                Trace.WriteLine("Name : " + server.Name);
                Trace.WriteLine("Key : " + server.Key);
                Trace.WriteLine("Host : " + server.Host);
                Trace.WriteLine("Port : " + server.Port);
                Trace.WriteLine("UserName : " + server.UserName);
                Trace.WriteLine("Password : " + server.Password);
                Trace.WriteLine("Comment : " + server.Comment);

                // Create new default server parameters
                // Add unique Server informations, replace settings if already exists.
                ApplicationBase.Options.Remote.Servers.AddDefaultSingle(new Server
                {
                    Key = "default",
                    Name = "Unique Server by Default",
                    IsDefault = true,
                    Host = NetworkInformations.GetLocalHostIp(),
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of an unique default server informations settings."
                });

                // Retrieve previews set.
                server = ApplicationBase.Options.Remote.Servers.FindDefaultFirst();
                Trace.WriteLine("---- AddDefaultUnique()");
                Trace.WriteLine("Name : " + server.Name);
                Trace.WriteLine("Key : " + server.Key);
                Trace.WriteLine("Host : " + server.Host);
                Trace.WriteLine("Port : " + server.Port);
                Trace.WriteLine("UserName : " + server.UserName);
                Trace.WriteLine("Password : " + server.Password);
                Trace.WriteLine("Comment : " + server.Comment);
            }

            // Retrieve default server settings.
            server = ApplicationBase.Options.Remote.Servers.FindDefaultFirst();
            Trace.WriteLine("---- FindDefault()");
            Trace.WriteLine("Name : " + server.Name);
            Trace.WriteLine("Key : " + server.Key);
            Trace.WriteLine("Host : " + server.Host);
            Trace.WriteLine("Port : " + server.Port);
            Trace.WriteLine("UserName : " + server.UserName);
            Trace.WriteLine("Password : " + server.Password);
            Trace.WriteLine("Comment : " + server.Comment);

            // Example of another server settings, not as default.
            Server server2 = new Server()
            {
                Key = "AnotherServer",
                Name = "AnotherServer",
                IsDefault = true,
                Host = NetworkInformations.GetLocalHostIp(),
                Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                UserName = "LoginIfRequired",
                Password = "PasswordIfRequired",
                Comment = "Example override default server informations."
            };
            ApplicationBase.Options.Remote.Servers.ReplaceDefault(server2);

            // Retrieve previews settings by Host for example.
            server2 = ApplicationBase.Options.Remote.Servers.Find(x => x.Host == NetworkInformations.GetLocalHostIp());

            Trace.WriteLine("---- Find(x => x.Host == NetworkInformations.GetLocalHostIp())");
            Trace.WriteLine("Server : " + server2.Name);
            Trace.WriteLine("Server Key : " + server2.Key);
            Trace.WriteLine("Host : " + server2.Host);
            Trace.WriteLine("Port : " + server2.Port);
            Trace.WriteLine("UserName : " + server2.UserName);
            Trace.WriteLine("Password : " + server2.Password);
            Trace.WriteLine("Comment : " + server2.Comment);

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void AddClientsInformations()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));

            // Add new client informations.
            Client client1 = new Client()
            {
                Key = "Client 1",
                Name = "My first Client",
                IsDefault = true,
                Host = NetworkInformations.GetLocalHostIp(),
                Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                UserName = "LoginIfRequired",
                Password = "PasswordIfRequired",
                Comment = "Example override default server informations."
            };
            ApplicationBase.Options.Remote.Clients.AddKeySingle(client1);

            // Retrieve previews Client settings.
            client1 = ApplicationBase.Options.Remote.Clients.FindKeyFirst("Client 1");
            client1 = ApplicationBase.Options.Remote.Clients.FindWithFirst("Name", "My first Client");
            client1 = ApplicationBase.Options.Remote.Clients.FindWithFirst("Host", NetworkInformations.GetLocalHostIp());

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");
        }
    }
}
