namespace GameShopWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        //  We assign a default value for this property as current date and time
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
