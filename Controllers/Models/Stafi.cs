using System.ComponentModel.DataAnnotations;

namespace E_PharmacyCrud.Controllers.Models
{
    public class Stafi
    {
        [Key]
        public int id { get; set; }
        public string stname { get; set; }
        public string pershkrimi { get; set; }
    }
}
