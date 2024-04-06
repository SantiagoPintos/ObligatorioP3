using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Articulo:IValidable<Articulo>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int stock { get; set; }
        public string PrecioUnitario { get; set; }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
