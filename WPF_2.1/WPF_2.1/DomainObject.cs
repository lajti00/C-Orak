using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_2._1
{
    public class DomainObject : INotifyPropertyChanged
    {
        public RelayCommand ChangeMyVisiblity { get; set; }
        public DomainObject()
        {
            this.ChangeMyVisiblity = new RelayCommand(() => ChangeAction(), null);
        }

        private void ChangeAction()
        {
            this.MyTextVisible = !this.MyTextVisible;
            //TODO: Http kérés
            this.MyData.Add("Akos4");
        }

        private ObservableCollection<string> myData = new ObservableCollection<string> { "Akos1", "Akos2", "Akos3" };
        public ObservableCollection<string> MyData
        {
            get { return myData; }
            set
            {
                if (value != myData)
                {
                    myData = value;
                    OnPropertyChanged(nameof(MyData));
                }
            }
        }

        public string MyText { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private bool myTextVisible;
        public bool MyTextVisible
        {
            get { return myTextVisible; }
            set
            {
                if (myTextVisible != value)
                {
                    myTextVisible = value;
                    //PropertyChanged(this, new PropertyChangedEventArgs("MyTextVisible"));
                    OnPropertyChanged(nameof(MyTextVisible));
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
