

namespace Core.Entities;


public partial class Restaurants : BaseEntity
{
    public string Nombre { get; set; } = null!;
    
    public string? NumeroTelefono { get; set; }

    public string Correo { get; set; }
    public string clave { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    public virtual ICollection<Social> Redes { get; set; } = new List<Social>();

    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
