using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarWorkHistoriesController : ControllerBase
    {
        private readonly ICarWorkHistoryService _service;

        public CarWorkHistoriesController(ICarWorkHistoryService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CarWorkHistoryResponse>> Get(Guid id)
        {
            var history = await _service.GetByIdAsync(id);

            var resp = new CarWorkHistoryResponse(
                Id: history.Id,
                CarId: history.CarId,
                TypeOfWorkId: history.TypeOfWorkId,
                InWork: history.InWork,
                OutWork: history.OutWork);

            return Ok(resp);
        }

        [HttpGet("by-car/{carId:guid}")]
        public async Task<ActionResult<List<CarWorkHistoryResponse>>> GetByCarId(Guid carId)
        {
            var list = await _service.GetByCarIdAsync(carId);

            var resp = list
                .Select(x => new CarWorkHistoryResponse(
                    Id: x.Id,
                    CarId: x.CarId,
                    TypeOfWorkId: x.TypeOfWorkId,
                    InWork: x.InWork,
                    OutWork: x.OutWork))
                .ToList();

            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<CarWorkHistoryResponse>> Post([FromBody] CreateCarWorkHistoryRequest req)
        {
            var history = await _service.CreateAsync(req.CarId, req.TypeOfWorkId, req.InWork, req.OutWork);

            var resp = new CarWorkHistoryResponse(
                Id: history.Id,
                CarId: history.CarId,
                TypeOfWorkId: history.TypeOfWorkId,
                InWork: history.InWork,
                OutWork: history.OutWork);

            return CreatedAtAction(nameof(Get), new { id = resp.Id }, resp);
        }

        [HttpPut]
        public async Task<ActionResult<CarWorkHistoryResponse>> Put([FromBody] UpdateCarWorkHistoryRequest req)
        {
            var history = await _service.UpdateAsync(req.Id, req.TypeOfWorkId, req.InWork, req.OutWork);

            var resp = new CarWorkHistoryResponse(
                Id: history.Id,
                CarId: history.CarId,
                TypeOfWorkId: history.TypeOfWorkId,
                InWork: history.InWork,
                OutWork: history.OutWork);

            return Ok(resp);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
