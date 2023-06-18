namespace BZPAY_BE.DataAccess
{
    public class DetalleEntradaDo
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string TipoAsiento { get; set; }
        public int Disponibles { get; set; }
        public decimal Precio { get; set; }
    }
}
