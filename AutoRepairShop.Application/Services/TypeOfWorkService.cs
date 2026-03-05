using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;

namespace AutoRepairShop.Application.Services;

public class TypeOfWorkService : ITypeOfWorkService
{
    private readonly ITypeOfWorkRepository _repo;

    public TypeOfWorkService(ITypeOfWorkRepository repo)
    {
        _repo = repo;
    }

    public async Task<TypeOfWork> CreateAsync(string name, EngineTypeEnum engine)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Название работы не может быть пустым");
        }
        
        var dto = new TypeOfWork { Name = name, Engine = engine };

        if (dto.Id == Guid.Empty)
        {
            dto.Id = Guid.NewGuid();
        }

        await _repo.CreateAsync(dto);
        return dto;
    }

    public async Task<TypeOfWork> UpdateAsync(Guid id, string name)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }

        if(string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Название работы не может быть пустым");
        }

        var typeOfWork = await _repo.GetByIdAsync(id);

        if (typeOfWork == null)
        {
            throw new Exception($"Работы с таким id:{id} нет");
        }

        typeOfWork.Name = name;
        var updated = await _repo.UpdateAsync(typeOfWork);

        if (updated == null)
        {
            throw new Exception("не найдено");
        }

        return updated;
    }

    public async Task<TypeOfWork> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }

        var typeOfWork = await _repo.GetByIdAsync(id);

        if (typeOfWork == null)
        {
            throw new Exception("не найдено");
        }

        return typeOfWork;
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Id не может быть пустым");
        }
        await _repo.DeleteAsync(id);
    }
}
