using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.Ui
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Ui Elements List.
    /// </summary>
    [JsonArray()]
    public class UiElements : ElementsBase<UiElement<object>>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Ui Elements List Constructor.
        /// </summary>
        public UiElements() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Ui Elements List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public UiElements(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Ui Elements List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public UiElements(IEnumerable<UiElement<object>> collection) : base(collection) { }

        #endregion



        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public UiElement<object> FindControl(Control ctrl)
        {
            string key = UiElement<object>.KeyFormat(ctrl);
            return Find(x => x.HasPropertyEquals("Key", key));
        }
    }
}