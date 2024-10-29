using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Manager.Implementation;
using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoManager _produtoManager;

    public ProdutosController(IProdutoManager produtoManager)
    {
        _produtoManager = produtoManager;
    }

    [Authorize]
    [HttpGet("/contas/{contaID}/produtos")]
    public async Task<IActionResult> GetByConta(string contaID)
    {
        return Ok(await _produtoManager.GetProdutosByContaAsync(contaID));
    }

    [Authorize]
    [HttpGet("/perfilcontas/{perfilContaID}/produtos")]
    public async Task<IActionResult> GetByPerfilConta(string perfilContaID)
    {
        return Ok(await _produtoManager.GetProdutosByPerfilContasAsync(perfilContaID));
    }

    [Authorize]
    [HttpGet("/contas/{contaID}/feiras/{feiraID}/produtos")]
    public async Task<IActionResult> GetByFeira(string contaID, int feiraID)
    {
        return Ok(await _produtoManager.GetProdutosByFeiraEContaAsync(contaID, feiraID));
    }

    [Authorize]
    [HttpGet("/produtos/filtrar")]
    public async Task<IActionResult> FiltrarFeirasPorPeriodos([FromQuery] List<int> periodoIds)
    {
        return Ok(await _produtoManager.FiltrarFeirasPorPeriodosAsync(periodoIds));
    }

    [Authorize]
    [HttpDelete("/contas/{contaID}/produtos/{produtoID}")]
    public async Task<IActionResult> Delete(string contaID, int produtoID)
    {
        await _produtoManager.DeleteProdutoAsync(contaID, produtoID);

        return NoContent();
    }

}
