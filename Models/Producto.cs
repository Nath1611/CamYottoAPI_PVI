using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Producto
    {
        public int Valor { get; set; }
        public string Detalle { get; set; }
        public int Idproducto { get; set; }
        public int? IdtipoProdcto { get; set; }
        public int UsuarioIdusuario { get; set; }

        public virtual Pedido Idproducto1 { get; set; }
        public virtual Cama Idproducto2 { get; set; }
        public virtual Chaleco IdproductoNavigation { get; set; }
        public virtual Usuario UsuarioIdusuarioNavigation { get; set; }
    }
}
