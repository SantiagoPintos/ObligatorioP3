using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        public bool ExisteUsuario(string email);

        public Usuario EncontrarPorEmail(string email);

        public bool ClaveCoincide(string claveCifrada, string claveTextoPlano);

        public Usuario EncontrarPorId(int id);
    }
}
