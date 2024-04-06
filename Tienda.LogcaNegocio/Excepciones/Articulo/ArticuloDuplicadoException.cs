using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class ArticuloDuplicadoException : Exception
    {
        public ArticuloDuplicadoException()
        {
        }
        public ArticuloDuplicadoException(string? message) : base(message)
        {
        }
        public ArticuloDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected ArticuloDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
