using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
//
using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
//
namespace SimpleInventory.ViewModels
{
    class ManageItemsViewModel : BaseViewModel, ICreatedInventoryItem
    {
        private ObservableCollection<bbBaseGroup> _items;
        private int _selectedIndex = 0;
        private bbBaseGroup _selectedItem;
        private bool _isItemSelected;
        SimpleInventoryContext db = new SimpleInventoryContext();
        public ManageItemsViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
            //_items = new ObservableCollection<bbItem>(db.Items.Include("ItemType"));
            _isItemSelected = false;
        }
        public ObservableCollection<bbBaseGroup> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(); }
        }
        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set { _isItemSelected = value; NotifyPropertyChanged(); }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; NotifyPropertyChanged(); IsItemSelected = value != -1; }
        }
        public bbBaseGroup SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyPropertyChanged(); }
        }
        public ICommand MoveToAddItemScreen
        {
            get { return new RelayCommand(LoadAddItemScreen); }
        }
        private void LoadAddItemScreen()
        {
            PushViewModel(new CreateOrEditItemViewModel(ViewModelChanger, this) { CurrentUser = CurrentUser });
        }
        public ICommand MoveToEditItemScreen
        {
            get { return new RelayCommand(LoadEditItemScreen); }
        }
        private void LoadEditItemScreen()
        {
            if (SelectedItem != null)
            {
                PushViewModel(new CreateOrEditItemViewModel(ViewModelChanger, SelectedItem) { CurrentUser = CurrentUser });
            }
        }
        //public ICommand MoveToAdjustQuantityScreen
        //{
        //    get { return new RelayCommand(LoadAdjustQuantityScreen); }
        //}
        //private void LoadAdjustQuantityScreen()
        //{
        //    // PushViewModel(new AdjustQuantityViewModel(ViewModelChanger, SelectedItem) { CurrentUser = CurrentUser });
        //}
        public ICommand GoToMainMenu
        {
            get { return new RelayCommand(PopToMainMenu); }
        }
        private void PopToMainMenu()
        {
            PopViewModel();
        }
        public void CreatedInventoryItem(bbBaseGroup item)
        {
            Items.Add(item);
        }
        public void DeleteItem(bbBaseGroup item)
        {
            if (item != null)
            {
                //item.Delete();
                //Items.Remove(item);
            }
        }
    }
}