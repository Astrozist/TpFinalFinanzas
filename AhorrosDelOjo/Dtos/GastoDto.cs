namespace FinanzasWeb.Dtos
{
    public class GastoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}