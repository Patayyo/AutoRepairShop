using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ICarService
{
    public Task<Car> CreateAsync(string brand, string model, string stateNumber, EngineTypeEnum engine);
    public Task<Car> GetByIdAsync(Guid Id);
    public Task<Car> UpdateAsync(Guid id, string brand, string model);
    public Task DeleteAsync(Guid Id);
}
