namespace AutoRepairShop.Domain.Models;

public class Car
{
    public Guid Id { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; } 
    public required string StateNumbers { get; set; } 
    public EngineTypeEnum Engine { get; set; }
    public List<CarWorkHistory> WorkHistory { get; set; } = new();
}
