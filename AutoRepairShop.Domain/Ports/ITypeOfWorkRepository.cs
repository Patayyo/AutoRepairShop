using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Domain.Ports;

public interface ITypeOfWorkRepository
{
    public Task<TypeOfWork> CreateAsync(TypeOfWork work);
    public Task<TypeOfWork?> UpdateAsync(TypeOfWork work);
    public Task<TypeOfWork?> GetByIdAsync(Guid id);
    public Task DeleteAsync(Guid Id);
}
