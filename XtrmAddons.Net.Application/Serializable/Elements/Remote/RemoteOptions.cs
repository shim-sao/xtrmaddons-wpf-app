﻿using Newtonsoft.Json;
using System;

namespace XtrmAddons.Net.Application.Serializable.Elements.Remote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Remote Options.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class RemoteOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of Clients informations.
        /// </summary>
        [JsonProperty(PropertyName = "Clients")]
        public Clients Clients { get; set; }

        /// <summary>
        /// Property to access to the list of Servers informations.
        /// </summary>
        [JsonProperty(PropertyName = "Servers")]
        public Servers Servers { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Remote Options Constructor.
        /// </summary>
        public RemoteOptions()
        {
            Servers = new Servers();
            Clients = new Clients();
        }

        #endregion
    }
}
