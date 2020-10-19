using System;
using System.Collections.Generic;

namespace MyChefAppModels
{
    public partial class Goals
    {
        public long GoalId { get; set; }
        public long UserId { get; set; }
        public string GoalText { get; set; }
        public bool GoalCompleted { get; set; }
    }
}
