using System.Diagnostics;
using System.Reflection;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;

namespace XtrmAddons.Net.Application.Examples.SettingsExamples
{
    /// <summary>
    /// <para>Class XtrmAddons .Net Application Examples Preferences.</para>
    /// <para>This Class privides some examples to set application preferences like application directories...</para>
    /// </summary>
    internal static class PreferencesExample
    {
        /// <summary>
        /// Method example of application directories settings adding.
        /// </summary>
        public static void AddStorageDirectories()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));

            // Example of directory placed in the application \Config directory
            // {application}\Config\Server
            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "Config.Server",
                    RelativePath = "Server",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );

            // Retrieving previews directory settings.
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Server")?.AbsolutePath;
            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);


            // Example of directory placed in the application \Data directory
            // {application}\Data\Database
            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "Config.Database",
                    RelativePath = "Database",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );

            // Retrieving previews directory settings.
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Database")?.AbsolutePath;
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Method example of application directories settings replace.
        /// </summary>
        public static void ReplaceStorageDirectories()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));

            // Example of directory placed in the application \Config directory
            // {application}\Config\Server Replace
            ApplicationBase.Storage.Directories.AddKeySingle
            (
                new Directory
                {
                    Key = "Config.Server",
                    RelativePath = "Server Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );
            
            // Retrieving previews directory settings.
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Server")?.AbsolutePath;
            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);

            // Example of directory placed in the application \Data directory
            // {application}\Data\Database Replace
            ApplicationBase.Storage.Directories.AddKeySingle
            (
                new Directory
                {
                    Key = "Config.Database",
                    RelativePath = "Database Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );
            
            // Retrieving previews directory settings.
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Database")?.AbsolutePath;
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }
    }
}
