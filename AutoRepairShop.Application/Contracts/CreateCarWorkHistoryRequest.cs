namespace AutoRepairShop.Application.Contracts;

public record CreateCarWorkHistoryRequest(Guid CarId, Guid TypeOfWorkId, DateTime InWork, DateTime OutWork);
