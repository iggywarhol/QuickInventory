using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//
using Newtonsoft.Json;
//
using SimpleInventory.Helpers;
using SimpleInventory.Interfaces;
using SimpleInventory.Models;
//
namespace SimpleInventory.ViewModels
{
    class CreateOrEditItemTypeViewModel : BaseViewModel
    {
        private string _screenTitle;
        private string _name;
        private string _description;
        private int _manufacturerSelectedIndex = 0;
        private ObservableCollection<bb_Asset_List> _manufactureritems;
        private string _model;
        private int _categoryselectedindex = 0;
        private ObservableCollection<bb_Asset_List> _categorylist;
        private ICreatedEditedItemType _createdEditedItemType;
       // private bbListType _itemBeingEdited;
        //Groups groupM;
        //Groups groupC;
        List<bb_Asset_List> _itemsM;
        List<bb_Asset_List> _itemsC;
        SimpleInventoryContext db = new SimpleInventoryContext();
        public CreateOrEditItemTypeViewModel(IChangeViewModel viewModelChanger, ICreatedEditedItemType createdItemType) : base(viewModelChanger)
        {
            ScreenTitle = "Add Item Category";
           // _itemBeingEdited = null;
            _createdEditedItemType = createdItemType;
            //
            Name = "";
            Description = "";
            Model = "";
            //
            FillDropDowns();
        }
        private void FillDropDowns()
        {

            /*
            _manufacturerSelectedIndex = 0;
            groupM = db.Groups.ToList().Find(sh => sh.Key == "Manufacture");
            if (groupM != null)
            {
                _itemsM = JsonConvert.DeserializeObject<List<bbList>>(groupM.Value);
                _manufactureritems = new ObservableCollection<bbList>(_itemsM.ToList());
            }
            _categoryselectedindex = 0;
            groupC = db.Groups.ToList().Find(sh => sh.Key == "Category");
            if (groupC != null)
            {
                _itemsC = JsonConvert.DeserializeObject<List<bbList>>(groupC.Value);
                _categorylist = new ObservableCollection<bbList>(_itemsC.ToList());
            }
            */
        }
        
        /*
        public CreateOrEditItemTypeViewModel(IChangeViewModel viewModelChanger, ICreatedEditedItemType createdItemType, bbListType itemType) : base(viewModelChanger)
        {
            ScreenTitle = "Edit Item Category";
           // _itemBeingEdited = itemType;
            _createdEditedItemType = createdItemType;
            _name = itemType.Value;
            Description = itemType.Display;
            _model = itemType.Model;
            FillDropDowns();
            //_manufacturerSelectedIndex = _itemsM.FindIndex(m => m.Value == itemType.Manufacture);
            //_categoryselectedindex =  _itemsC.FindIndex(m => m.Value == itemType.Category); //"Latop"
        }
        */
        public string ScreenTitle
        {
            get { return _screenTitle; }
            set { _screenTitle = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(); }
        }
        public ObservableCollection<bb_Asset_List> ManufacturerList
        {
            get { return _manufactureritems; }
            set { _manufactureritems = value; NotifyPropertyChanged(); }
        }
        public int ManufacturerSelectedIndex
        {
            get { return _manufacturerSelectedIndex; }
            set { _manufacturerSelectedIndex = value; NotifyPropertyChanged(); }
        }
        public ObservableCollection<bb_Asset_List> CategoryList
        {
            get { return _categorylist; }
            set { _categorylist = value; NotifyPropertyChanged(); }
        }
        public int CategorySelectedIndex
        {
            get { return _categoryselectedindex; }
            set { _categoryselectedindex = value; NotifyPropertyChanged(); }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; NotifyPropertyChanged(); }
        }
        public ICommand ReturnToManageTypes
        {
            get { return new RelayCommand(PopScreen); }
        }
        private void PopScreen()
        {
            PopViewModel();
        }
        public ICommand SaveItemType
        {
            get { return new RelayCommand(SaveData); }
        }

        private void SaveData()
        {
            //bbListType itemType = _itemBeingEdited != null ? _itemBeingEdited : new bbListType();
            //itemType.Value = Name;
            //itemType.Display = Description;
            //itemType.Manufacture = ManufacturerList[_manufacturerSelectedIndex].Value;
            //itemType.Model = Model;
            //itemType.Category = CategoryList[_categoryselectedindex].Value;
            //if (_itemBeingEdited != null)
            //{
             //   db.ItemTypes.AddOrUpdate(itemType);
            //    db.SaveChanges();
            //}
            //else
            //{
              //  db.ItemTypes.Add(itemType);
            //    db.SaveChanges();
            //}
            //db?.CreatedEditedItemType(itemType, _itemBeingEdited == null);
            PopViewModel();
        }
    }
}
