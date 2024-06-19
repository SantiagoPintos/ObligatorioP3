using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioSettings:IRepositorio<Setting>
    {
        public Setting GetSettingByName(string nombre);

        public double GetSettingValueByName(string nombre);

        public double ObtenerPaginado();
    }
}
