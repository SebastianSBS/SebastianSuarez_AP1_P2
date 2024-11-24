using System.ComponentModel.DataAnnotations;

namespace SebastianSuarez_AP1_P2.Models
{
    public class Combos
    {
        [Key]
        public int ComboId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Descripcion")]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int Precio { get; set; }

        public bool Vendido { get; set; }

        public ICollection<CombosDetalle> ComboDetalle { get; set; } = new List<CombosDetalle>();
    }
}
