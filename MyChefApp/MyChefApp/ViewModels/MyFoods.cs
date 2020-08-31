using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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


        ObservableCollection<Protien> protiens;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Protien> GetProtiens()
        {
            protiens = new ObservableCollection<Protien>()
            {
                new Protien()
                {
                    Title = "Beef",
                    IsSelected = false
                },
                new Protien()
                {
                    Title = "Chicken",
                    IsSelected = false
                },
                new Protien()
                {
                    Title = "Fish",
                    IsSelected = false
                },
                new Protien()
                {
                    Title = "Shellfish",
                    IsSelected = false
                },
                new Protien()
                {
                    Title = "Turkey",
                    IsSelected = false
                },
                new Protien()
                {
                    Title = "Pork",
                    IsSelected = false
                }
            };

            return protiens;
        }
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


        public ObservableCollection<Grain> grains;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Grain> GetGrain()
        {
            grains = new ObservableCollection<Grain>()
            {
                new Grain()
                {
                    Title = "Rice",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Corn",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Pasta",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Quinoa",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Couscous",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Beans",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Lentile",
                    IsSelected = false
                },
                new Grain()
                {
                    Title = "Peas",
                    IsSelected = false
                }
            };

            return grains;
        }
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

        public ObservableCollection<Veggie> veggies;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Veggie> GetVeggie()
        {
            veggies = new ObservableCollection<Veggie>()
            {
                new Veggie()
                {
                    Title = "Asparagus",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Broccoli",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Cabbage",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Carrots",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Leafy Greens",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Mushrooms",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Onion",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Peppers",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Tomatoes",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Potato",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Yams",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Sweet Potato",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Squash",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Brussel",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Sprouts",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Celery",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Couliflower",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Green beans",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Cucumbers",
                    IsSelected = false
                },
                new Veggie()
                {
                    Title = "Garlic",
                    IsSelected = false
                }
            };

            return veggies;
        }
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

        public ObservableCollection<AllergieAndRestriction> allergiesAndRestrictions;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<AllergieAndRestriction> GetAllergieAndRestrictions()
        {
            allergiesAndRestrictions = new ObservableCollection<AllergieAndRestriction>()
            {
                new AllergieAndRestriction()
                {
                    Title = "Peanuts",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Dairy",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Gluten",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Sugar",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Salt",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Spicy",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Soy",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Shellfish",
                    IsSelected = false
                },
                new AllergieAndRestriction()
                {
                    Title = "Tree Nuts",
                    IsSelected = false
                }
            };

            return allergiesAndRestrictions;
        }
    }
}
