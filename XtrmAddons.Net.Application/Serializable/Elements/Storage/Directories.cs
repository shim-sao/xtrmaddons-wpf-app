﻿using Newtonsoft.Json;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.Base;

namespace XtrmAddons.Net.Application.Serializable.Elements.Storage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Directories List.
    /// </summary>
    [JsonArray()]
    public class Directories : ElementsBase<Directory>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directories List Constructor.
        /// </summary>
        public Directories() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directories List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Directories(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directories List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Directories(IEnumerable<Directory> collection) : base(collection) { }

        #endregion
    }
}
