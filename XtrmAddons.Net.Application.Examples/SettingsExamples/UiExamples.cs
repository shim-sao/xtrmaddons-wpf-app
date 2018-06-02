using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using XtrmAddons.Net.Application.Serializable.Elements.Base;
using XtrmAddons.Net.Application.Serializable.Elements.Ui;

namespace XtrmAddons.Net.Application.Examples.SettingsExamples
{
    internal static class UiExamples
    {
        public static void AddParameters()
        {
            ApplicationBase.UI.Parameters.AddKeySingle(
                new ElementBaseObject
                {
                    Key = "MyParameters1",
                    Name = "NameOfParameter",
                    Value = "1"
                });

            ApplicationBase.UI.Parameters.AddKeySingle(
                new ElementBaseObject
                {
                    Key = "MyParameters2",
                    Name = "NameOfParameter",
                    Value = "another value"
                });
        }
    
        public static void AddUiProperties()
        {
            ApplicationBase.UI.Controls.AddKeySingle(
                new UiElement<object>
                {
                    Key = "MyParameters1",
                    Context = { new BindingProperty<object>("IsChecked", true) }
                });

            Button b = new Button
            {
                Uid = "MyButtonUid",
                Name = "MyButtonName",
                IsEnabled = false
            };

            ApplicationBase.UI.Controls.AddKeySingle(new UiElement<object>(b, "IsEnabled", false));

            // Adding of a new property to store
            UiElement<object> btn = ApplicationBase.UI.Controls.FindControl(b);
            btn.Context.Add(new BindingProperty<object> { Name = "Content", Value = "Enter" });

            b.Content = btn.FindBindingProperty("Content").Value;
            b.IsEnabled = (bool)btn.FindBindingProperty("IsEnabled").Value;

            var test = b;
        }
    }
}
