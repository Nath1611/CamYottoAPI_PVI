using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Cama
    {
        public string Medidas { get; set; }
        public string DetallePers { get; set; }
        public string Colores { get; set; }
        public int Idcama { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
