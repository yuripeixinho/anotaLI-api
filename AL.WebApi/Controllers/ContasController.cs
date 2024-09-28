using Microsoft.AspNetCore.Mvc;
using AL.Manager.Interfaces.Managers;

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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _contaManager.GetContasAsync());
    }
}
