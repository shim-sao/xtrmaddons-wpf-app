using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.Base
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Elements Base Object.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class ElementBaseObject : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the object or property.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property value of the object or property.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Elements Base Object Constructor.
        /// </summary>
        public ElementBaseObject() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Elements Base Object Constructor.
        /// </summary>
        public ElementBaseObject(string Name ="", string Value = "" ) : base() { }
        
        #endregion
    }
}
