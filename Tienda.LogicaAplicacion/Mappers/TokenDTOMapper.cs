using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class TokenDTOMapper
    {
        public static TokenDTO toDto(Token token)
        {
            TokenDTO tokenDTO = new TokenDTO();
            tokenDTO.Id = token.Id;
            tokenDTO.Encargado = EncargadoDTOMapper.ToDTO(token.Encargado);
            tokenDTO.TokenUsuario = token.TokenUsuario;
            return tokenDTO;
        }

        public static Token FromDto(TokenDTO tokenDTO)
        {
            if (tokenDTO == null) throw new Exception();
            Token token = new Token();
            token.Id = tokenDTO.Id;
            token.Encargado = EncargadoDTOMapper.FromDTO(tokenDTO.Encargado);
            token.TokenUsuario = tokenDTO.TokenUsuario;            
            return token;

        }
    }
}
