using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Encargado : Usuario
    {
        public Encargado() { }
        public Encargado(string nombre, string apellido, string email, string clave, string claveSinEncriptar) : base(nombre, apellido, email, clave, claveSinEncriptar) { }
        public Encargado(int id, string nombre, string apellido, string email, string clave, string claveSinEncriptar) : base(id, nombre, apellido, email, clave, claveSinEncriptar) { }
        

        public void EsValido()
        {
            try
            {
                base.EsValido();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
