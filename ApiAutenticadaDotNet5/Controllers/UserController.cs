using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutenticadaDotNet5.Controllers
{
    public class UserController : ControllerBase
    {
        
        [HttpGet]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("api/funcionario")]
        [Authorize(Roles = "funcionario,gerente")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("api/gerente")]
        [Authorize(Roles = "gerente")]
        public string Manager() => "Gerente";
    }
}