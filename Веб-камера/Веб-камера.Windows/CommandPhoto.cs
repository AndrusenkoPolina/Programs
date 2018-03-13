using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Capture;
using Windows.UI.Xaml.Media.Imaging;

namespace Веб_камера
{
    public class CommandPhoto : ICommand
    {


        public async void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            var ui = new CameraCaptureUI();
            //Пропорции фотографии
            ui.PhotoSettings.CroppedAspectRatio = new Windows.Foundation.Size(16, 9);

            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null)
            {
                var bitmap = new BitmapImage();
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                bitmap.SetSource(stream);
                vm.ImageSource = bitmap;

            }
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

    }
   }

