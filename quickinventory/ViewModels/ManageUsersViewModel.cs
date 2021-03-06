﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//
using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
//
namespace SimpleInventory.ViewModels
{
    class ManageUsersViewModel : BaseViewModel, ICreatedUser
    {
        private User _selectedUser;
        SimpleInventoryContext simpleInventoryContext = new SimpleInventoryContext();
        public ManageUsersViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
        }
        public User SelectedUser
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
        public void CreatedUser(User user)
        {
            simpleInventoryContext.Users.Add(user);
            simpleInventoryContext.SaveChanges();
        }
        public void DeleteUser(User user)
        {
            simpleInventoryContext.Users.Attach(user);
            simpleInventoryContext.Users.Remove(user);
            simpleInventoryContext.SaveChanges();
        }
    }
}
