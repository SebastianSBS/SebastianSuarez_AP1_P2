using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SebastianSuarez_AP1_P2.Models
{
    public class CombosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int ComboId { get; set; }

        [ForeignKey("ComboId")]
        public Combos? Combos { get; set; }

        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulos? Articulos { get; set; }

        public int Cantidad { get; set; }

        public int Costo { get; set; }
    }
}
