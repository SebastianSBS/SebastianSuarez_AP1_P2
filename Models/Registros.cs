namespace SebastianSuarez_AP1_P2.Models
{
    public class Registros
    {
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public int DeudorId { get; set; }
        public string Concepto { get; set; }
        public int? Monto { get; set; }
    }
}
