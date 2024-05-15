using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo
{
    public interface IModificarStock
    {
        public void ModificarStock(Tienda.LogicaNegocio.Entidades.Articulo articulo, int cantidadARestar);
    }
}

