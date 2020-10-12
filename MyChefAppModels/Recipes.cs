namespace MyChefAppModels
{
    public partial class Recipes
    {
        public long MenuRecipeId { get; set; }
        public long MenuId { get; set; }
        public string MenuDay { get; set; }
        public string Directions { get; set; }
    }
}
