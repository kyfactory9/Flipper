using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFlipperDemo
{
    class MainWindowModel : INotifyPropertyChanged
    {
        private string temp;
        private string humi;

        public string Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                OnPropertyChanged("Temp");
            }
        }

        public string Humi
        {
            get { return humi; }
            set
            {
                humi = value;
                OnPropertyChanged("Humi");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
