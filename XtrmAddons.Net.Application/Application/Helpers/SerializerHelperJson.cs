using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using XtrmAddons.Net.Application.Serializable;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Helpers
{
    internal class SerializerHelperJson : SerializerHelper
    {
        #region Properties

        /// <summary>
        /// Constant preferences Json file name. 
        /// </summary>
        public override string FileName_Preferences { get; } = "preferences.json";

        /// <summary>
        /// Constant options Json file name.
        /// </summary>
        public override string FileName_Options { get; } = "options.json";

        /// <summary>
        /// Constant user interface Json file name.
        /// </summary>
        public override string FileName_Ui { get; } = "ui.json";

        #endregion



        #region Methods

        /// <summary>
        /// Method to load the application preferences from Xml file.
        /// </summary>
        public override Preferences LoadPreferences()
        {
            Trace.WriteLine("Serializer Json loading Preferences : " + FilePath_Preferences);

            if (File.Exists(FilePath_Preferences))
            {
                Trace.WriteLine("Serializer Json deserializing Preferences : " + FilePath_Preferences);
                return Deserialize<Preferences>(FilePath_Preferences);
            }

            return new Preferences();
        }

        /// <summary>
        /// Method to load the application options from Xml file.
        /// </summary>
        public override Options LoadOptions()
        {
            Trace.WriteLine("Serializer Json loading Options : " + FilePath_Options);

            if (File.Exists(FilePath_Options))
            {
                Trace.WriteLine("Serializer Json deserializing Options : " + FilePath_Preferences);
                return Deserialize<Options>(FilePath_Options);
            }
            
            return new Options();
        }

        /// <summary>
        /// Method to load the application ui from Xml file.
        /// </summary>
        public override UserInterface LoadUi()
        {
            Trace.WriteLine("Serializer Json load user interface : " + FilePath_Ui);

            if (File.Exists(FilePath_Ui))
            {
                Trace.WriteLine("Serializer Json deserializing Options : " + FilePath_Ui);
                return Deserialize<UserInterface>(FilePath_Ui);
            }

            return new UserInterface();
        }

        /// <summary>
        /// Method to get default Json serializer settings.
        /// </summary>
        /// <param name="converters">A list of Json converters.</param>
        /// <returns>A Json serializer settings.</returns>
        private static JsonSerializerSettings GetJss(List<JsonConverter> converters)
        {
            return new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                Converters = converters
            };
        }

        /// <summary>
        /// Method to save the application Preferences, options and user interface.
        /// </summary>
        public override void SaveAll(Preferences pref)
        {
            SavePreferences(pref);
            SaveOptions();
            SaveUi();
        }

        /// <summary>
        /// Method to save the application Preferences only into a file.
        /// </summary>
        public override void SavePreferences(Preferences pref)
        {
            File.WriteAllText(FilePath_Preferences, pref.ToJson());
        }

        /// <summary>
        /// Method to save the application Preferences only into a file.
        /// </summary>
        public override void SaveOptions()
        {
            File.WriteAllText(FilePath_Options, ApplicationBase.Options.ToJson());
        }

        /// <summary>
        /// Method to save the application Preferences only into a file.
        /// </summary>
        public override void SaveUi()
        {
            File.WriteAllText(FilePath_Ui, ApplicationBase.UI.ToJson());
        }

        /// <summary>
        /// Method to load and deserialize a Json file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized Json object.</returns>
        public override T Deserialize<T>(string filename)
        {
            string str = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// Method to load and deserialize a Json file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized Json object.</returns>
        public T Deserialize<T>(string filename, JsonSerializerSettings serializerSettings)
        {
            string str = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(str, serializerSettings);
        }

        #endregion

    }
}
