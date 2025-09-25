using GeometriaModels;
using GeometriaServices;
using Microsoft.AspNetCore.Mvc;


namespace EjemploWebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FigurasController : ControllerBase
{
    IFigurasService _figurasService;

    public FigurasController(IFigurasService figurasService)
    {
        _figurasService = figurasService;
    }

    [HttpGet]
    async public Task<ActionResult<List<FiguraModel>>> Get()
    {
        return Ok(await _figurasService.GetAll());
    }

    // GET api/<FigurasController>/5
    [HttpGet("{id}")]
    async public Task<ActionResult<List<FiguraModel>>>  Get(int id)
    {
        var figura = await _figurasService.GetById(id);

        if(figura==null) return NotFound();

        return Ok(figura);
    }

    // POST api/<FigurasController>
    [HttpPost]
    async public Task<ActionResult> Post([FromBody] FiguraModel value)
    {
        _figurasService.CrearNuevo(value);

        return Ok();
    }

    // PUT api/<FigurasController>/5
    [HttpPut("{id}")]
    async public Task<ActionResult> Put(int id, [FromBody] string value)
    {
        var figura = await _figurasService.GetById(id);

        if (figura == null) return NotFound();

        await _figurasService.Actualizar(figura);

        return Ok();
    }

    // DELETE api/<FigurasController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
