using Connection;
using LinqToDB;
using Sistema_punto_de_venta.Library;
using Sistema_punto_de_venta.Models;
using Sistema_punto_de_venta.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Sistema_punto_de_venta.ViewModels
{
    public class UserViewModel : UserModel
    {
        private Connections _conn;
        private BitmapImage _bitmapImage;
        private UploadImage _uploadImage;
        private TextBox _textBoxNid, _textBoxName, _textBoxLastName;
        private TextBox _textBoxTelephone, _textBoxUser, _textBoxEmail;
        private TextBox _textBoxPass;
        private string filename, fillPath;
        private byte[] avatar;

        public UserViewModel()
        {

        }
        public UserViewModel(object[] campos)
        {
            UserTittle = "Registrar usuarios";
            _textBoxNid = (TextBox)campos[0];
            _textBoxName = (TextBox)campos[1];
            _textBoxLastName = (TextBox)campos[2];
            _textBoxTelephone = (TextBox)campos[3];
            _textBoxEmail = (TextBox)campos[4];
            _textBoxPass = (TextBox)campos[5];
            _textBoxUser = (TextBox)campos[6];
            _uploadImage = new UploadImage();
            _conn = new Connections();
            _bitmapImage = new BitmapImage();
            ResetUsers();
        }
        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(() => App.mContentFrame.Navigate(typeof(AddUser)));
            }
        }
        public ICommand AddUser
        {
            get
            {
                return new CommandHandler(async () => await RegisterUserAsync());
            }
        }


        public ICommand loadImage
        {
            get
            {
                return new CommandHandler(async () =>
                {
                    object[] objects = await _uploadImage.loadImageAsync();
                    avatar = (byte[])objects[0];//va a la base de datos
                    if (avatar != null)
                    {
                        _bitmapImage = (BitmapImage)objects[1];
                        Image = _bitmapImage;
                    }
                    else
                    {
                        if (0 == _bitmapImage.PixelHeight)
                        {
                            _bitmapImage.UriSource = new Uri("ms-appx:///Assets/StorageLogo.scale-400.png");
                            avatar = await _uploadImage.ImagebyteAsync(_bitmapImage);
                            Image = _bitmapImage;
                        }
                    }
                });
            }
        }
        private async Task RegisterUserAsync()
        {
            if (Nid == null || Nid.Equals(""))
            {
                UserTittle = "Ingrese Nid";
                _textBoxNid.Focus(FocusState.Programmatic);
            }
            else
            {
                if(Name == null || Name.Equals(""))
                {
                    UserTittle = "Ingrese el nombre";
                    _textBoxName.Focus(FocusState.Programmatic);
                }
                else
                {
                    if (LastName == null || LastName.Equals(""))
                    {
                        UserTittle = "Ingrese el apellido";
                        _textBoxLastName.Focus(FocusState.Programmatic);
                    }
                    else
                    {
                        if (Telephone == null || Telephone.Equals(""))
                        {
                            UserTittle = "Ingrese el Numero de telefono";
                            _textBoxTelephone.Focus(FocusState.Programmatic);
                        }
                        else
                        {
                            if (Email == null || Email.Equals(""))
                            {
                                UserTittle = "Ingrese el email";
                                _textBoxEmail.Focus(FocusState.Programmatic);
                            }
                            else
                            {
                                if (TextBoxEvent.IsValidEmail(Email))
                                {
                                    if(Password == null || Password.Equals(""))
                                    {
                                        UserTittle = "Ingrese la contrseña";
                                        _textBoxPass.Focus(FocusState.Programmatic);
                                    }
                                    else
                                    {
                                        if (User == null || User.Equals(""))
                                        {
                                            UserTittle = "Ingrese el usuario";
                                            _textBoxUser.Focus(FocusState.Programmatic);
                                        }
                                        else
                                        {
                                            if(SelectedRole == null || SelectedRole.Equals(""))
                                            {
                                                UserTittle = "Seleccione un rol";
                                            }
                                            else
                                            {
                                                await SaveDataAsync();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    UserTittle = "el Email no es valido";
                                    _textBoxEmail.Focus(FocusState.Programmatic);
                                }
                            }
                        }
                    }
                }
            }
        }
        private async Task SaveDataAsync()
        {
            var user = _conn.TUsers.Where(u => u.Email.Equals(Email)).ToList();
            if (user.Count.Equals(0))
            {
                if(avatar == null)
                {
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/StorageLogo.scale-400.png");
                    avatar = await _uploadImage.ImagebyteAsync(_bitmapImage);
                }
                _conn.TUsers.Value(u => u.NID, Nid)
                    .Value(u => u.Name, Name)
                    .Value(u => u.LastName, LastName)
                    .Value(u => u.Telephone, Telephone)
                    .Value(u => u.Email, Email)
                    .Value(u => u.Password, Encrypt.EncryptData(Password, Email))
                    .Value(u => u.Users, User)
                    .Value(u => u.Role, SelectedRole)
                    .Value(u => u.Date, DateTime.Now.ToString("dd/MMM/yyy"))
                    .Value(u => u.Images, avatar)
                    .Insert();
                App.mContentFrame.Navigate(typeof(Usuarios));
            }
            else
            {
                UserTittle = "El email ya esta registrado";
                _textBoxEmail.Focus(FocusState.Programmatic);
            }
        }
        private void ResetUsers()
        {
            _bitmapImage.UriSource = new Uri("ms-appx:///Assets/StorageLogo.scale-400.png");
            Image = _bitmapImage;
            _bitmapImage = new BitmapImage();
        }
    }
}
