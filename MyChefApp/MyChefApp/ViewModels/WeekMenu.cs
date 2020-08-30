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

        ObservableCollection<WeekMenu> menus;

        public ObservableCollection<WeekMenu> GetMenu()
        {
            menus = new ObservableCollection<WeekMenu>()
            {
                new WeekMenu()
                {
                    Day = "Monday",
                    Title = "Menu 1"
                },
                new WeekMenu()
                {
                    Day = "Tuesday",
                    Title = "Menu 2"
                },
                new WeekMenu()
                {
                    Day = "Wednesday",
                    Title = "Menu 3"
                },
                new WeekMenu()
                {
                    Day = "Thursday",
                    Title = "Menu 4"
                },
                new WeekMenu()
                {
                    Day = "Friday",
                    Title = "Menu 5"
                },
                new WeekMenu()
                {
                    Day = "Saturday",
                    Title = "Menu 6"
                },
                new WeekMenu()
                {
                    Day = "Sunday",
                    Title = "Menu 7"
                }
            };

            return menus;
        }
    }
}
