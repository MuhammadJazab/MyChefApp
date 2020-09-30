using System;
using System.Collections.Generic;

namespace MyChefAppModels
{
    public partial class Ingredients
    {
        public long IngredientId { get; set; }
        public long MenuRecipeId { get; set; }
        public string MenuIngredients { get; set; }
    }
}
