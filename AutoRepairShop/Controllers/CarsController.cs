using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Domain.Ports;
using AutoRepairShop.Infrastructure.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _service;

    public CarsController(ICarService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CarResponse>> Get(Guid id)
    {
        var car = await _service.GetByIdAsync(id);

        var resp = new CarResponse
            (Id: car.Id, 
            Brand: car.Brand, 
            Model: car.Model, 
            StateNumber: car.StateNumbers, 
            Engine: car.Engine);

        return Ok(resp);
    }

    [HttpPost]
    public async Task<ActionResult<CarResponse>> Post([FromBody] CreateCarRequest req)
    {
        var car = await _service.CreateAsync(req.Brand, req.Model, req.StateNumber, req.Engine);
        var resp = new CarResponse
            (
            Id: car.Id,
            Brand: car.Brand,
            Model: car.Model,
            StateNumber: car.StateNumbers,
            Engine: car.Engine);

        return CreatedAtAction(nameof(Get), new {id = resp.Id}, resp);
    }

    [HttpPut]
    public async Task<ActionResult<CarResponse>> Put([FromBody] UpdateCarRequest req)
    {
        var car = await _service.UpdateAsync(req.Id, req.Brand, req.Model);

        var resp = new CarResponse
            (
            Id: car.Id,
            Brand: car.Brand,
            Model: car.Model,
            StateNumber: car.StateNumbers,
            Engine: car.Engine);

        return Ok(resp);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
