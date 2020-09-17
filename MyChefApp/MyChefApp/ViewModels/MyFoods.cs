using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyChefApp.ViewModels
{
    public class Protien : INotifyPropertyChanged
    {
        public string Title { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }

    public class Grain : INotifyPropertyChanged
    {
        public string Title { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }

    public class Veggie : INotifyPropertyChanged
    {
        public string Title { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }

    public class AllergieAndRestriction : INotifyPropertyChanged
    {
        public string Title { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
