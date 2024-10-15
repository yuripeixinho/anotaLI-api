using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PerfilContaController : ControllerBase
{
    private readonly IPerfilContaManager _perfilContaManager;

    public PerfilContaController(IPerfilContaManager perfilContaManager)
    {
        _perfilContaManager = perfilContaManager;   
    }


    [HttpGet("/contas/{contaID}/perfis")]
    public async Task<IActionResult> Get(int contaID)
    {
        return Ok(await _perfilContaManager.GetPerfisContaAsync(contaID));
    }
}
