using Newtonsoft.Json;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Preferences.
    /// </summary>
    [XmlRoot("Configuration", Namespace= "http://www.xtrmaddons.com/", IsNullable = false)]
    [JsonObject(MemberSerialization.OptIn)]
    public class Preferences
    {
        #region Properties

        /// <summary>
        /// Property to access to the base directory for application options and directories.
        /// </summary>
        [XmlElement("BaseDirectory")]
        [JsonProperty(PropertyName = "BaseDirectory")]
        public string BaseDirectory { get; set; }

        /// <summary>
        /// Property to access to the language used by the user.
        /// </summary>
        [XmlElement("Language")]
        [JsonProperty(PropertyName = "Language")]
        public string Language { get; set; }

        /// <summary>
        /// Property to access to the storage informations like list of directories... used by default by the application.
        /// </summary>
        [XmlElement("Storage")]
        [JsonProperty(PropertyName = "Storage")]
        public StorageOptions Storage;

        /// <summary>
        /// Property to access to the list of specials directories used by default by the application.
        /// </summary>
        [XmlElement("SpecialDirectories")]
        [JsonProperty(PropertyName = "SpecialDirectories")]
        public SpecialDirectories SpecialDirectories;

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Preferences constructor.
        /// </summary>
        public Preferences()
        {
            SpecialDirectories = new SpecialDirectories();
            Storage = new StorageOptions();
        }

        #endregion
    }
}
