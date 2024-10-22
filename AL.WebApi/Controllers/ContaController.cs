using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ContaController : ControllerBase
{
    private readonly IContaManager _contaManager;

    public ContaController(IContaManager contaManager)
    {
        _contaManager = contaManager;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] Conta conta)
    {
        var contaLogada = await _contaManager.ValidaContaEGeraTokenAsync(conta);

        if (contaLogada != null)
        {
            return Ok(contaLogada);
        }

        return Unauthorized();
    }

    [Authorize]
    [HttpGet("/contas")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _contaManager.GetContasAsync());
    }

    [Authorize]
    [HttpGet("/contas/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _contaManager.GetContaByIdAsync(id));
    }

    [HttpPost("/registrar")]
    public async Task<IActionResult> Post([FromBody] NovaConta novaConta)
    {
        Conta contaInserida = await _contaManager.InsertContaAsync(novaConta);

        return CreatedAtAction(nameof(Get), new { id = contaInserida.Id }, contaInserida);
    }

    [Authorize]
    [HttpPut("/contas")]
    public async Task<IActionResult> Put([FromBody] AlteraConta alteraConta)
    {
        var contaAtualizada = await _contaManager.UpdateContaAsync(alteraConta);

        return Ok(contaAtualizada);
    }

    [Authorize]
    [HttpDelete("/contas/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _contaManager.DeleteContaAsync(id);

        return NoContent();
    }
}
