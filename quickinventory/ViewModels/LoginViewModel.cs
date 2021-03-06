using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleInventory.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string _username;
        private SecureString _password;
        private string _error;
        SimpleInventoryContext simpleInventoryContext = new SimpleInventoryContext();

        public LoginViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(); }
        }

        public SecureString Password
        {
            private get { return _password; }
            set { _password = value; NotifyPropertyChanged(); }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; NotifyPropertyChanged(); }
        }

        public ICommand AttemptLogin
        {
            get { return new RelayCommand(TryLogin); }
        }

        private void TryLogin()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Error = "Username is required";
            }
            else if (Password == null)
            {
                Error = "Password is required";
            }
            else
            {
                string s = Utilities.SecureStringToString(Password);
                string s1 = User.HashPassword("changeme");
                List<User> uu = simpleInventoryContext.Users.ToList();
                User user = uu.Find(x => x.Username == Username && x.PasswordHash == s1);
                if (user != null)
                {
                    Username = "";
                    Password.Clear();
                    Error = "";
                    PushViewModel(new HomeScreenViewModel(ViewModelChanger) { CurrentUser = user });
                }
                else
                {
                    Error = "Invalid username or password";
                }

            }
        }
    }
}
