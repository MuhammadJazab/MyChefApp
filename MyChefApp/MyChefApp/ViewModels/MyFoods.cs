using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class Protien
    {
        public string Title { get; set; }

        public Protien()
        {
            ObservableCollection<Protien> Protiens = new ObservableCollection<Protien>
            {
                new Protien
                {
                    Title = "Beef"
                },
                new Protien
                {
                    Title = "Chicken"
                },
                new Protien
                {
                    Title = "Fish"
                },
                new Protien
                {
                    Title = "Shellfish"
                },
                new Protien
                {
                    Title = "Turkey"
                },
                new Protien
                {
                    Title = "Pork"
                }
            };
        }
    }

    public class Grain
    {
        public string Title { get; set; }

        public Grain()
        {
            ObservableCollection<Grain> Grains = new ObservableCollection<Grain>
            {
                new Grain
                {
                    Title = "Rice"
                },
                new Grain
                {
                    Title = "Corn"
                },
                new Grain
                {
                    Title = "Pasta"
                },
                new Grain
                {
                    Title = "Quinoa"
                },
                new Grain
                {
                    Title = "Couscous"
                },
                new Grain
                {
                    Title = "Beans"
                },
                new Grain
                {
                    Title = "Lentile"
                },
                new Grain
                {
                    Title = "Peas"
                }
            };
        }
    }

    public class Veggie
    {
        public string Title { get; set; }

        public Veggie()
        {
            ObservableCollection<Veggie> veggies = new ObservableCollection<Veggie>
            {
                new Veggie
                {
                    Title = "Asparagus"
                },
                new Veggie
                {
                    Title = "Broccoli"
                },
                new Veggie
                {
                    Title = "Cabbage"
                },
                new Veggie
                {
                    Title = "Carrots"
                },
                new Veggie
                {
                    Title = "Leafy Greens"
                },
                new Veggie
                {
                    Title = "Mushrooms"
                },
                new Veggie
                {
                    Title = "Onion"
                },
                new Veggie
                {
                    Title = "Peppers"
                },
                new Veggie
                {
                    Title = "Tomatoes"
                },
                new Veggie
                {
                    Title = "Potato"
                },
                new Veggie
                {
                    Title = "Yams"
                },
                new Veggie
                {
                    Title = "Sweet Potato"
                },
                new Veggie
                {
                    Title = "Squash"
                },
                new Veggie
                {
                    Title = "Brussel"
                },
                new Veggie
                {
                    Title = "Sprouts"
                },
                new Veggie
                {
                    Title = "Celery"
                },
                new Veggie
                {
                    Title = "Couliflower"
                },
                new Veggie
                {
                    Title = "Green beans"
                },
                new Veggie
                {
                    Title = "Cucumbers"
                },
                new Veggie
                {
                    Title = "Garlic"
                }
            };
        }
    }

    public class AllergieAndRestriction
    {
        public string Title { get; set; }

        public AllergieAndRestriction()
        {
            ObservableCollection<AllergieAndRestriction> allergiesAndRestrictions = new ObservableCollection<AllergieAndRestriction> 
            {
                new AllergieAndRestriction
                {
                    Title = "Peanuts"
                },
                new AllergieAndRestriction
                {
                    Title = "Dairy"
                },
                new AllergieAndRestriction
                {
                    Title = "Gluten"
                },
                new AllergieAndRestriction
                {
                    Title = "Sugar"
                },
                new AllergieAndRestriction
                {
                    Title = "Salt"
                },
                new AllergieAndRestriction
                {
                    Title = "Spicy"
                },
                new AllergieAndRestriction
                {
                    Title = "Soy"
                },
                new AllergieAndRestriction
                {
                    Title = "Shellfish"
                },
                new AllergieAndRestriction
                {
                    Title = "Tree Nuts"
                }
            };
        }
    }
}
