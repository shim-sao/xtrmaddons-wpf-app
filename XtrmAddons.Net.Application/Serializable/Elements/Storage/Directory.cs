using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.Storage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Directory Info.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Directory : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property relative path of the directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        [JsonProperty(PropertyName = "Value")]
        public string RelativePath { get; set; }

        /// <summary>
        /// Property defines if path of the directory is relative or absolute path.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "IsRelative")]
        [JsonProperty(PropertyName = "IsRelative")]
        public bool IsRelative { get; set; }

        /// <summary>
        /// Property root path of the directory if is define to relative path.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Root")]
        [JsonProperty(PropertyName = "Root")]
        public string Root { get; set; }

        /// <summary>
        /// Property absolute path of the directory.
        /// </summary>
        [XmlIgnore]
        public string AbsolutePath
        {
            get
            {
                if(!IsRelative)
                {
                    return RelativePath;
                }

                if (!RelativePath.IsNullOrWhiteSpace())
                {
                    return Path.Combine(GetRootAbsolutePath(), RelativePath);
                }

                return null;
            }
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directory Info Constructor.
        /// </summary>
        public Directory() : base() { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to get the absolute path of the root of the directory.
        /// </summary>
        /// <returns>The absolute path of the root of the directory.</returns>
        private string GetRootAbsolutePath()
        {
            switch (Root)
            {
                case "{Cache}":
                    return ApplicationBase.Directories.Cache;

                case "{Config}":
                    return ApplicationBase.Directories.Config;

                case "{Data}":
                    return ApplicationBase.Directories.Data;

                case "{Logs}":
                    return ApplicationBase.Directories.Logs;

                case "":
                    return ApplicationBase.Directories.Base;
            }

            return Root;
        }

        /// <summary>
        /// Method wrapper to system directory exists.
        /// </summary>
        /// <param name="fullName">The full name or path to the directory.</param>
        /// <returns>True if the directory exists otherwise, false.</returns>
        public static bool Exists(string fullName)
        {
            return System.IO.Directory.Exists(fullName);
        }

        /// <summary>
        /// <para>Method to a create directory</para>
        /// <para>Method wrapper to system directory create directory.</para>
        /// </summary>
        /// <param name="fullName">The full name or path to the directory.</param>
        public static void CreateDirectory(string fullName)
        {
            System.IO.Directory.CreateDirectory(fullName);
        }

        /// <summary>
        /// Method to the create directory.
        /// </summary>
        public void Create()
        {
            System.IO.Directory.CreateDirectory(AbsolutePath);
        }

        /// <summary>
        /// Method wrapper to system directory create directory.
        /// </summary>
        /// <param name="relativePath">The full name or path to the directory.</param>
        public string Combine(string relativePath)
        {
            return Path.Combine(AbsolutePath, relativePath);
        }

        #endregion
    }
}