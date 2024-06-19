using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Settings;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Settings
{
    public class ObtenerPaginadoCU : IObtenerPaginado
    {
        private IRepositorioSettings _repositorioSettings;
        public ObtenerPaginadoCU(IRepositorioSettings repositorioSettings)
        {
            _repositorioSettings = repositorioSettings;
        }
        public double obtenerPaginado()
        {
            return _repositorioSettings.ObtenerPaginado();
        }
    }
}
