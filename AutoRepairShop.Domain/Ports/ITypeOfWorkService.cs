using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ITypeOfWorkService
{
    public Task<TypeOfWork> CreateAsync(string name, EngineTypeEnum engine);
    public Task<TypeOfWork> UpdateAsync(Guid id, string name);
    public Task<TypeOfWork> GetByIdAsync(Guid id);
    public Task DeleteAsync(Guid Id);
}
