namespace Core.Entities;


public partial class TiposPlato : BaseEntity
{
    public string Nombre { get; set; } = null!;
    public virtual ICollection<Plato> Plato { get; set; } = new List<Plato>();

}





