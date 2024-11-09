using AL.Core.Shared.ModelViews.PerfilConta;
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

    [Authorize]
    [HttpGet("/perfis/{perfilContaID}")]
    public async Task<IActionResult> GetById(string perfilContaID)
    {
        return Ok(await _perfilContaManager.GetPerfilContaByIdAsync(perfilContaID));
    }

    //[HttpGet("/perfis/{perfilContaID}/produtos-por-categoria")]
    //public async Task<IActionResult> GetProdutoCountByCategoria(string perfilContaID)
    //{
    //    var resultado = await _perfilContaManager.GetProdutoCountByCategoriaAsync(perfilContaID);

    //    return Ok(resultado);
    //}
    //[HttpGet("/perfis/{perfilContaID}/produtos-por-categoria")]
    //public async Task<IActionResult> GetProdutoCountByFeiraAsync(string perfilContaID)
    //{
    //    var resultado = await _perfilContaManager.GetProdutoCountByFeiraAsync(perfilContaID);

    //    return Ok(resultado);
    //}
    
    [Authorize]
    [HttpPost("/contas/{contaID}/perfis")]
    public async Task<IActionResult> Post([FromBody] NovoPerfilConta novoPerfilConta, string contaID)
    {
        PerfilContaView contaInserida = await _perfilContaManager.InsertPerfilContaAsync(novoPerfilConta, contaID);

        return CreatedAtAction(nameof(Get), new { contaID = contaID }, contaInserida );
    }

    [Authorize]
    [HttpPut("/contas/{contaID}/perfis/{perfilContaID}")]
    public async Task<IActionResult> Put([FromBody] AlterarPerfilConta alterarPerfilConta, string contaID, string perfilContaID)
    {
        var perfilAtualizado = await _perfilContaManager.UpdatePerfilContaAsync(alterarPerfilConta, contaID, perfilContaID);

        return Ok(perfilAtualizado);
    }

    [Authorize]
    [HttpDelete("/contas/{contaID}/perfis/{perfilContaID}")]
    public async Task<IActionResult> Delete(string contaID, string perfilContaID)
    {
        await _perfilContaManager.DeletePerfilContaAsync(contaID, perfilContaID);

        return NoContent();
    }
}
