using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleInventory.ViewModels
{
    class ViewItemTypesViewModel : BaseViewModel, ICreatedEditedItemType
    {
        //private ObservableCollection<bbListType> _itemTypes;
        private int _selectedItemTypeIndex;
        //private bbListType _selectedItem;
        private bool _isNonDefaultItemSelected;
        private bool _isItemSelected;

        public ViewItemTypesViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
           // ItemTypes = new ObservableCollection<ItemType>(ItemType.LoadItemTypes());
        }

        //public ObservableCollection<ItemType> ItemTypes
        //{
        //    get { return _itemTypes; }
        //    set { _itemTypes = value; NotifyPropertyChanged(); }
        //}
        public int SelectedItemTypeIndex
        {
            get { return _selectedItemTypeIndex; }
            set { _selectedItemTypeIndex = value; NotifyPropertyChanged(); IsItemSelected = value != -1; }
        }


        /*
        public bbListType SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged();
                RefreshCanDelete();
            }
        }
        */

        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set { _isItemSelected = value; NotifyPropertyChanged(); }
        }

        public bool CanDelete
        {
            get { return _isNonDefaultItemSelected; }
            set { _isNonDefaultItemSelected = value; NotifyPropertyChanged(); }
        }
        public ICommand GoToMainMenu
        {
            get { return new RelayCommand(ReturnToPreviousScreen); }
        }
        private void ReturnToPreviousScreen()
        {
            PopViewModel();
        }
        public ICommand MoveToAddItemCategoryScreen
        {
            get { return new RelayCommand(LoadAddItemCategoryScreen); }
        }
        private void LoadAddItemCategoryScreen()
        {
            PushViewModel(new CreateOrEditItemTypeViewModel(ViewModelChanger, this) { CurrentUser = CurrentUser });
        }
        public ICommand MoveToEditItemCategoryScreen
        {
            get { return new RelayCommand(LoadEditItemCategoryScreen); }
        }
        private void LoadEditItemCategoryScreen()
        {
           // PushViewModel(new CreateOrEditItemTypeViewModel(ViewModelChanger, this, SelectedItem) { CurrentUser = CurrentUser });
        }

        //public void DeleteItem(bbListType itemType)
        //{
            //if (itemType != null && !itemType.IsDefault && ItemTypes.Count != 1)
            //{
            //    itemType.Delete();
            //    ItemTypes.Remove(itemType);
            //}
        //}

        //public void CreatedEditedItemType(bbListType itemType, bool wasCreated)
        //{
          //  if (itemType.IsDefault)
           // {
               // foreach (var type in ItemTypes)
               // {
               //     type.IsDefault = type.ID == itemType.ID;
               // }
           // }
         //   if (wasCreated)
         //   {
               //ItemTypes.Add(itemType);
         //   }
         //   RefreshCanDelete();
        //}

        private void RefreshCanDelete()
        {
            //CanDelete = SelectedItem != null ? !SelectedItem.IsDefault && ItemTypes.Count > 1 : false;
        }
    }
}
