using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Kontakti
    {

            [Key]
            public int id { get; set; }

            public String name { get; set; }

            public String email { get; set; }

            public String message { get; set; }

        }
    }

