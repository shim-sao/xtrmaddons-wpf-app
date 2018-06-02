using Newtonsoft.Json;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.Base;

namespace XtrmAddons.Net.Application.Serializable.Elements.Remote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Clients List.
    /// </summary>
    [JsonArray()]
    public class Clients : ElementsBase<Client>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Clients List Constructor.
        /// </summary>
        public Clients() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Clients List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Clients(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Clients List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Clients(IEnumerable<Client> collection) : base(collection) { }

        #endregion
    }
}
