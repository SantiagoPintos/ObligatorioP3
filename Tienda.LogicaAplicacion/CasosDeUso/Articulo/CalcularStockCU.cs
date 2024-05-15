using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class CalcularStockCU : ICalcularStock
    {
        private IRepositorioArticulo _repositorioArticulo;
        public CalcularStockCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public void CalcularStock(ArticuloDTO articulo, int cantidad)
        {
            if (cantidad > articulo.stock)
            {
                throw new Exception("No hay suficiente stock");
            }
        }
    }
}
