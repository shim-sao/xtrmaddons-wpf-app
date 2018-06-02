using XtrmAddons.Net.Application.Serializable;

namespace XtrmAddons.Net.Application.Interfaces
{
    /// <summary>
    /// <para>Class XtrmAddons Net Application Serializer Interfaces</para>
    /// <para>This interface implement how an application base must be defines.</para>
    /// </summary>
    internal interface ISerializer
    {
        #region Properties

        /// <summary>
        /// Property Application Base Preferences file name. 
        /// </summary>
        string FileName_Preferences { get; }

        /// <summary>
        /// Property Application Base Options file name.
        /// </summary>
        string FileName_Options { get; }

        /// <summary>
        /// Property Application Base User Interface file name.
        /// </summary>
        string FileName_Ui { get; }

        /// <summary>
        /// Property to access to the absolute path of the file Preferences.
        /// </summary>
        string FilePath_Preferences { get; }

        /// <summary>
        /// Property to access to the absolute path of the file Options.
        /// </summary>
        string FilePath_Options { get; }

        /// <summary>
        /// Property to access to the absolute path of the file User Interface.
        /// </summary>
        string FilePath_Ui { get; }

        #endregion



        #region Methods

        /// <summary>
        /// Method to load the application base Preferences.
        /// </summary>
        Preferences LoadPreferences();

        /// <summary>
        /// Method to load the application base Options.
        /// </summary>
        Options LoadOptions();

        /// <summary>
        /// Method to load the application base User Interface.
        /// </summary>
        UserInterface LoadUi();

        /// <summary>
        /// Method to save all the application base data.
        /// </summary>
        void SaveAll(Preferences pref);

        /// <summary>
        /// Method to save the application base Preferences.
        /// </summary>
        void SavePreferences(Preferences pref);

        /// <summary>
        /// Method to save the application base Options.
        /// </summary>
        void SaveOptions();

        /// <summary>
        /// Method to save the application base User Interface.
        /// </summary>
       void SaveUi();

        /// <summary>
        /// Method to load and deserialize a file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized object.</returns>
        T Deserialize<T>(string filename);

        #endregion

    }
}