using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace Sistema_punto_de_venta.Library
{
    public static class TextBoxEvent
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public static void textPreviewKeyDown(KeyRoutedEventArgs e)
        {
            var code = e.KeyStatus;
        }
    }
}
