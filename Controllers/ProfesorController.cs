
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.ListP;
using Models.Dtos.P;
using Service.P;

[ApiController]
[Route("api/[Controller]")]

public class ProfesorController : ControllerBase
{
    private readonly ProfesorService _profesorService;

    public ProfesorController(ProfesorService profesorService)
    {
        _profesorService = profesorService;
    }
    [HttpPost]

    public async Task<IActionResult> AddAsyn([FromBody] ProfesorAddDto profesorAddDto)
    {
        await _profesorService.AddAsync(profesorAddDto);
        return Ok("Profesor Agregado correctamente.");
    }

    [HttpGet]

    public async Task<IActionResult> GetAsync()
    {
        List<ProfesorListDto> lista = await _profesorService.GetAsync();
        return Ok(lista);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id){

    var profesor = await _profesorService.GetByIdAsync(id);
    if (profesor is null)
    {
        return NotFound("Este Id no Existe.");
    }

    return Ok(profesor);
    
    }
}