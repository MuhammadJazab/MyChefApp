using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyChefAppViewModels
{
    public class GoalsVM : INotifyPropertyChanged
    {
        public long GoalId { get; set; }
        public long UserId { get; set; }
        public string GoalText { get; set; }
        private bool goalCompleted { get; set; }

        public bool GoalCompleted
        {
            get { return goalCompleted; }
            set
            {
                goalCompleted = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GoalCompleted"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
