using AL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaManager _categoriaManager;

    public CategoriaController(ICategoriaManager categoriaManager)
    {
        _categoriaManager = categoriaManager;   
    }

    [Authorize]
    [HttpGet("/categorias-nao-vinculadas")]
    public async Task<IActionResult> GetDefault()
    {
        return Ok(await _categoriaManager.GetCategoriasDefaultAsync());
    }

    [Authorize]
    [HttpGet("/contas/{contaID}/categorias")]
    public async Task<IActionResult> GetByContaID(string contaID)
    {
        return Ok(await _categoriaManager.GetCategoriasByContaAsync(contaID));
    }
}
