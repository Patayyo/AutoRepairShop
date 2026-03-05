using AutoRepairShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Infrastructure.Repository.Context;

public class AutoRepairShopDbContext : DbContext
{
    public readonly Guid AudiGuid = new Guid("14697994-81cd-4cc6-8883-be08faa58e1c");
    public readonly Guid ToyotaGuid = new Guid("53df9d76-1da1-4fe9-91a3-38ca179c1841");
    public readonly Guid OpelGuid = new Guid("742784a0-70c0-4004-820a-22b2c2670945");
    public readonly Guid SparkPlug = new Guid("dca90b74-0b77-47a0-88e9-141cfdb0b748");
    public readonly Guid GlowPlug = new Guid("d1414603-ea48-4bd4-b5bc-cb1d80994bf1");
    public readonly Guid CompressionInCylindersGasoline = new Guid("8989a114-77f2-4af5-8e6c-a04980a691a5");
    public readonly Guid CompressionInCylindersDiesel = new Guid("dbb5e317-e55f-4b84-ac7a-d6c8c43213d3");

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<TypeOfWork> TypeOfWorks { get; set; } = null!;
    public DbSet<CarWorkHistory> CarWorkHistories { get; set; } = null!;

    public AutoRepairShopDbContext(DbContextOptions<AutoRepairShopDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<Car>(e =>
        {
            e.HasIndex(x => x.StateNumbers).IsUnique();

            e.HasData(
                new Car { Id = AudiGuid, Brand = "Audi", Model = "TT", StateNumbers = "А047ЕВ66", Engine = EngineTypeEnum.GasolineEngine },
                new Car { Id = ToyotaGuid, Brand = "Toyota", Model = "Mark 2", StateNumbers = "А002АС", Engine = EngineTypeEnum.GasolineEngine },
                new Car { Id = OpelGuid, Brand = "Opel", Model = "Astra", StateNumbers = "М033ЕЕ", Engine = EngineTypeEnum.DieselEngine }
                );
        });

        mb.Entity<TypeOfWork>(e =>
        {
            e.HasData(
                new TypeOfWork { Id = SparkPlug, Name = "Замена свечей зажигания", Engine = EngineTypeEnum.GasolineEngine},
                new TypeOfWork { Id = GlowPlug, Name = "Замена свечей накаливания", Engine = EngineTypeEnum.DieselEngine},
                new TypeOfWork { Id = CompressionInCylindersGasoline, Name = "Проверка компрессии в цилиндрах", Engine = EngineTypeEnum.GasolineEngine},
                new TypeOfWork { Id = CompressionInCylindersDiesel, Name = "Проверка компрессии в цилиндрах", Engine = EngineTypeEnum.DieselEngine }
                );
        });

        mb.Entity<CarWorkHistory>(e =>
        {
            e.HasIndex(x => x.CarId);
            e.HasIndex(x => x.TypeOfWorkId);

            e.Property(x => x.InWork).IsRequired();
            e.Property(x => x.OutWork).IsRequired();

            e.HasOne(x => x.Car).WithMany(x => x.WorkHistory).HasForeignKey(x => x.CarId);
            e.HasOne(x => x.TypeOfWork).WithMany(x => x.WorkHistory).HasForeignKey(x => x.TypeOfWorkId);
        });
    }
}
