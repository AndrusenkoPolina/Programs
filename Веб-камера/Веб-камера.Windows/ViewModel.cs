using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Веб_камера
{
  public class ViewModel: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void DoPropertyChanged(String name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
            public ICommand DoPhoto { get; set; }
            private object imageSource { get; set; }

            public object ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                DoPropertyChanged("ImageSource");
            }
               
        }


        public ViewModel()
        {
            DoPhoto = new CommandPhoto();
        }
    }
    
    }

