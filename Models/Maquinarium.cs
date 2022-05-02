using System;
using System.Collections.Generic;

namespace CamYottoAPI.Models
{
    public partial class Maquinarium
    {
        public int Idmaquinaria { get; set; }
        public string Nombre { get; set; }
        public string Funcion { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public string Detalle { get; set; }
        public int UsuarioIdusuario { get; set; }

        public virtual Usuario UsuarioIdusuarioNavigation { get; set; }
    }
}
