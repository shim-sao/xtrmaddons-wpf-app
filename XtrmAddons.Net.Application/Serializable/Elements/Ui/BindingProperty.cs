using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;
using XtrmAddons.Net.Common.Extensions;
using XtrmAddons.Net.Common.Objects;

namespace XtrmAddons.Net.Application.Serializable.Elements.Ui
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Binding Property.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BindingProperty<T> : ObjectBaseNotifier
    {
        #region Variables

        /// <summary>
        /// Property name of the UI element.
        /// </summary>
        [XmlIgnore]
        public string name;

        /// <summary>
        /// Property value of the property of the UI element.
        /// </summary>
        [XmlIgnore]
        public T val;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the name of property of the UI element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        [JsonProperty(PropertyName = "Name")]
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the value of the property of the UI element.
        /// </summary>
        [XmlElement("Value")]
        [JsonProperty(PropertyName = "Value")]
        public T Value
        {
            get => val;
            set
            {
                if ((value != null && !value.Equals(val)) || (value == null && val != null))
                {
                    val = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        public BindingProperty() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The value of the property</param>
        /// <exception cref="ArgumentNullException"/>
        public BindingProperty(string propertyName, T propertyValue)
        {
            if (propertyName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            Name = propertyName;
            Value = propertyValue;
        }

        #endregion
    }
}
