using MorningStarSupply.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorningStarSupply.Models
{
    public class Entrada
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo N° Registro é necessário!")]
        [Display(Name = "N° de Registro")]
        public int MercadoriaRegistro{ get; set; }

        [Required(ErrorMessage = "O campo Data é necessário!")]
        [Display(Name = "Data")]
       
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é necessário!")]
        [Range(0,99999, ErrorMessage ="O valor deve estar entre 0 e 99999")]
        [Display(Name ="Quantidade")]
        public int Quantidade { get; set; }

   
     

  

    }
}
