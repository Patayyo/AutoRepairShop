using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Application.Contracts;

public record CreateCarRequest(string Brand, string Model, string StateNumber, EngineTypeEnum Engine);
