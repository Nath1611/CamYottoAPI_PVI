using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int Idproducto { get; set; }
        public int PrecioTotal { get; set; }
        public int SubTotal { get; set; }
        public int? Idcliente { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioIdusuario { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Usuario UsuarioIdusuarioNavigation { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
