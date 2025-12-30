using Microsoft.AspNetCore.Mvc;
using Models.Dtos.C;
using Service.C;

[ApiController]
[Route("api/[Controller]")]

public class CursoController : ControllerBase
{
    private readonly CursoService _cursoService;
    

    public CursoController(CursoService cursoService)
    {
        _cursoService = cursoService;
    }
    [HttpPost]

    public async Task<IActionResult> AddAsync([FromBody] CursoAddDto cursoAddDto)
    {


        var encontrarProfe = await _cursoService.AddAsync(cursoAddDto);
        if (encontrarProfe)
        {
            return Ok("Curso Agregado correctamente.");
        }

        return NotFound("No existe un profesor con el id asociado");
        
    }
}