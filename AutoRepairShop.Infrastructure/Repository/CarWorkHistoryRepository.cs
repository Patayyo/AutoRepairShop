using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;
using AutoRepairShop.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Infrastructure.Repositorty;

public class CarWorkHistoryRepository : ICarWorkHistoryRepository
{
    private readonly AutoRepairShopDbContext _db;

    public CarWorkHistoryRepository(AutoRepairShopDbContext db)
    {
        _db = db;
    }

    public async Task<CarWorkHistory> CreateAsync(CarWorkHistory carWorkHistory)
    {
        _db.Add(carWorkHistory);
        await _db.SaveChangesAsync();
        return carWorkHistory;
    }

    public async Task<CarWorkHistory?> UpdateAsync(CarWorkHistory carWorkHistory)
    {
        var model = await _db.CarWorkHistories.FirstOrDefaultAsync(x => x.Id == carWorkHistory.Id);
        if (model == null)
        {
            return null;
        }
        model.TypeOfWorkId = carWorkHistory.TypeOfWorkId;
        model.InWork = carWorkHistory.InWork;
        model.OutWork = carWorkHistory.OutWork;
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<CarWorkHistory?> GetByIdAsync(Guid id)
    {
        var model = await _db.CarWorkHistories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return model;
    }

    public async Task<List<CarWorkHistory>> GetByCarIdAsync(Guid id)
    {
        var query = _db.CarWorkHistories.AsNoTracking().Where(x => x.CarId == id).OrderBy(x => x.InWork);
        var model = await query.ToListAsync();
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        var model = await _db.CarWorkHistories.FirstOrDefaultAsync(x => x.Id == id);
        if (model is null)
        {
            return;
        }
        _db.CarWorkHistories.Remove(model);
        await _db.SaveChangesAsync();
    }
}
