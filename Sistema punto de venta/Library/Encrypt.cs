using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sistema_punto_de_venta.Library
{
    public class Encrypt
    {
        private static RijndaelManaged rm = new RijndaelManaged();
        public Encrypt()
        {
            // establece el modo para el funcionamiento del algoritmo
            rm.Mode = CipherMode.CBC;
            // establece el metodo de relleno utilizando el algoritmo.
            rm.Padding = PaddingMode.PKCS7;
            // establece el tamaño en bits , para la clave secreta
            rm.KeySize = 0x80;
            // establece el tamaño del bloque en bits para la operacion criptografica.
            rm.BlockSize = 0x80;
        }
        public static string EncryptData(string textData, string Encryptionkey)
        {
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] EncryptionKeyBytes = new byte[] {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
            
            int len = passBytes.Length;
            if (len > EncryptionKeyBytes.Length)
            {
                len = EncryptionKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionKeyBytes, len);
            rm.Key = EncryptionKeyBytes;
            rm.IV = EncryptionKeyBytes;
            //crea un objeto aes asimetrico con la clave actual y el vector de inicializacion iv
            ICryptoTransform objtransform = rm.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);

            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0,
                textDataByte.Length));
        }
        public static string DecryptData(string EncryptedText,string Encryptionkey)
        {
            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);

            byte[] EncryptionKeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionKeyBytes.Length)
            {
                len = EncryptionKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionKeyBytes, len);
            rm.Key = EncryptionKeyBytes;
            rm.IV = EncryptionKeyBytes;
            byte[] TextByte = rm.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0,
                encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);
        }
    }
}
