using System.Collections.Generic;

namespace MyChefAppViewModels
{
    public class RecipeVM
    {
        public long MenuRecipeId { get; set; }
        public long MenuId { get; set; }
        public string MenuDay { get; set; }
        public string Directions { get; set; }
        public string MenuTitle { get; set; }
        public List<IngredientsVM> RecipeIngredients { get; set; }
    }
}
