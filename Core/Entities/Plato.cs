
namespace Core.Entities;


public partial class Plato : BaseEntity
{

    public Guid? RestauranteId { get; set; }
    public Guid? TipoId { get; set; }

    public string Imagen { get; set; }
    public bool Estado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }


    public decimal Precio { get; set; }

    public TiposPlato Tipo { get; set; }
    public virtual Restaurants? Restaurante { get; set; }
}
