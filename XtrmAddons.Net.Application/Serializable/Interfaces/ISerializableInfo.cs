using System.Collections.Generic;

namespace XtrmAddons.Net.Application.Serializable.Interfaces
{
    /// <summary>
    /// Interface XtrmAddons Net Application Serializable Elements Informations List.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializableInfo<T>
    {
        #region Methods Find

        /// <summary>
        /// Method to find an element by a property value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value to search.</param>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        T FindWithFirst(string propertyName, object value);

        /// <summary>
        /// Method to find all elements by a property value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        List<T> FindWithAll(string propertyName, object value);

        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        T FindKeyFirst(string value);

        /// <summary>
        /// Method to find all elements by a Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        List<T> FindKeyAll(string value);

        /// <summary>
        /// Method to find an element flagged to default.
        /// </summary>
        /// <returns>The first founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        T FindDefaultFirst();

        /// <summary>
        /// Method to find all elements found flagged to default.
        /// </summary>
        /// <returns>The founded elements list otherwise, default empty List.</returns>
        List<T> FindDefaultAll();

        #endregion



        #region Methods Add

        /// <summary>
        /// Method to add a new unique default element into the list.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void AddDefaultSingle(T element);

        #endregion



        #region Methods Remove
        
        /// <summary>
        /// Method to remove the first element found by a Key property value.
        /// </summary>
        /// <param name="value">The value to search.</param>
        /// <returns>true if item is deleted; otherwise, false. This method also returns false if item is not found.</returns>
        bool RemoveKeyFirst(string value);

        /// <summary>
        /// Method to remove all elements with same Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        int RemoveKeyAll(string value);

        #endregion



        #region Methods Replace

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        void ReplaceKeyFirst(T element);

        /// <summary>
        /// <para>Method to add or update an element flagged by default.</para>
        /// </summary>
        /// <param name="element">The element to add or update list and flag it by default.</param>
        void ReplaceDefault(T element);

        #endregion



        #region Methods Set

        /// <summary>
        /// Method to flag all elements default to false or none.
        /// </summary>
        void SetDefaultAllNone();

        /// <summary>
        /// Method to flag all elements default to true or yes.
        /// </summary>
        void SetDefaultAll();

        #endregion
    }
}
