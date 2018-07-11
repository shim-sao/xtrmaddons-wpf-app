using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Application.Serializable.Elements.Ui;
using XtrmAddons.Net.Common.Extensions;

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



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable User Interface Constructor.
        /// </summary>
        public UserInterface()
        {
            Parameters = new ElementBaseObjects();
            Controls = new UiElements();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to add a simple parameter.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="paramValue">The value of the parameter.</param>
        /// <returns></returns>
        public string AddParameter(string paramName, string paramValue)
        {
            ElementBaseObject param = Parameters.FindKeyFirst(paramName);
            if (param == null)
            {
                Parameters.Add(new ElementBaseObject( ) { Key = paramName, Value = paramValue });
            }
            else
            {
                param.Value = paramValue;
            }

            return paramValue;
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable User Interface Constructor.
        /// </summary>
        public string GetParameter(string paramName, string paramValue = null, bool setDefault = true)
        {
            ElementBaseObject param = Parameters.FindKeyFirst(paramName);
            if (param != null)
            {
                return param.Value;
            }
            else if(setDefault)
            {
                return AddParameter(paramName, paramValue);
            }

            return paramValue;
        }

        #endregion

        
    }
}
