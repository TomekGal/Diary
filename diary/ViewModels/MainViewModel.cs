using diary.Commands;
using diary.Models.Domains;
using diary.Models.Wrappers;
using diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace diary.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();

        
        public MainViewModel()
        {

            AddStudentCommand = new RelayCommand(AddEditStudent);

            EditStudentCommand = new RelayCommand(AddEditStudent, CanEditDeleteStudents);

            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, CanEditDeleteStudents);

            RefreshStudentsCommand = new RelayCommand(RefreshStudents);

            UserSettingsCommand = new RelayCommand(UserSettings );
           
             CloseCommand = new RelayCommand(Close);

            ConfirmCommand = new RelayCommand(ConfirmSettings);
           
            if (!CheckSettings())
            {
                
                var metrodialog = new DialogWindow() ;
                metrodialog.ShowMetroWindow();

               
            }
            else
            {
                RefreshDiary();

                InitGroups();
            }

           
 
        }

       

        public ICommand AddStudentCommand { get; set; }

        public ICommand EditStudentCommand { get; set; }

        public ICommand DeleteStudentCommand { get; set; }

        public ICommand RefreshStudentsCommand { get; set; }

        public ICommand UserSettingsCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand ConfirmCommand { get; set; }

        private StudentWrapper _selectedStudent;

        public StudentWrapper SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentWrapper> _students;

        public ObservableCollection<StudentWrapper> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _group;

        public ObservableCollection<Group> Groups
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        private void RefreshStudents(object obj)
        {
            RefreshDiary();

        }

        private bool CanRefreshStudents(object obj)
        {
            return true;
        }

        private bool CheckSettings()
        {

            try
            {
                using (var connection = new ApplicationDbContext())
                {
                    connection.Database.Connection.Open();
                    connection.Database.Connection.Close();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        

        }
        private void InitGroups()
        {
            
            var groups=_repository.GetGroups();
            groups.Insert(0, new Group{ Id = 0, Name = "wszystkie" });

            Groups = new ObservableCollection<Group>(groups);
          
            SelectedGroupId = 0;
        }

        private bool CanEditDeleteStudents(object obj)
        {
            return SelectedStudent != null;
        }

        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Usuwanie ucznia", 
                $"Czy na pewno chcesz usunąć ucznia {SelectedStudent.FirstName} {SelectedStudent.LastName}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;
            // usuwanie ucznia z bazy 

            _repository.DeleteStudent(SelectedStudent.Id);

            RefreshDiary();
        }

        private void AddEditStudent(object obj)
        {
            var addEditStudentWindow = new AddEditStudentsView(obj as StudentWrapper);
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void UserSettings(object obj)
        {
            
            var userSettingWindow = new UserSettingsView();
            userSettingWindow.ShowDialog();
        }

        private void RefreshDiary()
        { 
            Students = new ObservableCollection<StudentWrapper>(
                _repository.GetStudents(SelectedGroupId));
            
              
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();

        }
        private void ConfirmSettings(object obj)
        {
            throw new NotImplementedException();
        }

       
        }
    }

