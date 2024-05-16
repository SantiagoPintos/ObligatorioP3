using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Articulo;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Articulo : IValidable<Articulo>, IEquatable<Articulo>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(13), MinLength(13)]
        public long Codigo { get; set; }
        [Required]
        [MaxLength(200), MinLength(5)]
        public string Descripcion { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int stock { get; set; }
        [Required]
        public decimal PrecioUnitario { get; set; }


        //constructor vacío para MVC y EF
        public Articulo() { }

        // Constructor Articulo sin id
        public Articulo(string Nombre, long Codigo, string Descripcion, int stock, decimal PrecioUnitario)
        {
            this.Nombre = Nombre;
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.stock = stock;
            this.PrecioUnitario = PrecioUnitario;
            EsValido(this);
        }

        public Articulo(string Nombre, long Codigo, string Descripcion, int stock, decimal PrecioUnitario, int id)
        {
            this.Nombre = Nombre;
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.stock = stock;
            this.PrecioUnitario = PrecioUnitario;
            this.Id = id;
            EsValido(this);
        }

        public void EsValido(Articulo articulo)
        {
            if(articulo==null) throw new ArticuloNuloException("El articulo no puede ser nulo");

            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (Nombre.Length < 10 || Nombre.Length > 200)
            {
                throw new NombreNoValidoException("El nombre debe tener entre 10 y 200 caracteres.");
            }
            if (Descripcion.Length < 5 || string.IsNullOrEmpty(Descripcion))
            {
                throw new DescripcionNoValidaException("La descripción debe tener al menos 5 caracteres");
            }
            if (string.IsNullOrEmpty(Codigo.ToString()))
            {
                throw new CodigoNoValidoException("El código no puede ser vacío");
            }
            if (Codigo.ToString().Length != 13)
            {
                throw new CodigoNoValidoException("El código debe tener 13 caracteres");
            }
            if (stock < 0)
            {
                throw new StockNoValidoException("El stock no puede ser negativo");
            }
            if (PrecioUnitario < 0)
            {
                throw new PrecioUnitarioNoValidoException("El precio no es válido");
            }



        }

        public void EsValido()
        {
            try
            {
                EsValido(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Equals(Articulo? other)
        {
            if(other == null) throw new ArticuloNuloException("El articulo no puede ser nulo");

            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return $"Nombre del artículo: {Nombre}, descripción: {Descripcion}";
        }
    }
}
