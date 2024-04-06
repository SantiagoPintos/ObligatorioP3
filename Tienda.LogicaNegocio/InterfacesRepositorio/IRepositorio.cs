using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        bool Add(T aAgregar);
        bool Remove(int id);//También podría recibirse el objeto
        bool Update(T aModificar);
    }
}
