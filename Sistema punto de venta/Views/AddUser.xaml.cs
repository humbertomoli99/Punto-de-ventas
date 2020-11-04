using Sistema_punto_de_venta.Library;
using Sistema_punto_de_venta.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sistema_punto_de_venta.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AddUser : Page
    {
        public AddUser()
        {
            this.InitializeComponent();
            Object[] campos = { NID, Name, LastName, Telephone, Email, Password, User };
            DataContext = new UserViewModel(campos);
        }

        private void NID_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBoxEvent.textPreviewKeyDown(e);
        }

        private void Name_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void LastName_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void Telephone_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
    }
}
