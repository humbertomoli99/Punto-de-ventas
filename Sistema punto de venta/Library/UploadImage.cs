using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Sistema_punto_de_venta.Library
{
    public class UploadImage
    {
        private BitmapImage _bitmapImage;
        private byte[] avatar;
        public async Task<object[]> loadImageAsync()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".webp");// esta talvez no
            _bitmapImage = new BitmapImage();
            StorageFile file = await picker.PickSingleFileAsync();
            if (file!=null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    _bitmapImage.SetSource(fileStream);
                }
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BinaryReader reader = new BinaryReader(fileStream.AsStream());
                    avatar = reader.ReadBytes((int)fileStream.Size);
                }
            }
            object[] objects = { avatar, _bitmapImage };
            return objects;
        }
    }
}
