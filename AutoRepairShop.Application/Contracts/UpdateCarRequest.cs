namespace AutoRepairShop.Application.Contracts;

public record UpdateCarRequest(Guid Id, string Brand, string Model);
