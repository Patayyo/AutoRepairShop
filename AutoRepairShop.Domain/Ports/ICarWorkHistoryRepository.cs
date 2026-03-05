using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ICarWorkHistoryRepository
{
    public Task<CarWorkHistory?> GetByIdAsync(Guid id);
    public Task<List<CarWorkHistory>> GetByCarIdAsync(Guid id);
    public Task<CarWorkHistory> CreateAsync(CarWorkHistory carWorkHistory);
    public Task<CarWorkHistory?> UpdateAsync(CarWorkHistory carWorkHistory);
    public Task DeleteAsync(Guid id);
}
