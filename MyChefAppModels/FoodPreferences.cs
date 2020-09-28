namespace MyChefAppModels
{
    public partial class FoodPreferences
    {
        public long FoodPreferenceId { get; set; }
        public long UserId { get; set; }
        public long FoodId { get; set; }
    }
}
