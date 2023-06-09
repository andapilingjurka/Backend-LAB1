using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; } 
        public int price { get; set; }  
        public int quantity { get; set; }   
        public string ImgUrl { get; set; }
    }
}
