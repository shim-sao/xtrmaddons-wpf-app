using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Application.Serializable.Elements.Ui;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable User Interface.
    /// </summary>
    [XmlRoot("UserInterface", Namespace = "http://www.xtrmaddons.com/", IsNullable = false)]
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInterface
    {
        #region Properties

        /// <summary>
        /// Property  to access to the list of elements base objects parameters container.
        /// </summary>
        [XmlElement("Properties")]
        [JsonProperty(PropertyName = "Parameters")]
        public ElementBaseObjects Parameters;

        /// <summary>
        /// Property to access to the list of UI elements controls container.
        /// </summary>
        [XmlElement("UI")]
        [JsonProperty(PropertyName = "Controls")]
        public UiElements Controls;

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable User Interface Constructor.
        /// </summary>
        public UserInterface()
        {
            Parameters = new ElementBaseObjects();
            Controls = new UiElements();
        }

        #endregion

    }
}
