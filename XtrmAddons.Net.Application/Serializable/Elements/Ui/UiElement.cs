using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.Ui
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements UI Element.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UiElement<T> : ElementBase
    {
        #region Variables

        /// <summary>
        /// Property value of the property of the UI element.
        /// </summary>
        [XmlIgnore]
        public List<BindingProperty<T>> context = new List<BindingProperty<T>>();

        #endregion



        #region Properties

        /// <summary>
        /// Property value of the property of the UI element.
        /// </summary>
        [XmlElement("Context")]
        [JsonProperty(PropertyName = "Context")]
        public List<BindingProperty<T>> Context
        {
            get => context;
            set
            {
                if (value != context)
                {
                    context = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        public UiElement() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(Control ctrl)
        {
            if (ctrl == null)
            {
                throw new ArgumentNullException(nameof(ctrl));
            }

            if (ctrl.Uid.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Uid));
            }

            if (ctrl.Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Name));
            }

            Key = KeyFormat(ctrl);
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(Control ctrl, string propertyName, T propertyValue) : this(ctrl)
        {
            if (propertyName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            Context.Add(new BindingProperty<T>(propertyName, propertyValue));
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <param name="properties"></param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(Control ctrl, List<BindingProperty<T>> properties) : this(ctrl)
        {
            Context = properties ?? new List<BindingProperty<T>>(); ;
        }

        #endregion



        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static string KeyFormat(Control ctrl)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", ctrl.Uid, ctrl.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BindingProperty<T> FindBindingProperty(string name)
        {
            return Context.Find(x => x.Name == name);
        }

        #endregion
    }
}
