using MorningStarSupply.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorningStarSupply.Models
{
    public class Entrada
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Número de Registro")]
        [Required]
        public int MercadoriaRegistro{ get; set; }

        [Required]
        [Display(Name = "Data")]
       
        public DateTime DataHora { get; set; }

        [Required]
        [Display(Name ="Quantidade")]
        public int Quantidade { get; set; }

   
     

  

    }
}
