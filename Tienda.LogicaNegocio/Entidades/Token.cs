using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Token;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Token:IValidable<Token>
    {
        [Key]
        public int Id { get; set; }
        public string TokenUsuario { get; set; }
        public Encargado Encargado { get; set; }

        public Token()
        {
        }
        public Token(string tokenUsuario, Encargado encargado)
        {
            TokenUsuario = tokenUsuario;
            Encargado = encargado;
        }

        public void EsValido()
        {
            if (this.TokenUsuario == null) throw new TokenNoValidoException("Token no puede ser nulo");
            if (this.Encargado == null) throw new TokenNoValidoException("Encargado no puede ser nulo");
        }


    }
}
