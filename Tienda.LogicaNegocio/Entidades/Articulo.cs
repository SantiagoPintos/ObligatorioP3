using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Articulo;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Articulo:IValidable<Articulo>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int stock { get; set; }
        public decimal PrecioUnitario { get; set; }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (Descripcion.Length < 5 || string.IsNullOrEmpty(Descripcion))
            {
                throw new DescripcionNoValidaException("La descripción debe tener al menos 5 caracteres");
            }
            if (stock < 0)
            {
                throw new StockNoValidoException("El stock no puede ser negativo");
            }
            if (Descripcion.Length < 13) {
                throw new DescripcionNoValidaException("La descripción debe tener al menos 13 caracteres");
            }
            if (PrecioUnitario < 0)
            {
                throw new PrecioUnitarioNoValidoException("El precio no es válido");
            }
            //el código debe tener al menos 13 digitos significativos, se convierte a string para contar
            //la cant de digitos
            if (Descripcion.ToString().Length<13)
            {
                throw new CodigoNoValidoException("El código no es válido");
            }

        }
    }
}
