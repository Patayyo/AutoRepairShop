namespace AutoRepairShop.Application.Contracts;

public record UpdateCarWorkHistoryRequest(Guid Id, Guid TypeOfWorkId, DateTime InWork, DateTime OutWork);

