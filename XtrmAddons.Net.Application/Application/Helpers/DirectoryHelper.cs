using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XtrmAddons.Net.Application.Serializable;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;
using XtrmAddons.Net.Common.Extensions;
using XtrmAddons.Net.SystemIO;

namespace XtrmAddons.Net.Application.Helpers
{
    /// <summary>
    /// <para>Class XtrmAddons Net Application Helpers Directory.</para>
    /// </summary>
    public class DirectoryHelper : INotifyPropertyChanged
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable application serializable preferences.
        /// </summary>
        private static Preferences prefs;

        /// <summary>
        /// Variable application base Bin directory.
        /// </summary>
        public string bin;

        /// <summary>
        /// Variable application base Cache directory.
        /// </summary>
        private string cache;

        /// <summary>
        /// Variable application base Config directory.
        /// </summary>
        public string config;

        /// <summary>
        /// Variable application base Data directory.
        /// </summary>
        public string data;

        /// <summary>
        /// Variable application base Logs directory.
        /// </summary>
        public string logs;

        /// <summary>
        /// Variable application base Plugin directory.
        /// </summary>
        public string plugin;

        /// <summary>
        /// Variable application base Theme directory.
        /// </summary>
        public string theme;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the application base directory.
        /// </summary>
        public string Base
        {
            get
            {
                if(prefs == null)
                {
                    Trace.WriteLine(new NullReferenceException(nameof(prefs)));
                    return "";
                }

                if (prefs.BaseDirectory.IsNullOrWhiteSpace())
                {
                   prefs.BaseDirectory = UserMyDocuments;
                }

                return prefs.BaseDirectory;
            }

            set
            {
                if (prefs == null)
                {
                    Trace.WriteLine(new NullReferenceException(nameof(prefs)));
                }
                else
                if (value != prefs.BaseDirectory)
                {
                    if (!System.IO.Directory.Exists(value))
                    {
                        System.IO.Directory.CreateDirectory(value);
                    }

                    prefs.BaseDirectory = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application Bin directory.</para>
        /// <para>A new Bin directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Bin
        {
            get
            {
                if (bin.IsNullOrWhiteSpace())
                {
                    bin = GetSpecialDirectory("Bin", UserAppData, SpecialDirectoriesName.Bin.Name());
                }

                return bin;
            }

            set
            {
                if (value != bin)
                {
                    bin = SetSpecialDirectory("Bin", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the cache directory.</para>
        /// <para>A new cache directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Cache
        {
            get
            {
                if(cache == null)
                {
                    cache = GetSpecialDirectory("Cache", Base, SpecialDirectoriesName.Cache.Name());
                }

                return cache;
            }

            set
            {
                if (value != cache)
                {
                    cache = SetSpecialDirectory("Cache", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application custom configuration directory.</para>
        /// <para>A new config directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Config
        {
            get
            {
                if (config == null)
                {
                    config = GetSpecialDirectory("Config", Base, SpecialDirectoriesName.Config.Name());
                }

                return config;
            }

            set
            {
                if (value != config)
                {
                    SetSpecialDirectory("Config", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application data directory.</para>
        /// <para>A new data directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Data
        {
            get
            {
                if (data == null)
                {
                    data = GetSpecialDirectory("Data", Base, SpecialDirectoriesName.Data.Name());
                }

                return data;
            }

            set
            {
                if (value != data)
                {
                    SetSpecialDirectory("Data", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application logs directory.</para>
        /// <para>A new logs directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Logs
        {
            get
            {
                if (logs == null)
                {
                    logs = GetSpecialDirectory("Logs", UserAppData, SpecialDirectoriesName.Logs.Name());
                }

                return logs;
            }

            set
            {
                if (value != logs)
                {
                    SetSpecialDirectory("Logs", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application plugin directory.</para>
        /// <para>A new plugin directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Plugin
        {
            get
            {
                if (plugin == null)
                {
                    plugin = GetSpecialDirectory("Plugin", UserAppData, SpecialDirectoriesName.Plugin.Name());
                }

                return plugin;
            }

            set
            {
                if (value != plugin)
                {
                    SetSpecialDirectory("Plugin", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// <para>Property to access to the application Theme directory.</para>
        /// <para>A new theme directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public string Theme
        {
            get
            {
                if (theme == null)
                {
                    theme = GetSpecialDirectory("Theme", Base, SpecialDirectoriesName.Theme.Name());
                }

                return theme;
            }

            set
            {
                if (value != theme)
                {
                    SetSpecialDirectory("Theme", value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the default assets images directory.
        /// </summary>
        public static string AssetsImagesDefault
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Default");

        /// <summary>
        /// Property to access to the default assets icons directory.
        /// </summary>
        public static string AssetsImagesIcons
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Icons");

        /// <summary>
        /// Property to get Window User My Documents path.
        /// </summary>
        /// <returns>The absolute path to Window User My Documents.</returns>
        public static string UserMyDocuments
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationBase.ApplicationFriendlyName);

        /// <summary>
        /// Property to get application datas path.
        /// </summary>
        /// <returns>The absolute path to the datas application directory.</returns>
        public static string UserAppData
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationBase.ApplicationFriendlyName);

        #endregion



        #region Event Handler

        /// <summary>
        /// Delegate property changed event handler of the model.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName.
        /// parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        /// <param name="propertyName">A name of a property to notify changed event.</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Application Helpers Directory Constructor.
        /// </summary>
        public DirectoryHelper(Preferences pref = null)
        {
            prefs = pref;
        }

        #endregion



        #region Methods

        /// <summary>
        /// <para>Method to copy application configuration files to the user documents directory Asynchronously.</para>
        /// <para>Always replace user config documents by application default config documents.</para>
        /// </summary>
        /// <param name="Override">Defines if copy should override existing files.</param>
        /// <returns>A ansynchronus Task.</returns>
        public Task CopyConfigFiles_Async(bool Override = false)
        {
            return Task.Run(() =>
            {
                CopyConfigFiles(Override);
            });
        }

        /// <summary>
        /// <para>Method to copy application configuration files to the user documents directory.</para>
        /// <para>Always replace user config documents by application default config documents.</para>
        /// </summary>
        /// <param name="Override">Defines if copy should override existing files.</param>
        public void CopyConfigFiles(bool Override = false)
        {
            // Get installed application path.
            string src = Path.Combine(Environment.CurrentDirectory, "Config");

            // Copy configuration to defined user config directory.
            SysDirectory.Copy(src, Config, Override);
        }

        /// <summary>
        /// <para>Method to get a special directory path from preferences.</para>
        /// <para>A new directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        /// <param name="prefName">The name of the preferences property.</param>
        /// <param name="root">The root path for the directory.</param>
        /// <param name="sdName">A special directory name.</param>
        /// <returns>The absolute path of the special directory.</returns>
        private static string GetSpecialDirectory(string prefName, string root, string sdName)
        {
            // Check if preferences are already set.
            if (prefs == null)
            {
                log.Warn(new NullReferenceException(nameof(prefs)).Message);
                return "";
            }

            string path = prefs.SpecialDirectories.GetPropertyValue<string>(prefName);

            if (path.IsNullOrWhiteSpace())
            {
                path = Path.Combine(root, sdName);

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                prefs.SpecialDirectories.SetPropertyValue(prefName, path);
            }

            return path;
        }

        /// <summary>
        /// <para>Method to set a special directory path to preferences.</para>
        /// <para>A new directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        /// <param name="prefName">The name of the preferences property.</param>
        /// <param name="value">The absolute path of the directory.</param>
        /// <returns>The value pasted or the absolute path of the special directory.</returns>
        private static string SetSpecialDirectory(string prefName, string value)
        {
            // Check if preferences are already set.
            if (prefs == null)
            {
                log.Warn(new NullReferenceException(nameof(prefs)).Message);
                return "";
            }

            if (!System.IO.Directory.Exists(value))
            {
                System.IO.Directory.CreateDirectory(value);
            }

            return (string)prefs.SpecialDirectories.SetPropertyValue(prefName, value);
        }

        #endregion

    }
}
