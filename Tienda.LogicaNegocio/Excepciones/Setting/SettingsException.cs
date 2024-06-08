using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Setting
{
    public class SettingsException: Exception
    {
        public SettingsException()
        {
        }

        public SettingsException(string message) : base(message)
        {
        }

        public SettingsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected SettingsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
