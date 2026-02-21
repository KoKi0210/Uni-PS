using DataLayer;
using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.ObjectModel;
using UI.ViewModel;

namespace UI.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        private ObservableCollection<DatabaseUser> _users;

        public ObservableCollection<DatabaseUser> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public StudentsViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                var dbUsers = context.Users.ToList();

                Users = new ObservableCollection<DatabaseUser>(dbUsers);
            }
        }
    }
}