using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class VwPedidoxProductoxCliente
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int IdProducto { get; set; }
        public string DetalleProducto { get; set; }
        public int ValorProducto { get; set; }
        public int SubTotal { get; set; }
        public int PrecioTotal { get; set; }
    }
}
