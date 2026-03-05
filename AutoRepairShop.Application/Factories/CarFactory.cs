using AutoRepairShop.Domain.Models;
using AutoRepairShop.Application.Contracts;

namespace AutoRepairShop.Application.Factories;

public abstract class CarFactory
{
    protected EngineTypeEnum Engine { get; init; }
    public abstract Car Create(CreateCarRequest req);
}
