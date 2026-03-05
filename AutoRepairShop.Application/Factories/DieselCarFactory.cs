using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Application.Factories;

public class DieselCarFactory : CarFactory
{
    public DieselCarFactory()
    {
        Engine = EngineTypeEnum.DieselEngine;
    }

    public override Car Create(CreateCarRequest req)
    {
        return new Car { Brand = req.Brand, Model = req.Model, StateNumbers = req.StateNumber, Engine = Engine };
    }
}
