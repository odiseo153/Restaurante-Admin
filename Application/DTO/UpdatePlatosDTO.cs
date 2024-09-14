

namespace Application.DTO
{
    public class UpdatePlatosDTO
    {
        public Guid? Id { get; set; }
        public string Imagen { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
