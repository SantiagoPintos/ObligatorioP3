using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.Excepciones;
using Tienda.LogicaNegocio.Excepciones.Setting;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Setting:IValidable<Setting>
    {
        [Key]
        public string Nombre { get; set; }
        public double Valor { get; set; }

        public void EsValido()
        {
            if(String.IsNullOrEmpty(Nombre)) throw new SettingsException("El nombre del setting no es válido");
            //Preguntar por ese valor, puede ser positivo en caso de que se quiera hacer un descuento(?)
            if(Valor < 0) throw new SettingsException("El valor del setting no es válido");
        }
    }
}
