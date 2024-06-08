using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Settings;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Excepciones;
using Tienda.LogicaNegocio.Excepciones.Setting;

namespace Tienda.LogicaAplicacion.CasosDeUso.Settings
{
    public class ActualizarSettingCU : IActualizarSetting
    {
        private IRepositorioSettings _repositorioSettings;
        public ActualizarSettingCU(IRepositorioSettings repositorioSettings)
        {
            _repositorioSettings = repositorioSettings;
        }
        public void ActualizarSetting(string nombre, double valor)
        {
            Tienda.LogicaNegocio.Entidades.Setting setting = _repositorioSettings.GetSettingByName(nombre);
            if(setting != null) throw new SettingsException("El setting no existe");
            setting.Valor = valor;
            this._repositorioSettings.Update(setting);
        }
    }
}
