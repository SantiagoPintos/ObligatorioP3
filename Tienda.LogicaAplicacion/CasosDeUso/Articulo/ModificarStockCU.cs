using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ModificarStockCU:IModificarStock
    {
        private IRepositorioArticulo _repositorioArticulo;
        public ModificarStockCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void ModificarStock(LogicaNegocio.Entidades.Articulo articulo, int cantidadARestar)
        {
            if (cantidadARestar>articulo.stock)
            {
                throw new Exception("El stock no es suficiente");
            }
            articulo.stock = articulo.stock - cantidadARestar;
            _repositorioArticulo.Update(articulo);
        }
    }
}
