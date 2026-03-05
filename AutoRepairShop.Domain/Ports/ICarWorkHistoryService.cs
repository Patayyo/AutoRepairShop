using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ICarWorkHistoryService
{
    public Task<CarWorkHistory> GetByIdAsync(Guid id);
    public Task<List<CarWorkHistory>> GetByCarIdAsync(Guid id);
    public Task<CarWorkHistory> CreateAsync(Guid carId, Guid typeOfWorkId, DateTime inWork, DateTime outWork);
    public Task<CarWorkHistory> UpdateAsync(Guid id, Guid typeOfWorkId, DateTime inWork, DateTime outWork);
    public Task DeleteAsync(Guid id);
}
