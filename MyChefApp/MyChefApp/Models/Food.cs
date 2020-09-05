namespace MyChefApp.Models
{
    public class Food
    {
        public FoodTypeEnum FoodTypeEnumId { get; set; }
        public string Title { get; set; }
        public bool isSelected { get; set; }
    }
}
