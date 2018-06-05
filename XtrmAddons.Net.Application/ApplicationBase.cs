using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Helpers;
using XtrmAddons.Net.Application.Serializable;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application
{
    /// <summary>
    /// <para>Class XtrmAddons Common Classes Configuration Properties Application.</para>
    /// <para>Provides some application default properties settings.</para>
    /// </summary>
    public static class ApplicationBase
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable application serializable Preferences.
        /// </summary>
        private static Preferences prefs;

        #endregion



        #region Properties

        /// <summary>
        /// Property to set or access to the application serializer type.
        /// </summary>
        public static ApplicationSerializer SerializerType { get; set; }
            = ApplicationSerializer.Json;

        /// <summary>
        /// Property to access to the serializer helper.
        /// </summary>
        public static object SerializerHelper { get; private set; }

        /// <summary>
        /// Property to access to the preferences storage informations.
        /// </summary>
        public static StorageOptions Storage => prefs.Storage;

        /// <summary>
        /// Property to access to the application options informations.
        /// </summary>
        public static Options Options { get; private set; }

        /// <summary>
        /// Property to access to the application user interface.
        /// </summary>
        public static UserInterface UI { get; private set; }

        /// <summary>
        /// Property to access to the user defined language.
        /// </summary>
        public static string Language
        {
            get
            {
                if (prefs.Language.IsNullOrWhiteSpace())
                {
                    prefs.Language = Thread.CurrentThread.CurrentCulture.ToString();
                }

                return prefs.Language;
            }

            set => prefs.Language = value;
        }

        /// <summary>
        /// <para>Method to get the application friendly name.</para>
        /// <para>This method remove extensions from file name.</para>
        /// </summary>
        /// <returns>The cleaned application friendly name.</returns>
        public static string ApplicationFriendlyName
            => AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", "").Replace(".exe", "");

        /// <summary>
        /// Property to access to the application Directories.
        /// </summary>
        public static DirectoryHelper Directories { get; private set; }

        #endregion



        #region Methods

        /// <summary>
        /// <para>Method to start an application.</para>
        /// <para>Set ApplicationBase.SerializerType to change the type of Serializer before starting the application.</para>
        /// </summary>
        /// <example>
        /// ApplicationBase.SerializerType = ApplicationSerializer.Xml;
        /// ApplicationBase.Start();
        /// </example>
        public static void Start()
        {
            Trace.WriteLine("Application Base start.");

            switch (SerializerType)
            {
                case ApplicationSerializer.Json :
                    InitializeJson();
                    break;

                case ApplicationSerializer.Xml :
                    InitializeXml();
                    break;
            }
        }

        /// <summary>
        /// Method to start an application.
        /// </summary>
        private static void InitializeJson()
        {
            Trace.WriteLine("Application Base initialize json.");

            SerializerHelperJson sh = new SerializerHelperJson();
            prefs = sh.LoadPreferences();

            Directories = new DirectoryHelper(prefs);
            Options = sh.LoadOptions();
            UI = sh.LoadUi();

            SerializerHelper = sh;
        }

        /// <summary>
        /// Method to start an application.
        /// </summary>
        private static void InitializeXml()
        {
            Trace.WriteLine("Application Base initialize xml.");

            SerializerHelperXml sh = new SerializerHelperXml();
            prefs = sh.LoadPreferences();

            Directories = new DirectoryHelper(prefs);
            Options = sh.LoadOptions();
            UI = sh.LoadUi();

            SerializerHelper = sh;
        }

        /// <summary>
        /// Method to save the application preferences, options and user interface.
        /// </summary>
        public static void Save()
        {
            switch(SerializerType)
            {
                case ApplicationSerializer.Json :
                    var a = (SerializerHelper as SerializerHelperJson);
                    (SerializerHelper as SerializerHelperJson).SaveAll(prefs);
                    break;

                case ApplicationSerializer.Xml:
                    (SerializerHelper as SerializerHelperXml).SaveAll(prefs);
                    break;
            }
        }

        /// <summary>
        /// Method to save the application preferences.
        /// </summary>
        public static void SavePreferences()
        {
            switch(SerializerType)
            {
                case ApplicationSerializer.Json :
                    var a = (SerializerHelper as SerializerHelperJson);
                    (SerializerHelper as SerializerHelperJson).SavePreferences(prefs);
                    break;

                case ApplicationSerializer.Xml:
                    (SerializerHelper as SerializerHelperXml).SavePreferences(prefs);
                    break;
            }
        }

        /// <summary>
        /// Method to save the application options.
        /// </summary>
        public static void SaveOptions()
        {
            switch (SerializerType)
            {
                case ApplicationSerializer.Json:
                    var a = (SerializerHelper as SerializerHelperJson);
                    (SerializerHelper as SerializerHelperJson).SaveOptions();
                    break;

                case ApplicationSerializer.Xml:
                    (SerializerHelper as SerializerHelperXml).SaveOptions();
                    break;
            }
        }

        /// <summary>
        /// Method to save the application user interface.
        /// </summary>
        public static void SaveUi()
        {
            switch(SerializerType)
            {
                case ApplicationSerializer.Json :
                    var a = (SerializerHelper as SerializerHelperJson);
                    (SerializerHelper as SerializerHelperJson).SaveUi();
                    break;

                case ApplicationSerializer.Xml:
                    (SerializerHelper as SerializerHelperXml).SaveUi();
                    break;
            }
        }

        /// <summary>
        /// Method to trace main application preferences.
        /// </summary>
        public static void Debug()
        {
            Trace.WriteLine(string.Format("# {0}.{1} ------------------------------------------------", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name));

            Trace.WriteLine("Application Friendly Name = " + ApplicationFriendlyName);
            Trace.WriteLine("Application Roaming Directory = " + DirectoryHelper.UserAppData);
            Trace.WriteLine("User My Documents Directory = " + DirectoryHelper.UserMyDocuments);

            // Displays default application specials directories.
            Trace.WriteLine("--- Specials Directories ---");
            Trace.WriteLine("Bin = " + Directories.Bin);
            Trace.WriteLine("Cache = " + Directories.Cache);
            Trace.WriteLine("Config = " + Directories.Config);
            Trace.WriteLine("Data = " + Directories.Data);
            Trace.WriteLine("Logs = " + Directories.Logs);
            Trace.WriteLine("Theme = " + Directories.Theme);

            // Displays default application language.
            Trace.WriteLine("--- language ---");
            Trace.WriteLine("Language = " + Language);

            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        #endregion
    }



    /// <summary>
    /// Enumerator XtrmAddons Net Application Serializer.
    /// </summary>
    [Serializable]
    public enum ApplicationSerializer
    {
        /// <summary>
        /// Application Xml Serializer. 
        /// </summary>
        [XmlEnum(Name = "Xml")]
        Xml = 0,

        /// <summary>
        /// Application Json Serializer. 
        /// </summary>
        [XmlEnum(Name = "Json")]
        Json = 1
    }
}