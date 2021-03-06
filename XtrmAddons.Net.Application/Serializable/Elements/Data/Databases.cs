﻿using Newtonsoft.Json;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.Base;

namespace XtrmAddons.Net.Application.Serializable.Elements.Data
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Databases List.
    /// </summary>
    [JsonArray()]
    public class Databases : ElementsBase<Database>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Databases List Constructor.
        /// </summary>
        public Databases() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Databases List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Databases(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Databases List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Databases(IEnumerable<Database> collection) : base(collection) { }

        #endregion
    }
}
