namespace MyChefAppModels
{
    public partial class Foods
    {
        public long FoodId { get; set; }
        public long FoodTypeId { get; set; }
        public string FoodName { get; set; }
        public bool IsSelected { get; set; }
    }
}
