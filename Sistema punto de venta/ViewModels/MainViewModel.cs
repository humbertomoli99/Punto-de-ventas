using Connection;
using Models;
using Sistema_punto_de_venta.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sistema_punto_de_venta.ViewModels
{
    public class MainViewModel
    {
        private SQLiteConnections _sqlite;
        public MainViewModel()
        {
            _sqlite = new SQLiteConnections();
        }
        public void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args, Frame contentFrame)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "Close":
                    _sqlite.Connection.DeleteAll<TUsers>();
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Login));
                    break;
                default:

                    break;

            }
        }
    }
}
