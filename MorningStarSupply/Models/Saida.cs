using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MorningStarSupply.Models
{
    public class Saida
    {
        [Key]
        public int Id { get; set; } 
        [Display(Name = "Número de Registro")]
        public int MercadoriaRegistro { get; set; }

        [Required]
        [Display(Name = "Data")]
        
        public DateTime DataHora { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

     

    }
}
