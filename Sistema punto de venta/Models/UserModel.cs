using Sales_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.UI.Xaml.Media.Imaging;

namespace Sistema_punto_de_venta.Models
{
    public class UserModel : PropertyChangedNotification
    {
        public int ID { get; set; }
        public string Email
        {
            get { return GetValue(() => Email); }
            set
            {
                SetValue(() => Email, value);
                EmailMessage = "";
                Message = "";
                UserTittle = "Registrar usuarios";
            }

        }
        public string Password
        {
            get { return GetValue(() => Password); }
            set
            {
                SetValue(() => Password, value);
                PasswordMessage = "";
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public string Message
        {
            get { return GetValue(() => Message); }
            set { SetValue(() => Message, value); UserTittle = "Registrar usuarios"; }
        }
        public BitmapImage Image
        {
            get { return GetValue(() => Image); }
            set { SetValue(() => Image, value); }
        }
        public string EmailMessage
        {
            get { return GetValue(() => EmailMessage); }
            set { SetValue(() => EmailMessage, value); UserTittle = "Registrar usuarios";}
        }
        public string PasswordMessage
        {
            get { return GetValue(() => PasswordMessage); }
            set { SetValue(() => PasswordMessage, value); UserTittle = "Registrar usuarios"; }
        }

        public string Nid
        {
            get { return GetValue(() => Nid); }
            set
            {
                SetValue(() => Nid, value);
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public string Name
        {
            get { return GetValue(() => Name); }
            set
            {
                SetValue(() => Name, value);
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public string LastName
        {
            get { return GetValue(() => LastName); }
            set
            {
                SetValue(() => LastName, value);
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public string Telephone
        {
            get { return GetValue(() => Telephone); }
            set
            {
                SetValue(() => Telephone, value);
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public string User
        {
            get { return GetValue(() => User); }
            set
            {
                SetValue(() => User, value);
                Message = "";
                UserTittle = "Registrar usuarios";
            }
        }
        public List<string> ListRoles //lista de roles de combobox
        {
            get
            {
                return new List<string>
                {
                    "Admin",
                    "User"
                };
            }
        }
        public string UserTittle
        {
            get { return GetValue(() => UserTittle); }
            set
            {
                if (UserTittle == null || UserTittle.Equals(""))
                {
                    SetValue(()  => UserTittle , "Registrar Usuarios");
                }
                else
                {
                    SetValue(() => UserTittle, value);
                }
            }
        }
        public string SelectedRole
        {
            get { return GetValue(() => SelectedRole); }
            set {
                SetValue(() => SelectedRole, value);
                UserTittle = "Registrar usuarios";
            }
        }
        public List<UserModel> ListUsers
        {
            get { return GetValue(() => ListUsers); }
            set { SetValue(() => ListUsers, value); }
        }
    }
}
