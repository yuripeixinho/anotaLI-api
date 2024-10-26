using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class FeiraController : ControllerBase
{
    private readonly IFeiraManager _feiraManager;

    public FeiraController(IFeiraManager feiraManager)
    {
        _feiraManager = feiraManager;
    }

    [Authorize]
    [HttpGet("/contas/{contaID}/feiras")]
    public async Task<IActionResult> Get(string contaID)
    {
        return Ok(await _feiraManager.GetFeirasAsync(contaID));
    }
}
