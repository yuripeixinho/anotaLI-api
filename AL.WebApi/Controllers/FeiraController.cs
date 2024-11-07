using AL.Core.Shared.ModelViews.PerfilConta;
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

    [Authorize]
    [HttpGet("/feiras/{feiraID}")]
    public async Task<IActionResult> GetById(int feiraID)
    {
        return Ok(await _feiraManager.GetFeiraByIdAsync(feiraID));
    }

    [Authorize]
    [HttpPost("/contas/{contaID}/feiras")]
    public async Task<IActionResult> Post([FromBody] NovaFeira novaFeira, string contaID)
    {
        NovaFeira contaInserida = await _feiraManager.InsertNovaFeiraAsync(novaFeira, contaID);

        return CreatedAtAction(nameof(Get), new { contaID = contaID }, contaInserida );
    }

    [Authorize]
    [HttpPut("/contas/{contaID}/feiras/{feiraID}")]
    public async Task<IActionResult> Put([FromBody] NovaFeira novoPerfilConta, int feiraID, string contaID)
    {
        var novaFeira = await _feiraManager.UpdateFeiraAsync(novoPerfilConta, feiraID, contaID);

        return Ok(novaFeira);
    }

    [Authorize]
    [HttpDelete("/contas/{contaID}/feiras/{feiraID}")]
    public async Task<IActionResult> Delete(string contaID, int feiraID)
    {
        await _feiraManager.DeleteFeiraAsync(contaID, feiraID);

        return NoContent();
    }
}
