using Newtonsoft.Json;
using System;

namespace XtrmAddons.Net.Application.Serializable.Elements.Storage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Storage Options.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class StorageOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of directories informations.
        /// </summary>
        [JsonProperty(PropertyName = "Directories")]
        public Directories Directories { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Storage Options Constructor.
        /// </summary>
        public StorageOptions()
        {
            Directories = new Directories();
        }

        #endregion
    }
}