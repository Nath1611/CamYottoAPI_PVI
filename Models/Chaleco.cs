using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Chaleco
    {
        public decimal? Medidas { get; set; }
        public string Colores { get; set; }
        public string Talla { get; set; }
        public int? Idchaleco { get; set; }
        public int Column { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
