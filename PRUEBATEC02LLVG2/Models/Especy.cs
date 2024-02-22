using System;
using System.Collections.Generic;

namespace PRUEBATEC02LLVG2.Models
{
    public partial class Especy
    {
        public Especy()
        {
            Flores = new HashSet<Flore>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Flore> Flores { get; set; }
    }
}
