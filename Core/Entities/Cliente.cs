

namespace Core.Entities;

public partial class Cliente : BaseEntity
{

    public string Nombre { get; set; } = null!;

    public string? Correo { get; set; }

    public string? NumeroTelefono { get; set; }

    public int? PuntosFidelidad { get; set; } = 0;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
