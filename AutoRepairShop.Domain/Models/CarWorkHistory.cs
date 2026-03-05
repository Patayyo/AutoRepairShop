namespace AutoRepairShop.Domain.Models;

public class CarWorkHistory
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid TypeOfWorkId { get; set; }

    public required DateTime InWork { get; set; }
    public required DateTime OutWork { get; set; }
   
    public Car? Car { get; set; }
    public TypeOfWork? TypeOfWork { get; set; }

}
