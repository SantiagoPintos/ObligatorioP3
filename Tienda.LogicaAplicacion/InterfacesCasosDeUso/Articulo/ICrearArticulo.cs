using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo
{
    public interface ICrearArticulo
    {
        public void CrearArticulo(ArticuloDTO aCrear);

    }
}
