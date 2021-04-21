using SimpleInventory.Interfaces;
using System.Security;
using System.Windows.Input;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
namespace SimpleInventory.ViewModels
{
    class ChangePasswordViewModel : BaseViewModel
    {
        private SecureString _password;
        private SecureString _confirmPassword;

        private string _errorMessage;

        public ChangePasswordViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {

        }

        public SecureString Password
        {
            private get { return _password; }
            set { _password = value; NotifyPropertyChanged(); }
        }

        public SecureString ConfirmPassword
        {
            private get { return _confirmPassword; }
            set { _confirmPassword = value; NotifyPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; NotifyPropertyChanged(); }
        }

        public ICommand ReturnToMainMenu
        {
            get { return new RelayCommand(GoBackToManageUsers); }
        }

        private void GoBackToManageUsers()
        {
            PopViewModel();
        }

        public ICommand SavePassword
        {
            get { return new RelayCommand(SaveUserPassword); }
        }

        private void SaveUserPassword()
        {
            var password = Utilities.SecureStringToString(Password);
            if (password != Utilities.SecureStringToString(ConfirmPassword))
            {
                ErrorMessage = "Password and Confirm Password must match";
            }
            else if ((Password == null || password == ""))
            {
                ErrorMessage = "Password cannot be blank";
            }
            else
            {
                ErrorMessage = "";
                CurrentUser.UpdatePassword(password);
                PopViewModel();
            }
        }
    }
}
