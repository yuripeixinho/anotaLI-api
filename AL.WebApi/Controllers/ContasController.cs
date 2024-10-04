using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
    private readonly IContaManager _contaManager;

    public ContasController(IContaManager contaManager)
    {
        _contaManager = contaManager;
    }
    
    [HttpGet("/contas")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _contaManager.GetContasAsync());
    }

    [HttpGet("/contas/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _contaManager.GetContaByIdAsync(id));
    }

    [HttpPost("/contas")]
    public async Task<IActionResult> Post([FromBody] NovaConta novaConta)
    {
        Conta contaInserida = await _contaManager.InsertContaAsync(novaConta);

        return CreatedAtAction(nameof(Get), new { id = contaInserida.ContaID }, contaInserida);
    }

    [HttpPut("/contas")]
    public async Task<IActionResult> Put([FromBody] AlteraConta alteraConta)
    {
        var contaAtualizada = await _contaManager.UpdateContaAsync(alteraConta);

        return Ok(contaAtualizada);
    }

    [HttpDelete("/contas/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contaManager.DeleteContaAsync(id);

        return NoContent();
    }
}
