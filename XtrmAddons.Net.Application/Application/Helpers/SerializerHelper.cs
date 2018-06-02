using System.IO;
using XtrmAddons.Net.Application.Interfaces;
using XtrmAddons.Net.Application.Serializable;

namespace XtrmAddons.Net.Application.Helpers
{
    /// <summary>
    /// <para>Class XtrmAddons Net Application Serializer Helper.</para>
    /// <para>This class provides definitions for application serialization and deserialization.</para>
    /// </summary>
    public abstract class SerializerHelper : ISerializer
    {
        #region Properties

        /// <summary>
        /// Property Application Base Preferences file name. 
        /// </summary>
        public abstract string FileName_Preferences { get; }

        /// <summary>
        /// Property Application Base Options file name.
        /// </summary>
        public abstract string FileName_Options { get; }

        /// <summary>
        /// Property Application Base User Interface file name.
        /// </summary>
        public abstract string FileName_Ui { get; }

        /// <summary>
        /// Property to access to the absolute path of the file Preferences.
        /// </summary>
        public string FilePath_Preferences
            => Path.Combine(DirectoryHelper.UserMyDocuments, FileName_Preferences);

        /// <summary>
        /// Property to access to the absolute path of the file Options.
        /// </summary>
        public string FilePath_Options
            => Path.Combine(ApplicationBase.Directories.Config, FileName_Options);

        /// <summary>
        /// Property to access to the absolute path of the file User Interface.
        /// </summary>
        public string FilePath_Ui
            => Path.Combine(ApplicationBase.Directories.Config, FileName_Ui);

        #endregion



        #region Constructor

        /// <summary>
        /// <para>Class XtrmAddons Net Application Serializer Helper Constructor.</para>
        /// <para>This class provides definitions for application serialization and deserialization.</para>
        /// </summary>
        public SerializerHelper() { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to load the application base Preferences.
        /// </summary>
        public abstract Preferences LoadPreferences();

        /// <summary>
        /// Method to load the application base Options.
        /// </summary>
        public abstract Options LoadOptions();

        /// <summary>
        /// Method to load the application base User Interface.
        /// </summary>
        public abstract UserInterface LoadUi();

        /// <summary>
        /// Method to save all the application base data.
        /// </summary>
        public abstract void SaveAll(Preferences pref);

        /// <summary>
        /// Method to save the application base Preferences.
        /// </summary>
        public abstract void SavePreferences(Preferences pref);

        /// <summary>
        /// Method to save the application base Options.
        /// </summary>
        public abstract void SaveOptions();

        /// <summary>
        /// Method to save the application base User Interface.
        /// </summary>
        public abstract void SaveUi();

        /// <summary>
        /// Method to load and deserialize a file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized object.</returns>
        public abstract T Deserialize<T>(string filename);

        #endregion

    }
}