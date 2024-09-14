using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Social : BaseEntity
    {
        public string Nombre { get; set; }
        public string Link { get; set; }
        public Guid RestaurantId { get; set; }

        public virtual Restaurants Restaurant { get; set; }

    }
}
