using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso
{
    public class CreateArticuloCU : ICreateArticuloCU
    {
        private IRepositorioArticulo _repositorioArticulo;

        public CreateArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            this._repositorioArticulo = repositorioArticulo;
        }
        public void CreateArticulo(Articulo articulo)
        {
            try
            {
                articulo.EsValido();
                _repositorioArticulo.Add(articulo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el articulo");
            }
        }
    }
}
