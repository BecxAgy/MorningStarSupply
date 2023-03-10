using Microsoft.EntityFrameworkCore;
using MorningStarSupply.Context;
using System.ComponentModel.DataAnnotations;

namespace MorningStarSupply.Models
{
    public class Mercadoria
    {
        [Key]
        [Display(Name = "Id")]
        public  int Id { get; set; }

        [Required(ErrorMessage ="O campo N° Registro é necessário!")]
        [Display(Name ="N° Registro")]
        public int NumeroRegistro { get; set; }

        [Required(ErrorMessage = "O campo Nome necessário!")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage="O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Fabricante é necessário!")]
        [Display(Name = "Fabricante")]
        [StringLength(100, ErrorMessage = "O campo Fabricante deve ter no máximo 100 caracteres.")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "O campo Descrição é necessário!")]
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "O campo Descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; set; }

        
    }
}
