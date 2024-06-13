using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Token
{
    public class TokenNoValidoException:Exception
    {
        public TokenNoValidoException()
        {
        }

        public TokenNoValidoException(string message) : base(message)
        {
        }

        public TokenNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected TokenNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
