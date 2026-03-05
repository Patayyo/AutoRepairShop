using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;

namespace AutoRepairShop.Application.Services;

public class CarWorkHistoryService : ICarWorkHistoryService
{
    private readonly ICarRepository _carRepo;
    private readonly ITypeOfWorkRepository _workRepo;
    private readonly ICarWorkHistoryRepository _historyRepo;

    public CarWorkHistoryService(ICarRepository carRepo, ITypeOfWorkRepository workRepo, ICarWorkHistoryRepository historyRepo)
    {
        _carRepo = carRepo;
        _workRepo = workRepo;
        _historyRepo = historyRepo;
    }

    public async Task<CarWorkHistory> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }

        var history = await _historyRepo.GetByIdAsync(id);

        if (history == null)
        {
            throw new Exception("не найдено");
        }

        return history;
    }

    public async Task<List<CarWorkHistory>> GetByCarIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }

        var car = await _carRepo.GetByIdAsync(id);
        if (car == null)
        {
            throw new Exception("не найдено");
        }

        var list = await _historyRepo.GetByCarIdAsync(id);
        return list;
    }

    public async Task<CarWorkHistory> CreateAsync(Guid carId, Guid typeOfWorkId, DateTime inWork, DateTime outWork)
    {
        if (carId == Guid.Empty || typeOfWorkId == Guid.Empty)
        {
            throw new Exception("carId/typeOfWorkId не могут быть пустыми");
        }

        if (outWork < inWork)
        {
            throw new Exception("OutWork не может быть меньше InWork");
        }

        var car = await _carRepo.GetByIdAsync(carId);
        if ( car == null)
        {
            throw new Exception("машина не найдена");
        }

        var work = await _workRepo.GetByIdAsync(typeOfWorkId);
        if (work == null)
        {
            throw new Exception("тип работы не найден");
        }

        if (car.Engine != work.Engine)
        {
            throw new Exception("тип работы не подходит для двигателя автомобиля");
        }

        var history = new CarWorkHistory
        {
            Id = Guid.NewGuid(),
            CarId = carId,
            TypeOfWorkId = typeOfWorkId,
            InWork = inWork,
            OutWork = outWork,
        };

        await _historyRepo.CreateAsync(history);
        return history;
    }

    public async Task<CarWorkHistory> UpdateAsync(Guid id, Guid typeOfWorkId, DateTime inWork, DateTime outWork)
    {
        if (id == Guid.Empty || typeOfWorkId == Guid.Empty)
        {
            throw new Exception("Id/typeOfWorkId не могут быть пустыми");
        }

        if (outWork < inWork)
        {
            throw new Exception("OutWork не может быть меньше InWork");
        }

        var history = await _historyRepo.GetByIdAsync(id);
        if (history == null)
        {
            throw new Exception("не найдено");
        }

        var car = await _carRepo.GetByIdAsync(history.CarId);
        if (car == null)
        {
            throw new Exception("машина не найдена");
        }

        var work = await _workRepo.GetByIdAsync(typeOfWorkId);
        if (work == null)
        {
            throw new Exception("тип работы не найден");
        }

        if (car.Engine != work.Engine)
        {
            throw new Exception("тип работы не подходит для двигателя автомобиля");
        }

        history.TypeOfWorkId = typeOfWorkId;
        history.InWork = inWork;
        history.OutWork = outWork;

        var updated = await _historyRepo.UpdateAsync(history);
        if (updated == null)
        {
            throw new Exception("не найдено");
        }

        return updated;
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }
        await _historyRepo.DeleteAsync(id);
    }
}
