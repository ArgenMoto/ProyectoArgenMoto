namespace Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public ICollection<Venta> Ventas { get; set; }  // Relación con Venta
    }
}
