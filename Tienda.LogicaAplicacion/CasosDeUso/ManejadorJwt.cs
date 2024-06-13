using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tienda.LogicaAplicacion.DTOs;

public class ManejadorJwt { 
    public static string GenerarToken(EncargadoDTO encargadoDTO)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        //clave secreta, generalmente se incluye en el archivo de configuración
        //Debe ser un vector de bytes 
        var clave = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");

        //Se incluye un claim para el rol

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Email, encargadoDTO.Email)
            }),
            Expires = DateTime.UtcNow.AddMonths(1),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}