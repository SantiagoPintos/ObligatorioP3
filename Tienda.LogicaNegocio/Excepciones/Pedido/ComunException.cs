using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Pedido
{
    public class ComunException: Exception
    {

        public ComunException()
        {
        }

        public ComunException(string message) : base(message)
        {
        }

        public ComunException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected ComunException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
