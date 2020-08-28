using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class Protien
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }

        ObservableCollection<Protien> protiens;

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

    public class Grain
    {
        public string Title { get; set; }

        public ObservableCollection<Grain> grains;

        public ObservableCollection<Grain> GetGrain()
        {
            grains = new ObservableCollection<Grain>()
            {
                new Grain()
                {
                    Title = "Rice"
                },
                new Grain()
                {
                    Title = "Corn"
                },
                new Grain()
                {
                    Title = "Pasta"
                },
                new Grain()
                {
                    Title = "Quinoa"
                },
                new Grain()
                {
                    Title = "Couscous"
                },
                new Grain()
                {
                    Title = "Beans"
                },
                new Grain()
                {
                    Title = "Lentile"
                },
                new Grain()
                {
                    Title = "Peas"
                }
            };

            return grains;
        }
    }

    public class Veggie
    {
        public string Title { get; set; }

        public ObservableCollection<Veggie> veggies;

        public ObservableCollection<Veggie> GetVeggie()
        {
            veggies = new ObservableCollection<Veggie>()
            {
                new Veggie()
                {
                    Title = "Asparagus"
                },
                new Veggie()
                {
                    Title = "Broccoli"
                },
                new Veggie()
                {
                    Title = "Cabbage"
                },
                new Veggie()
                {
                    Title = "Carrots"
                },
                new Veggie()
                {
                    Title = "Leafy Greens"
                },
                new Veggie()
                {
                    Title = "Mushrooms"
                },
                new Veggie()
                {
                    Title = "Onion"
                },
                new Veggie()
                {
                    Title = "Peppers"
                },
                new Veggie()
                {
                    Title = "Tomatoes"
                },
                new Veggie()
                {
                    Title = "Potato"
                },
                new Veggie()
                {
                    Title = "Yams"
                },
                new Veggie()
                {
                    Title = "Sweet Potato"
                },
                new Veggie()
                {
                    Title = "Squash"
                },
                new Veggie()
                {
                    Title = "Brussel"
                },
                new Veggie()
                {
                    Title = "Sprouts"
                },
                new Veggie()
                {
                    Title = "Celery"
                },
                new Veggie()
                {
                    Title = "Couliflower"
                },
                new Veggie()
                {
                    Title = "Green beans"
                },
                new Veggie()
                {
                    Title = "Cucumbers"
                },
                new Veggie()
                {
                    Title = "Garlic"
                }
            };

            return veggies;
        }
    }

    public class AllergieAndRestriction
    {
        public string Title { get; set; }

        public ObservableCollection<AllergieAndRestriction> allergiesAndRestrictions;

        public ObservableCollection<AllergieAndRestriction> GetAllergieAndRestrictions()
        {
            allergiesAndRestrictions = new ObservableCollection<AllergieAndRestriction>()
            {
                new AllergieAndRestriction()
                {
                    Title = "Peanuts"
                },
                new AllergieAndRestriction()
                {
                    Title = "Dairy"
                },
                new AllergieAndRestriction()
                {
                    Title = "Gluten"
                },
                new AllergieAndRestriction()
                {
                    Title = "Sugar"
                },
                new AllergieAndRestriction()
                {
                    Title = "Salt"
                },
                new AllergieAndRestriction()
                {
                    Title = "Spicy"
                },
                new AllergieAndRestriction()
                {
                    Title = "Soy"
                },
                new AllergieAndRestriction()
                {
                    Title = "Shellfish"
                },
                new AllergieAndRestriction()
                {
                    Title = "Tree Nuts"
                }
            };

            return allergiesAndRestrictions;
        }
    }
}
