using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace validationapp
{
    public class ViewModelBase : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

       
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
