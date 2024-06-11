using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Encargado
{
    public class EncargadoException:Exception
    {
        public EncargadoException()
        {
        }
        public EncargadoException(string? message) : base(message)
        {
        }
        public EncargadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected EncargadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
