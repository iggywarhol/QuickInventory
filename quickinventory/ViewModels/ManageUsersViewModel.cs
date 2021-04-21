using System.Windows.Input;
//
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
namespace SimpleInventory.ViewModels
{
    class ManageUsersViewModel : BaseViewModel, ICreatedUser
    {
        private bb_accesscontrol_User _selectedUser;
        SimpleInventoryContext simpleInventoryContext = new SimpleInventoryContext();
        public ManageUsersViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
        }
        public bb_accesscontrol_User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; NotifyPropertyChanged(); NotifyPropertyChanged(nameof(CanEditDeleteCurrentUser)); }
        }
        public bool CanEditDeleteCurrentUser
        {
            get { return _selectedUser != null && _selectedUser.ID != CurrentUser.ID; }
        }
        public ICommand GoToMainMenu
        {
            get { return new RelayCommand(PopToMainMenu); }
        }
        private void PopToMainMenu()
        {
            PopViewModel();
        }
        public ICommand MoveToAddUserScreen
        {
            get { return new RelayCommand(LoadAddUserScreen); }
        }
        public ICommand MoveToEditUserScreen
        {
            get { return new RelayCommand(LoadEditUserScreen); }
        }
        private void LoadAddUserScreen()
        {
            PushViewModel(new CreateOrEditUserViewModel(ViewModelChanger, this) { CurrentUser = CurrentUser });
        }
        private void LoadEditUserScreen()
        {
            PushViewModel(new CreateOrEditUserViewModel(ViewModelChanger, SelectedUser, this) { CurrentUser = CurrentUser });
        }
        public void CreatedUser(bb_accesscontrol_User user)
        {
            simpleInventoryContext.Users.Add(user);
            simpleInventoryContext.SaveChanges();
        }
        public void DeleteUser(bb_accesscontrol_User user)
        {
            simpleInventoryContext.Users.Attach(user);
            simpleInventoryContext.Users.Remove(user);
            simpleInventoryContext.SaveChanges();
        }
    }
}
