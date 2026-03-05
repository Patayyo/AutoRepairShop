using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Application.Factories;
using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;
using System.Globalization;

namespace AutoRepairShop.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _repo;
    private readonly GasolineCarFactory _gasolineCar;
    private readonly DieselCarFactory _dieselCar;

    public CarService(ICarRepository repo, GasolineCarFactory gasolineCar, DieselCarFactory dieselCar)
    {
        _repo = repo;
        _dieselCar = dieselCar;
        _gasolineCar = gasolineCar;
    }

    public async Task<Car> CreateAsync(string brand, string model, string stateNumber, EngineTypeEnum engine)
    {
        if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(stateNumber))
        {
            throw new Exception("Марка или модель, или гос номер не могут быть пустыми");
        }

        var dto = new CreateCarRequest(Brand: brand, Model: model, StateNumber: stateNumber, Engine: engine);

        Car car;

        if (dto.Engine == EngineTypeEnum.DieselEngine)
        {
            car = _dieselCar.Create(dto);
        }
        else
        {
            car = _gasolineCar.Create(dto);
        }

        if (car.Id == Guid.Empty)
        {
            car.Id = Guid.NewGuid();
        }

        await _repo.CreateAsync(car);
        return car;
    }

    public async Task<Car> UpdateAsync(Guid id, string brand, string model)
    {
        if (id ==  Guid.Empty)
        {
            throw new Exception("Id не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
        {
            throw new Exception("Марка или модель не могут быть пустыми");
        }

        var car = await _repo.GetByIdAsync(id);

        if (car == null)
        {
            throw new Exception($"Машина с таким id:{id} не найдена");
        }

        car.Brand = brand;
        car.Model = model;

        var updatedCar = await _repo.UpdateAsync(car);

        if (updatedCar  == null)
        {
            throw new Exception("не найдено");
        }

        return updatedCar;
    }

    public async Task<Car> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }

        var Car = await _repo.GetByIdAsync(id);
        if (Car == null)
        {
            throw new Exception("не найдено");
        }
        return Car;
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("id не может быть пустым");
        }
        await _repo.DeleteAsync(id);
    }
}
