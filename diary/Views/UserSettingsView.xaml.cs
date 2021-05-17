using diary.ViewModels;
using MahApps.Metro.Controls;


namespace diary.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserSettings.xaml
    /// </summary>
    public partial class UserSettingsView : MetroWindow
    {
        public UserSettingsView()
        {
            InitializeComponent();
            DataContext = new UserSettingsViewModel();
        }
    }
}
