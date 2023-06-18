namespace BZPAY_BE.Models.Entities
{
    public class DetalleEntrada
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string TipoAsiento { get; set; }
        public int Disponibles { get; set; }
        public decimal Precio { get; set; }
    }
}
