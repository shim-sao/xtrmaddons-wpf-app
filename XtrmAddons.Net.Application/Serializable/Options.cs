using Newtonsoft.Json;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Data;
using XtrmAddons.Net.Application.Serializable.Elements.Remote;
using XtrmAddons.Net.Application.Serializable.Elements.Storage;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Options.
    /// </summary>
    [XmlRoot("Options", Namespace="http://www.xtrmaddons.com/", IsNullable = false)]
    [JsonObject(MemberSerialization.OptIn)]
    public class Options
    {
        #region Properties

        /// <summary>
        /// Property list of databases.
        /// </summary>
        [XmlElement("Databases")]
        [JsonProperty(PropertyName = "Data")]
        public DataOptions Data;

        /// <summary>
        /// Property list of directories.
        /// </summary>
        [XmlElement("Storage")]
        [JsonProperty(PropertyName = "Storage")]
        public StorageOptions Storage;

        /// <summary>
        /// Property list of servers.
        /// </summary>
        [XmlElement("Remote")]
        [JsonProperty(PropertyName = "Remote")]
        public RemoteOptions Remote;

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Options Constructor.
        /// </summary>
        public Options()
        {
            Data = new DataOptions();
            Storage = new StorageOptions();
            Remote = new RemoteOptions();
        }

        #endregion
    }
}
