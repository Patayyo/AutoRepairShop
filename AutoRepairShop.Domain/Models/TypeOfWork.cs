namespace AutoRepairShop.Domain.Models;

public class TypeOfWork
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public EngineTypeEnum Engine { get; set; }
    public List<CarWorkHistory> WorkHistory { get; set; } = new();
}
