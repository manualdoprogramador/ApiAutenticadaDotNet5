using System;
using ApiAutenticadaDotNet5.Models;
using ApiAutenticadaDotNet5.Repositorio;
using ApiAutenticadaDotNet5.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutenticadaDotNet5.Controllers
{
    public class TokenController : ControllerBase
    {
        // Chamada para autenticar
        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromBody] User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Name, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
       
    }
}