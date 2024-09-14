namespace Core.Entities;

public partial class Pedido : BaseEntity
{

    public Guid? RestauranteId { get; set; }

    public Guid? ClienteId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal? MontoTotal { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Restaurants? Restaurante { get; set; }
}





