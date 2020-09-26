using System.ComponentModel;

namespace MyChefApp.ViewModels
{
    public class FoodVM : INotifyPropertyChanged
    {
        public long FoodId { get; set; }
        public long FoodTypeId { get; set; }
        public string FoodName { get; set; }

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
