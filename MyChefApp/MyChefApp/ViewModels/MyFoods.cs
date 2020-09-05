using MyChefApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyChefApp.ViewModels
{
    public class Protein : INotifyPropertyChanged
    {
        public FoodTypeEnum FoodTypeEnumId { get; set; }
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

        public FoodTypeEnum FoodTypeEnumId { get; set; }

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
        public FoodTypeEnum FoodTypeEnumId { get; set; }

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
        public object FoodTypeEnumId { get; set; }
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
