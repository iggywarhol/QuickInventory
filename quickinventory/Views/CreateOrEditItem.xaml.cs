using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleInventory.Models;
//
namespace SimpleInventory.Views
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class CreateOrEditItem : UserControl
    {
        SimpleInventoryContext db = new SimpleInventoryContext();

        public CreateOrEditItem()
        {
            InitializeComponent();
            Loaded += CreateOrEditItem_Loaded;
            //scotttest.ItemsSource = db.ItemTypes.ToList();
            //UsersGrid.ItemsSource = simpleInventoryContext.Users.ToList();
        }

        private void CreateOrEditItem_Loaded(object sender, RoutedEventArgs e)
        {
            //Keyboard.Focus(NameTextBox);
            Loaded -= CreateOrEditItem_Loaded;
        }
    }
}
