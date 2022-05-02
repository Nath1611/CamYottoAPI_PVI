using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Maquinaria = new HashSet<Maquinarium>();
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
        }

        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Contrasenna { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Maquinarium> Maquinaria { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
