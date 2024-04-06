using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Usuario:IValidable<Usuario>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        //letra dice que se debe guardar una copia de la contraseña sin encriptar
        public string ClaveSinEncriptar { get; set; }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
