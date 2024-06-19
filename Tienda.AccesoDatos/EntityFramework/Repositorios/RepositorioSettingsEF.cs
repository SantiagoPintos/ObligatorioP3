using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioSettingsEF : IRepositorioSettings
    {
        private TiendaContext _context;
        public RepositorioSettingsEF()
        {
            this._context = new TiendaContext();
        }

        public bool Add(Setting aAgregar)
        {
            try
            {
                this._context.Settings.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Setting> FindAll()
        {
            return this._context.Settings;
        }

        public Setting FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Setting GetSettingByName(string nombre)
        {
            return this._context.Settings.Where(setting => setting.Nombre == nombre).FirstOrDefault();
        }

        public double GetSettingValueByName(string nombre)
        {
            return this._context.Settings.Where(setting => setting.Nombre == nombre).FirstOrDefault().Valor;
        }

        public double ObtenerPaginado()
        {
            return this._context.Settings.Where(setting => setting.Nombre == "PAGINADO").FirstOrDefault().Valor;
        }

        public bool Remove(Setting aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(Setting aModificar)
        {
            try
            {
                this._context.Settings.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
