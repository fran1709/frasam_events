namespace BZPAY_BE.DataAccess
{
    public class EventoDo
    {
        public int Id { get; set; }
        public int Disponible { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public bool Active { get; set; }
        public int IdTipoEvento { get; set; }
        public int IdEscenario { get; set; }
    }
}
