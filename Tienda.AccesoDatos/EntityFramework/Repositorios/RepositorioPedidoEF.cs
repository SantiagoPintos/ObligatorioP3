using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
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
            try
            {
                aAgregar.EsValido();                
                this._context.Entry(aAgregar.Cliente).State = EntityState.Unchanged;
                this._context.Set<Pedido>().Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            
            
        }

        public IEnumerable<Pedido> FindAll()
        {
            return this._context.Pedidos;
        }

        public Pedido FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Pedido aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pedido aModificar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindByMonto(decimal monto)
        {
            return this._context.Pedidos.Where(p => p.PrecioTotal > monto).Select(p => p.Cliente);
        }
    }
}
