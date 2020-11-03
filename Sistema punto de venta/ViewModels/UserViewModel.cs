using Sistema_punto_de_venta.Library;
using Sistema_punto_de_venta.Models;
using Sistema_punto_de_venta.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sistema_punto_de_venta.ViewModels
{
    public class UserViewModel : UserModel
    {
        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(() => App.mContentFrame.Navigate(typeof(AddUser)));
            }
        }
    }
}
