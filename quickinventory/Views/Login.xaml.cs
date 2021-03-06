using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net;
using System.IO;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Runtime.Serialization;
//
using Newtonsoft.Json;
//
using SimpleInventory.Models;
using SimpleInventory.ViewModels;
//
namespace SimpleInventory.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        SimpleInventoryContext db = new SimpleInventoryContext();
        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
        }
        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(UsernameInput);
            Loaded -= Login_Loaded;
        }
        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as LoginViewModel;
            if (dataContext != null)
            {
                dataContext.Password = PasswordInput.SecurePassword;
            }
        }
        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.Focus(PasswordInput);
            }
        }
        private void PasswordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var dataContext = DataContext as LoginViewModel;
                if (dataContext != null)
                {
                    dataContext.AttemptLogin.Execute(null);
                }
            }
        }
    }
}
