using System.Windows;
using XtrmAddons.Net.Application.Helpers;

namespace XtrmAddons.Net.Application.Examples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class XtrmAddons Net Application Examples Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ApplicationStart();
        }

        /// <summary>
        /// Method example of application start.
        /// </summary>
        public void ApplicationStart()
        {
            TextBox_UserApplicationData.Text = DirectoryHelper.UserAppData;
            TextBox_UserMyDocuments.Text = DirectoryHelper.UserMyDocuments;

            // Displays default application scheme directories.
            TextBox_Bin.Text = ApplicationBase.Directories.Bin;
            TextBox_Cache.Text = ApplicationBase.Directories.Cache;
            TextBox_Config.Text = ApplicationBase.Directories.Config;
            TextBox_Data.Text = ApplicationBase.Directories.Data;
            TextBox_Theme.Text = ApplicationBase.Directories.Theme;
        }
    }
}
