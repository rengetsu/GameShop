using System.ComponentModel.DataAnnotations;

namespace GameShopWeb.Models
{
    public class Category
    {
        /// <summary>
        /// We make Id a primary key an identity column
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// We make sure a Name is required property
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// We assign a default value for this property as current date and time
        /// </summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
