using System.Windows;
using System.Windows.Controls;
//
using SimpleInventory.ViewModels;
using SimpleInventory.Models;
//
namespace SimpleInventory.Views
{
    /// <summary>
    /// Interaction logic for CreateOrEditUser.xaml
    /// </summary>
    public partial class CreateOrEditUser : UserControl
    {
        SimpleInventoryContext simpleInventoryContext = new SimpleInventoryContext();
        public CreateOrEditUser()
        {
            InitializeComponent();
        }

        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as CreateOrEditUserViewModel;
            if (dataContext != null)
            {
                dataContext.Password = PasswordInput.SecurePassword;
            }
        }

        private void ConfirmPasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as CreateOrEditUserViewModel;
            if (dataContext != null)
            {
                dataContext.ConfirmPassword = ConfirmPasswordInput.SecurePassword;
            }
        }
    }
}
