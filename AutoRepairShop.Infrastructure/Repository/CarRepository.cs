using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;
using AutoRepairShop.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Infrastructure.Repository;

public class CarRepository : ICarRepository
{
    private readonly AutoRepairShopDbContext _db;

    public CarRepository(AutoRepairShopDbContext db)
    {
        _db = db;
    }

    public async Task<Car> CreateAsync(Car car)
    {
        _db.Cars.Add(car);
        await _db.SaveChangesAsync();
        return car;
    }

    public async Task<Car?> UpdateAsync(Car car)
    {
        var model = await _db.Cars.FirstOrDefaultAsync(x => x.Id == car.Id);
        if (model is null)
        {
            return null;
        }
        model.Brand = car.Brand;
        model.Model = car.Model;
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        var model = await _db.Cars.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        var model = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
        if (model is null)
        {
            return;
        }
        _db.Cars.Remove(model);
        await _db.SaveChangesAsync();
    }
}
