using diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace diary
{
   public class DialogWindow
    {

        public async void ShowMetroWindow()
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Błąd połaczenia",
                $"Czy chcesz zmienić ustawienia?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog == MessageDialogResult.Affirmative)
            {

                var userSettingsWindow = new UserSettingsView();
                userSettingsWindow.ShowDialog();
            }
           

            else if (dialog == MessageDialogResult.Negative)
            {
                Application.Current.Shutdown();
            }


        }
    }
}
