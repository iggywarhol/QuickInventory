using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Input;
//
using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
//
namespace SimpleInventory.ViewModels
{
    class CreateOrEditItemViewModel : BaseViewModel
    {
        private bool _isCreating;
        private long _inventoryItemID;
        private string _screenTitle;
        private string _assetID;
        private int _selecteditemcatindex;
        private bbBaseGroup _currentItemBeingEdited;
      //  private ObservableCollection<bbListType> _itemtypes;
        SimpleInventoryContext db = new SimpleInventoryContext();
        public CreateOrEditItemViewModel(IChangeViewModel viewModelChanger, ICreatedInventoryItem createdItemListener) : base(viewModelChanger)
        {
            _isCreating = true;
          //  _itemtypes = new ObservableCollection<bbListType>(db.ItemTypes.ToList());
            _currentItemBeingEdited = null;
            _assetID = "";
            ScreenTitle = "Add Item";
            //
            _inventoryItemID = 0;
            // Visibility = "{Binding IsCreating, Converter={StaticResource BooleanToVisibilityConverter}}
        }
        public CreateOrEditItemViewModel(IChangeViewModel viewModelChanger, bbBaseGroup item) : base(viewModelChanger)
        {
            _isCreating = false;
           // _itemtypes = new ObservableCollection<bbListType>(db.ItemTypes.ToList());
            _currentItemBeingEdited = item;
            //_assetID = item.AssetID;
            //_selecteditemcatindex = db.ItemTypes.ToList().FindIndex(m => m.Category == item.ItemType.Category); 
            ScreenTitle = "Edit Item";
            //
            _inventoryItemID = item.ID;
        }
        #region Properties
       // public ObservableCollection<bbListType> ItemTypes
       // {
       //     get { return _itemtypes; }
       //     set { _itemtypes = value; NotifyPropertyChanged(); }
       // }
        public int SelectedCatIndex
        {
            get { return _selecteditemcatindex; }
            set { _selecteditemcatindex = value; NotifyPropertyChanged(); }
        }
        public string AssetID
        {
            get { return _assetID; }
            set { _assetID = value; NotifyPropertyChanged(); }
        }
        public string ScreenTitle
        {
            get { return _screenTitle; }
            set { _screenTitle = value; }
        }
        public bool IsCreating
        {
            get { return _isCreating; }
            set { _isCreating = value; NotifyPropertyChanged(); }
        }
        #endregion
        #region ICommands
        public ICommand PopBack
        {
            get { return new RelayCommand(PopToMainMenu); }
        }
        private void PopToMainMenu()
        {
            PopViewModel();
        }
        public ICommand SaveItem
        {
            get { return new RelayCommand(CreateOrSaveItem); }
        }

        #endregion
        private void CreateOrSaveItem()
        {
            var item = _currentItemBeingEdited != null ? _currentItemBeingEdited : new bbBaseGroup();
            //bool didValidate = true;
            //string errorMessage = "";
            //if (didValidate)
            //{
            if (_isCreating)
            {
                item.ID = _inventoryItemID;
                //item.AssetID = _assetID;
                //item.ItemType_ID = db.ItemTypes.ToList()[SelectedCatIndex].ID;
                //db.Items.Add(item);
                //db.SaveChanges();
            }
            else
            {
                item.ID = _inventoryItemID;
                //item.AssetID = _assetID;
                //item.ItemType_ID = db.ItemTypes.ToList()[SelectedCatIndex].ID; 
                //db.Items.AddOrUpdate(item);
                //db.SaveChanges();
            }
            PopViewModel();
            //}
            //else if (!string.IsNullOrWhiteSpace(errorMessage))
            //{
            //    MessageBox.Show(errorMessage, "Error!", MessageBoxButton.OK);
            //}
        }
    }
}
