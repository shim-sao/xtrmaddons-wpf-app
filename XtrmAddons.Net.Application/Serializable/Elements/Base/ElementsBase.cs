using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Interfaces;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.Base
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Elements Base.
    /// </summary>
    [JsonArray()]
    public abstract class ElementsBase<T> : List<T>, ISerializableInfo<T>
    {
        #region constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Elements Base Constructor.
        /// </summary>
        public ElementsBase() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Elements Base Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public ElementsBase(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Elements Base Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public ElementsBase(IEnumerable<T> collection) : base(collection) { }

        #endregion



        #region Methods Find

        /// <summary>
        /// Method to find an element by a property value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value to search.</param>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindWithFirst(string propertyName, object value)
        {
            if(propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            return Find(x => x.HasPropertyEquals(propertyName, value));
        }

        /// <summary>
        /// Method to find all elements by a property value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        public List<T> FindWithAll(string propertyName, object value)
        {
            return FindAll(x => x.HasPropertyEquals(propertyName, value));
        }

        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindKeyFirst(string value)
        {
            return FindWithFirst("Key", value);
        }

        /// <summary>
        /// Method to find all elements by a Key property value.
        /// </summary>
        /// <param name="value">The property value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        public List<T> FindKeyAll(string value)
        {
            return FindWithAll("Key", value);
        }

        /// <summary>
        /// Method to find an element flagged to default.
        /// </summary>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindDefaultFirst()
        {
            return FindWithFirst("IsDefault", true);
        }

        /// <summary>
        /// Method to find all elements found flagged to default.
        /// </summary>
        /// <returns>The founded elements list otherwise, default empty List.</returns>
        public List<T> FindDefaultAll()
        {
            return FindWithAll("IsDefault", true);
        }

        #endregion



        #region Methods Add

        /// <summary>
        /// Method to add a new unique default element into the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void AddDefaultSingle(T item)
        {
            SetDefaultAllNone();
            item.SetPropertyValue("IsDefault", true);
            Add(item);
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update the first elemet and remove all others elements with the same Key if at least one element is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        /// <returns>The numer of items removed before adding.</returns>
        public int AddKeySingle(T element)
        {
            string k = element.GetPropertyValue<string>("Key");
            int nb = RemoveKeyAll(element.GetPropertyValue<string>("Key"));
            Add(element);
            return nb;
        }

        #endregion



        #region Methods Remove

        /// <summary>
        /// Method to remove the first element found by a Key property value.
        /// </summary>
        /// <param name="value">The value to search.</param>
        /// <returns>true if item is deleted; otherwise, false. This method also returns false if item is not found.</returns>
        public bool RemoveKeyFirst(string value)
        {
            T item = Find(x => x.HasPropertyEquals("Key", value));
            if (item == null || item.Equals(default(T)))
            {
                return false;
            }
            return Remove(item);
        }

        /// <summary>
        /// Method to remove all elements with same Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        /// <returns>the numer of items removed.</returns>
        public int RemoveKeyAll(string value)
        {
            return RemoveAll(x => x.HasPropertyEquals("Key", value));
        }

        #endregion



        #region Methods Remove

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update the first element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        public void ReplaceKeyFirst(T element)
        {
            Predicate<T> match = x => x.HasPropertyEquals("Key", element.GetPropertyValue("Key"));
            T item = Find(match);
            if (item == null || item.Equals(default(T)))
            {
                Add(element);
            }
            else
            {
                this[FindIndex(match)] = element;
            }
        }

        /// <summary>
        /// <para>Method to add or update an element flagged by default.</para>
        /// </summary>
        /// <param name="element">The element to add or update list and flag it by default.</param>
        public void ReplaceDefault(T element)
        {
            T item = FindDefaultFirst();
            element.SetPropertyValue("IsDefault", true);

            if (item == null || item.Equals(default(T)))
            {
                SetDefaultAllNone();
                Add(element);
            }
            else
            {
                int index = FindIndex(x => (bool)x.GetPropertyValue("IsDefault") == true);
                SetDefaultAllNone();
                this[index] = element;
            }
        }

        #endregion



        #region Methods Set

        /// <summary>
        /// Method to flag all elements default to false or none.
        /// </summary>
        public void SetDefaultAllNone()
        {
            List<T> defaultElements = FindDefaultAll();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue("IsDefault", false);
            }
        }

        /// <summary>
        /// Method to flag all elements default to true or yes.
        /// </summary>
        public void SetDefaultAll()
        {
            List<T> defaultElements = FindDefaultAll();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue("IsDefault", true);
            }
        }

        #endregion
    }
}