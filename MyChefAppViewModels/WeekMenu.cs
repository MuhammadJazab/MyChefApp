using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyChefApp.ViewModels
{
    public class WeekMenu
    {
        public string Day { get; set; }
        public string Title { get; set; }
        public bool IsEven { get; set; }

        ObservableCollection<WeekMenu> menus;

        public ObservableCollection<WeekMenu> GetMenu()
        {
            menus = new ObservableCollection<WeekMenu>()
            {
                new WeekMenu()
                {
                    Day = "Monday",
                    Title = "Menu 1",
                    IsEven = false
                },
                new WeekMenu()
                {
                    Day = "Tuesday",
                    Title = "Menu 2",
                    IsEven = true
                },
                new WeekMenu()
                {
                    Day = "Wednesday",
                    Title = "Menu 3",
                    IsEven = false
                },
                new WeekMenu()
                {
                    Day = "Thursday",
                    Title = "Menu 4",
                    IsEven = true
                },
                new WeekMenu()
                {
                    Day = "Friday",
                    Title = "Menu 5",
                    IsEven = false
                }
            };

            return menus;
        }
    }
}
