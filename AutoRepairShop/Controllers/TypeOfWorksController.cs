using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeOfWorksController : ControllerBase
{
    private readonly ITypeOfWorkService _service;

    public TypeOfWorksController(ITypeOfWorkService service)
    {
        _service = service; 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TypeOfWorkResponse>> Get(Guid id)
    {
        var work = await _service.GetByIdAsync(id);

        var resp = new TypeOfWorkResponse
            (
            Id: work.Id,
            Name: work.Name,
            Engine: work.Engine);

        return Ok(resp);
    }

    [HttpPost]
    public async Task<ActionResult<TypeOfWorkResponse>> Post([FromBody] CreateTypeOfWorkRequest req)
    {
        var work = await _service.CreateAsync(req.Name, req.Engine);
        var resp = new TypeOfWorkResponse
            (
            Id: work.Id,
            Name: work.Name,
            Engine: work.Engine);

        return CreatedAtAction(nameof(Get), new { id = resp.Id }, resp);
    }

    [HttpPut]
    public async Task<ActionResult<TypeOfWorkResponse>> Put([FromBody] UpdateTypeOfWorkRequest req)
    {
        var work = await _service.UpdateAsync(req.Id, req.Name);

        var resp = new TypeOfWorkResponse
            (
            Id: work.Id,
            Name: work.Name,
            Engine: work.Engine);

        return Ok(resp);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
