using System.ComponentModel.DataAnnotations;

namespace SebastianSuarez_AP1_P2.Models
{
    public class CombosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ComboId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int Costo { get; set; }
    }
}
