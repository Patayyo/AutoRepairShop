using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ICarRepository
{
    public Task<Car> CreateAsync(Car car);
    public Task<Car?> GetByIdAsync(Guid Id);
    public Task<Car?> UpdateAsync(Car car);
    public Task DeleteAsync(Guid Id);
}
