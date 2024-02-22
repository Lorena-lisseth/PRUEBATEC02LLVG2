﻿using System;
using System.Collections.Generic;

namespace PRUEBATEC02LLVG2.Models
{
    public partial class Flore
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int? TipoId { get; set; }

        public virtual Especy? Tipo { get; set; }
    }
}
