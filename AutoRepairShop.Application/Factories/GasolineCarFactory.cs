using AutoRepairShop.Application.Contracts;
using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Application.Factories;

public class GasolineCarFactory : CarFactory
{
    public GasolineCarFactory()
    {
        Engine = EngineTypeEnum.GasolineEngine;
    }

    public override Car Create(CreateCarRequest req)
    {
        return new Car { Brand = req.Brand, Model = req.Model, StateNumbers = req.StateNumber, Engine = Engine};
    }
}
