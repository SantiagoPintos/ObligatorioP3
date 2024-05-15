using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Pedido
{
    public class ExpressException:Exception
    {
        public ExpressException()
        {
        }

        public ExpressException(string message) : base(message)
        {
        }

        public ExpressException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected ExpressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
