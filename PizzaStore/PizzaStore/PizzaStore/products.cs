

using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Models

{
    public class products
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemIngredients { get; set; }
        public int ItemPrice { get; set; }
        public string itemImage { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
