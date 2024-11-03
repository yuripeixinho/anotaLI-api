using AL.Core.Shared.ModelViews.Produto;
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
    [HttpGet("/produtos/{produtoID}")]
    public async Task<IActionResult> GetById(int produtoID)
    {
        return Ok(await _produtoManager.GetProdutosByIdAsync(produtoID));
    }

    [Authorize]
    [HttpGet("/contas/{contaID}/produtos/{produtoID}")]
    public async Task<IActionResult> GetByContaById(string contaID, int produtoID)
    {
        return Ok(await _produtoManager.GetProdutosByContaByIdAsync(contaID, produtoID));
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
    [HttpPost("/contas/{contaID}/produtos")]
    public async Task<IActionResult> Post([FromBody] NovoProduto produto, string contaID)
    {
        ProdutoContaView produtoInserido = await _produtoManager.InsertProdutoAsync(produto, contaID);

        return CreatedAtAction(nameof(GetByConta), new { contaID }, produtoInserido);
    }

    [Authorize]
    [HttpPut("/contas/{contaID}/produtos/{produtoID}")]
    public async Task<IActionResult> Put([FromBody] AlteraProduto produto, string contaID, int produtoID)
    {
        ProdutoContaView produtoAtualizado = await _produtoManager.UpdateProdutoAsync(produto, contaID, produtoID);

        return Ok(produtoAtualizado);
    }

    [Authorize]
    [HttpDelete("/contas/{contaID}/produtos/{produtoID}")]
    public async Task<IActionResult> Delete(string contaID, int produtoID)
    {
        await _produtoManager.DeleteProdutoAsync(contaID, produtoID);

        return NoContent();
    }
}
