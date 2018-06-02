using log4net.Repository;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using XtrmAddons.Net.Application.Examples.SettingsExamples;
using XtrmAddons.Net.Application.Helpers;

namespace XtrmAddons.Net.Application.Examples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples Application.
    /// </summary>
    public partial class App : System.Windows.Application
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// <para>Variable to define if the application must be reset on start.</para>
        /// <para>Used as tool for quick development.</para>
        /// </summary>
        private bool Reset = false;

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons.Fotootof Application Constructor.
        /// </summary>
        public App()
        {
            // Must be placed at the top start of the application.
            InitializeLog4Net();

            // Reset application
            // delete user my documents application folder.
            App_Reset();

            // Starting the application
            // The application loads options & parameters from files.
            // Create default files if not exists
            ApplicationBase.SerializerType = ApplicationSerializer.Xml;
            ApplicationBase.Start();

            // Initialize language.
            // Must be placed in the top start of the application.
            CultureInfo ci = new CultureInfo(ApplicationBase.Language);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }

        #endregion



        #region Methods

        /// <summary>
        /// <para>Method to initialize log4net debugger on application contructor.</para>
        /// <para>Log4net configuration must be placed on top of the constructor instructions.</para>
        /// </summary>
        private static void InitializeLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();

            #if !DEBUG

            // Disable using DEBUG mode in Release mode.
            foreach (ILoggerRepository repository in log4net.LogManager.GetAllRepositories())
            {
                repository.Threshold = log4net.Core.Level.Warn;
            }

            #endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            Trace.WriteLine("Starting Application Base. Please wait...");

            // Start application base manager.
            ApplicationBase.Debug();

            // Initialize application preferences.
            InitializePreferences();

            // Application is running
            // Process command line args
            bool startMinimized = false;
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "/StartMinimized")
                {
                    startMinimized = true;
                }
            }

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            if (startMinimized)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
            mainWindow.Show();
        }

        /// <summary>
        /// Method example of custom preferences settings adding.
        /// </summary>
        public void InitializePreferences()
        {
            // Adding some application folders.
            PreferencesExample.AddStorageDirectories();
            PreferencesExample.ReplaceStorageDirectories();

            OptionsExample.AddStorageDirectories();
            OptionsExample.AddDataDatabases();
            OptionsExample.AddServersInformations();
            OptionsExample.AddClientsInformations();

            UiExamples.AddParameters();
            UiExamples.AddUiProperties();

            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));

            Trace.WriteLine("Application Friendly Name : " + ApplicationBase.ApplicationFriendlyName);
            Trace.WriteLine("Application Base Directory : " + ApplicationBase.Directories.Base);

            // Retrieving application folders absolute path.
            // ApplicationBase.Storage.Directories.Find(x => x.Key == "Config.Server")?.AbsolutePath
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Server")?.AbsolutePath;
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKeyFirst("Config.Database")?.AbsolutePath;

            Trace.WriteLine("Config.Server : " + absoluteServerFolderName);
            Trace.WriteLine("Config.Database : " + absoluteDatabaseFolderName);
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");
        }

        /// <summary>
        /// <para>Method to reset the application.</para>
        /// <para>Reset application : delete user my documents application folder.</para>
        /// </summary>
        private void App_Reset()
        {
            if (Reset && System.IO.Directory.Exists(DirectoryHelper.UserMyDocuments))
            {
                Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));
                Trace.WriteLine("Deleting the application options & parameters. Please wait...");
                System.IO.Directory.Delete(DirectoryHelper.UserMyDocuments, true);
                Trace.WriteLine(DirectoryHelper.UserMyDocuments + " deleted !");
                Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
                Trace.WriteLine("");
            }
        }

        /// <summary>
        /// Method called before the application closing.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">Exit event arguments.</param>
        private void App_Exit(object sender, ExitEventArgs e)
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));
            Trace.WriteLine("Saving the application options & parameters before exit. Please wait...");
            ApplicationBase.Save();
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");
        }

        #endregion
    }
}
