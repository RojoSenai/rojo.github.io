using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoClassificados.ViewModels;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RojoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new
                    {
                        mensagem = "Email ou Senha inválidos"
                    });
                }

                var minhasClaims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Idusuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdtipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdtipoUsuario.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rojo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                            issuer: "rojoAPI",
                            audience: "rojoAPI",
                            claims: minhasClaims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: creds
                        );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
     }
}
