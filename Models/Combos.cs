using System.ComponentModel.DataAnnotations;

namespace SebastianSuarez_AP1_P2.Models
{
    public class Combos
    {
        [Key]
        public int ComboId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }  
        public int Vendido { get; set; }
    }
}
