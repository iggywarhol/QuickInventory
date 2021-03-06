using System.Windows;
using System.Windows.Controls;
//
using SimpleInventory.Models;
using SimpleInventory.ViewModels;
//
namespace SimpleInventory.Views
{
    /// <summary>
    /// Interaction logic for ManageItems.xaml
    /// </summary>
    public partial class ManageItems : UserControl
    {
        public ManageItems()
        {
            InitializeComponent();
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Inventory Item", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                (DataContext as ManageItemsViewModel)?.DeleteItem(ItemsGrid.SelectedValue as bbBaseGroup);
            }
        }
    }
}
