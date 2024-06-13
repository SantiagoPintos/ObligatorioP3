using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Encargado
{
    public class ObtenerEncargadoPorEmailCU: IObtenerEncargadoPorEmail
    {
        private IRepositorioEncargado _repositorioEncargado;
        public ObtenerEncargadoPorEmailCU(IRepositorioEncargado repositorioEncargado)
        {
            this._repositorioEncargado = repositorioEncargado;
        }
        public EncargadoDTO ObtenerEncargadoPorEmail(string email)
        {
            return EncargadoDTOMapper.ToDTO(this._repositorioEncargado.FindByEmail(email));
        }
    }
}
