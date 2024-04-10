using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICreateArticuloCU
    {
        public void CreateArticulo(Articulo articulo);
    }
}
