using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class StockNoValidoException : Exception
    {
        public StockNoValidoException()
        {
        }
        public StockNoValidoException(string? message) : base(message)
        {
        }
        public StockNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected StockNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
