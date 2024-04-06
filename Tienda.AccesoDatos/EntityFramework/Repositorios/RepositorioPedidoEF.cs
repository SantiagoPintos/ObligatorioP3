using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoEF:IRepositorioPedido
    {
        private TiendaContext _context;
        public RepositorioPedidoEF()
        {
            this._context = new TiendaContext();
        }

        public bool Add(Pedido aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pedido FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pedido aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
