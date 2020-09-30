using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefAppViewModels
{
    public class IngredientsVM
    {
        public long IngredientId { get; set; }
        public long MenuRecipeId { get; set; }
        public string MenuIngredients { get; set; }
    }
}
