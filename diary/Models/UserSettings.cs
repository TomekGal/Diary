using diary.Properties;



namespace diary.Models
{
    public class UserSettings
    {

        
        public string ServerAdress
        {
            get
            {
                return Settings.Default.ServerAdress;
            }
            set
            {
                Settings.Default.ServerAdress = value;
            }
        }
        public string ServerName
        {
            get
            {
                return Settings.Default.ServerName;
            }
            set
            {
                Settings.Default.ServerName = value;
            }
        }
        public string DataBaseName
        {
            get
            {
                return Settings.Default.DataBaseName;
            }
            set
            {
                Settings.Default.DataBaseName = value;
            }
        }
        public string UserName
        {
            get
            {
                return Settings.Default.UserName;
            }
            set
            {
                Settings.Default.UserName = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return Settings.Default.UserPassword;
            }
            set
            {
                Settings.Default.UserPassword = value;
            }
        }

        public void Save()
        {
            Settings.Default.Save();
        }

    }
}

