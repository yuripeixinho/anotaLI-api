using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet("/contas/{contaID}/perfis")]
    public async Task<IActionResult> Get(string contaID)
    {
        return Ok(await _perfilContaManager.GetPerfisContaAsync(contaID));
    }
}
