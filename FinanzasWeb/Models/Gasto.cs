using System.ComponentModel.DataAnnotations;

namespace FinanzasWeb.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100)]
        public string Descripcion { get; set; } = null!; 

        [Required]
        [Range(0.01, 99999999, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Monto { get; set; } 

        public DateTime Fecha { get; set; } = DateTime.Now; 
    }
}