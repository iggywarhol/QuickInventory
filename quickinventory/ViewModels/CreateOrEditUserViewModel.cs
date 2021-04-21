using SimpleInventory.Interfaces;
using SimpleInventory.Models;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security;
using System.Windows.Input;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
namespace SimpleInventory.ViewModels
{
    class CreateOrEditUserViewModel : BaseViewModel
    {
        private bool _isCreating;
        private bb_accesscontrol_User _user;
        private SecureString _password;
        private SecureString _confirmPassword;

        private string _screenTitle;
        private bool _shouldShowPasswordFields;
        private string _passwordTitle;
        private string _confirmPasswordTitle;
        private string _errorMessage;

        private ICreatedUser _createdUserCallback;

       SimpleInventoryContext simpleInventoryContext = new SimpleInventoryContext();

        public CreateOrEditUserViewModel(IChangeViewModel viewModelChanger, ICreatedUser createdUserCallback) : base(viewModelChanger)
        {
            _isCreating = true;
            _user = new bb_accesscontrol_User();
            _user.UserPermission = new bb_accesscontrol_Permissions();
            ScreenTitle = "Add User";
            PasswordTitle = "Password";
            ConfirmPasswordTitle = "Confirm Password";
            ShouldShowPasswordFields = true;
            ErrorMessage = "";
            _createdUserCallback = createdUserCallback;
        }

        public CreateOrEditUserViewModel(IChangeViewModel viewModelChanger, bb_accesscontrol_User userToEdit, ICreatedUser createdUserCallback) : base(viewModelChanger)
        {
            IQueryable<bb_accesscontrol_Permissions> rdperm = simpleInventoryContext.UserPermissions.Where(e => e.UserID == userToEdit.UserPermission_Id);
            //var l = x.ToList();
            _isCreating = false;
            _user = userToEdit;
            _user.UserPermission = rdperm.ToList()[0];
            ScreenTitle = "Edit User";
            PasswordTitle = "New Password";
            ConfirmPasswordTitle = "Confirm New Password";
            ShouldShowPasswordFields = false;
            ErrorMessage = "";
            _createdUserCallback = createdUserCallback;
        }

        public bb_accesscontrol_User User
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(); }
        }

        public bool IsCreating
        {
            get { return _isCreating; }
            set { _isCreating = value; NotifyPropertyChanged(); }
        }

        public bool IsEditing
        {
            get { return !_isCreating; }
        }

        public bool ShouldShowPasswordFields
        {
            get { return _shouldShowPasswordFields; }
            set { _shouldShowPasswordFields = value; NotifyPropertyChanged(); }
        }

        public string ScreenTitle
        {
            get { return _screenTitle; }
            set { _screenTitle = value; NotifyPropertyChanged(); }
        }

        public string PasswordTitle
        {
            get { return _passwordTitle; }
            set { _passwordTitle = value; NotifyPropertyChanged(); }
        }

        public string ConfirmPasswordTitle
        {
            get { return _confirmPasswordTitle; }
            set { _confirmPasswordTitle = value; NotifyPropertyChanged(); }
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

        public ICommand ReturnToManageUsers
        {
            get { return new RelayCommand(GoBackToManageUsers); }
        }

        private void GoBackToManageUsers()
        {
            PopViewModel();
        }

        public ICommand SaveUser
        {
            get { return new RelayCommand(SaveAndGoBack); }
        }

        private void SaveAndGoBack()
        {
            var password = Utilities.SecureStringToString(Password);
            if (_shouldShowPasswordFields && password != Utilities.SecureStringToString(ConfirmPassword))
            {
                ErrorMessage = "Password and Confirm Password must match";
            }
            else if (_shouldShowPasswordFields && (Password == null || password == ""))
            {
                ErrorMessage = "Password cannot be blank";
            }
            else
            {
                ErrorMessage = "";
                if (_isCreating)
                {
                    simpleInventoryContext.Users.Add(_user);
                    simpleInventoryContext.UserPermissions.Add(_user.UserPermission);
                    simpleInventoryContext.SaveChanges();
                }
                else
                {
                    simpleInventoryContext.Users.AddOrUpdate(_user);
                    simpleInventoryContext.UserPermissions.AddOrUpdate(_user.UserPermission);
                    simpleInventoryContext.SaveChanges();
                }
                PopViewModel();
            }
        }
    }
}
