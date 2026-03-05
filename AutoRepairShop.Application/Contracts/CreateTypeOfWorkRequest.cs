using AutoRepairShop.Domain.Models;

namespace AutoRepairShop.Application.Contracts;

public record CreateTypeOfWorkRequest(string Name, EngineTypeEnum Engine);
