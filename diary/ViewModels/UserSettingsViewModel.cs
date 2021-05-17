using diary.Commands;
using diary.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace diary.ViewModels
{

    
    public class UserSettingsViewModel : ViewModelBase
    {
        private UserSettings _userSettings;

        public UserSettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(ConfirmSettings);
            _userSettings = new UserSettings();

        }

        public ICommand CloseCommand { get; set; }

        public ICommand ConfirmCommand { get; set; }

        public UserSettings UserSettings
        {
            get
            {
                return _userSettings;
            }
            set
            {
                _userSettings = value;
                OnPropertyChanged();
            }
        }
        

      

        private string _userSettingsServerAdress;

        private string _userSettingsServerName;

        private string _userSettingsDataBaseName;

        private string _userSettingsUserName;

        private string _userSettingsUserPassword;

        public static string _userConnectionString;


        public string UserSettingsServerAdress
        {
            get { return _userSettingsServerAdress; }
            set
            {
                _userSettingsServerAdress = value;
                OnPropertyChanged();
            }
        }

        public string UserSettingsServerName
        {
            get { return _userSettingsServerName; }
            set
            {
                _userSettingsServerName = value;
                OnPropertyChanged();
            }
        }

        public string UserSettingsDataBaseName
        {
            get { return _userSettingsDataBaseName; }
            set
            {
                _userSettingsDataBaseName = value;
                OnPropertyChanged();
            }
        }

        public string UserSettingsUserName
        {
            get { return _userSettingsUserName; }
            set
            {
                _userSettingsUserName = value;
                OnPropertyChanged();
            }
        }

        public string UserSettingsUserPassword
        {
            get { return _userSettingsUserPassword; }
            set
            {
                _userSettingsUserPassword = value;
                OnPropertyChanged();
            }
        }

       
        public void ConfirmSettings(object obj)
        {

          
            UserSettings.Save();
            RestartApplication();

        }
        private void RestartApplication()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();

        }
    }

    
}