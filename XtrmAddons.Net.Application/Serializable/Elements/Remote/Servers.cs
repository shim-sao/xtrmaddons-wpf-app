using Newtonsoft.Json;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.Base;

namespace XtrmAddons.Net.Application.Serializable.Elements.Remote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Servers List.
    /// </summary>
    [JsonArray()]
    public class Servers : ElementsBase<Server>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Servers List Constructor.
        /// </summary>
        public Servers() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Servers List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Servers(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Servers List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Servers(IEnumerable<Server> collection) : base(collection) { }

        #endregion
    }
}
