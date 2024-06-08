using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class SettingMapperDTO
    {
        public static SettingDTO toDTO(Setting setting)
        {
            SettingDTO settingDTO = new SettingDTO();
            settingDTO.Nombre = setting.Nombre;
            settingDTO.Valor = setting.Valor;

            return settingDTO;
        }

        public static Setting fromDTO(SettingDTO settingDTO)
        {
            if (settingDTO == null) throw new Exception();
            Setting setting = new Setting();
            setting.Nombre = settingDTO.Nombre;
            setting.Valor = settingDTO.Valor;
            return setting;
        }
    }
}
