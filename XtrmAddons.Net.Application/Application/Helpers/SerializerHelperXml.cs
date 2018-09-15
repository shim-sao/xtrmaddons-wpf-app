using System;
using System.IO;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable;

namespace XtrmAddons.Net.Application.Helpers
{
    /// <summary>
    /// Class XtrmAddons Net Application Helpers Xml.
    /// </summary>
    public class SerializerHelperXml : SerializerHelper
    {
        #region Properties

#if DEBUG
        /// <summary>
        /// Constant preferences Json file name. 
        /// </summary>
        public override string FileName_Preferences { get; } = "preferences.debug.xml";

        /// <summary>
        /// Constant options Json file name.
        /// </summary>
        public override string FileName_Options { get; } = "options.debug.xml";

        /// <summary>
        /// Constant user interface Json file name.
        /// </summary>
        public override string FileName_Ui { get; } = "ui.debug.xml";

#else

        /// <summary>
        /// Constant preferences Json file name. 
        /// </summary>
        public override string FileName_Preferences { get; } = "preferences.xml";

        /// <summary>
        /// Constant options Json file name.
        /// </summary>
        public override string FileName_Options { get; } = "options.xml";

        /// <summary>
        /// Constant user interface Json file name.
        /// </summary>
        public override string FileName_Ui { get; } = "ui.xml";

#endif

        #endregion



        #region Methods

        /// <summary>
        /// Method to load the application preferences from Xml file.
        /// </summary>
        public override Preferences LoadPreferences()
        {
            if (File.Exists(FilePath_Preferences))
            {
                return Deserialize<Preferences>(FilePath_Preferences);
            }

            return new Preferences();
        }

        /// <summary>
        /// Method to load the application options from Xml file.
        /// </summary>
        public override Options LoadOptions()
        {
            if (File.Exists(FilePath_Options))
            {
                return Deserialize<Options>(FilePath_Options);
            }

            return new Options();
        }

        /// <summary>
        /// Method to load the application ui from Xml file.
        /// </summary>
        public override UserInterface LoadUi()
        {
            if (File.Exists(FilePath_Ui))
            {
                return Deserialize<UserInterface>(FilePath_Ui);
            }

            return new UserInterface();
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
            using (TextWriter writer = new StreamWriter(FilePath_Preferences))
            {
                XmlSerializer serializerPreferences = new XmlSerializer(typeof(Preferences));
                serializerPreferences.Serialize(writer, pref);
            }
        }

        /// <summary>
        /// Method to save the application Options only into a file.
        /// </summary>
        public override void SaveOptions()
        {
            using (TextWriter writer = new StreamWriter(FilePath_Options))
            {
                XmlSerializer serializerPreferences = new XmlSerializer(typeof(Options));
                serializerPreferences.Serialize(writer, ApplicationBase.Options);
            }
        }

        /// <summary>
        /// Method to save the application Preferences only into a file.
        /// </summary>
        public override void SaveUi()
        {
            using (TextWriter writer = new StreamWriter(FilePath_Ui))
            {
                XmlSerializer serializerPreferences = new XmlSerializer(typeof(UserInterface));
                serializerPreferences.Serialize(writer, ApplicationBase.UI);
            }
        }

        /// <summary>
        /// Method to load and deserialize a Xml file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized Xml object.</returns>
        public override T Deserialize<T>(string filename)
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // If the XML document has been altered with unknown nodes or attributes, handle them with the UnknownNode and UnknownAttribute events.
            serializer.UnknownNode += new XmlNodeEventHandler(Serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(Serializer_UnknownAttribute);

            // A FileStream is needed to read the XML document.
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                // Use the Deserialize method to restore the object's state with data from the XML document.
                return (T)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Method to handle unknown-ed XML nodes.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">XML node event arguments.</param>
        private static void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        /// <summary>
        /// Method to handle unknown-ed XML attributes.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">XML node event arguments.</param>
        private static void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }

#endregion

    }
}
