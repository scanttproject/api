using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sca.Interfaces;
using sca.Models;
using sca.Models.Common;
using sca.Models.Request;
using sca.Models.Response;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace sca.Services
{
    public class UserService : IUserService
    {
        //Inyeccion de dependencias
        private AppSettings _appSettings;
        private SCADB _contex;

        public UserService(IOptions<AppSettings> appSettings, SCADB contex)
        {
            _appSettings = appSettings.Value;
            _contex = contex;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse response = new UserResponse();
            string spassword = EncryptServices.GetSHA256(model.contrasenia);

            var usuario = _contex.Usuarios.Where(r=>r.nombreusuario == model.nombreusuario && r.contrasenia == spassword).FirstOrDefault();

            if (usuario == null)
            {
                return null;
            }
            response.nombreusuario = usuario.nombreusuario;
            response.Token = GetToken(usuario);
            return response;
        }

        private string GetToken(Usuarios usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.key);
            var getRol = GetPerfiles(usuario.perfilid);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.nombreusuario),
                        new Claim(ClaimTypes.Role, getRol)

                    }
                    ),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GetPerfiles(int? perfilid)
        {
            var profile = _contex.Perfiles.Where(p => p.id == perfilid).FirstOrDefault();
            return profile.descripcion;
        }
    }
}
