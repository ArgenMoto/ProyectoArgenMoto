namespace Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ICollection<Venta> Ventas { get; set; }  // Relación con Venta
    }
}
