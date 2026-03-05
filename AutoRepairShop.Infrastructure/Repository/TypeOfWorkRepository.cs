using AutoRepairShop.Domain.Models;
using AutoRepairShop.Domain.Ports;
using AutoRepairShop.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Infrastructure.Repositorty;

public class TypeOfWorkRepository : ITypeOfWorkRepository
{
    private readonly AutoRepairShopDbContext _db;

    public TypeOfWorkRepository(AutoRepairShopDbContext db)
    {
        _db = db;
    }

    public async Task<TypeOfWork> CreateAsync(TypeOfWork work)
    {
        _db.Add(work);
        await _db.SaveChangesAsync();
        return work;
    }

    public async Task<TypeOfWork?> UpdateAsync(TypeOfWork work)
    {
        var model = await _db.TypeOfWorks.FirstOrDefaultAsync(x => x.Id == work.Id);
        if (model is null)
        {
            return null;
        }
        model.Name = work.Name;
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<TypeOfWork?> GetByIdAsync(Guid id)
    {
        var model = await _db.TypeOfWorks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        var model = await _db.TypeOfWorks.FirstOrDefaultAsync(x => x.Id == id);
        if (model is null)
        {
            return;
        }
        _db.TypeOfWorks.Remove(model);
        await _db.SaveChangesAsync();
    }
}
