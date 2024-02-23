using Microsoft.EntityFrameworkCore;
using TestProjectBackend.Data;
using TestProjectBackend.Models.Entities;

namespace TestProjectBackend.Services
{
    public interface IStavkaFaktureService
    {
        Task<List<StavkaFakture>> GetAll();
        Task<Faktura> AddStavkaFakture(Guid idFakture, StavkaFakture stavkaFakture);
        Task<StavkaFakture> GetStavkaFakture(Guid id);
        Task<StavkaFakture> UpdateStavkaFakture(Guid idFakture, Guid idStavke, StavkaFakture stavkaFakture);
        Task<StavkaFakture> DeleteStavkaFakture(Guid idFakture, Guid idStavke);

    }
    public class StavkaFaktureService : IStavkaFaktureService
    {
        private readonly AppDbContext _context;
        public StavkaFaktureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Faktura> AddStavkaFakture(Guid idFakture, StavkaFakture stavkaFakture)
        {
            var result = await _context.Fakture.Include(p => p.StavkeFakture).FirstOrDefaultAsync(p => p.Id == idFakture);
            if (result == null)
            {
                throw new Exception("There is no faktura with ID: " + idFakture);
            }
            
            result.StavkeFakture.Add(stavkaFakture);
            _context.Fakture.Update(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<StavkaFakture> DeleteStavkaFakture(Guid idFakture, Guid idStavke)
        {
            var result = await _context.Fakture.Include(p => p.StavkeFakture).FirstOrDefaultAsync(p => p.Id == idFakture);
            if (result == null)
            {
                throw new Exception("There is no faktura with ID: " + idFakture);
            }

            var res = result.StavkeFakture.Find(p => p.Id == idStavke);
            if (res == null)
            {
                throw new Exception("There is no stavka for IDFakture:" + idStavke);
            }
            result.StavkeFakture.Remove(res);
            _context.Fakture.Update(result);
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<List<StavkaFakture>> GetAll()
        {
            return await _context.StavkaFakture.ToListAsync();
        }

        public async Task<StavkaFakture> GetStavkaFakture(Guid id)
        {
            var stavkaFakture = await _context.StavkaFakture.FindAsync(id);

            if (stavkaFakture == null)
            {
                throw new Exception("There is no stavka fakture with ID:" + id);
            }

            return stavkaFakture;
        }

        public async Task<StavkaFakture> UpdateStavkaFakture(Guid idFakture, Guid idStavke, StavkaFakture stavkaFakture)
        {


            var result = await _context.Fakture.Include(p => p.StavkeFakture).FirstOrDefaultAsync(p => p.Id == idFakture);
            if (result == null)
            {
                throw new Exception("There is no faktura with ID: " + idFakture);
            }

            var res = result.StavkeFakture.Find(p=> p.Id == idStavke);
            if (res == null)
            {
                throw new Exception("There is no stavka for IDFakture:"+ idFakture);  
            }
            result.StavkeFakture.Remove(res);
            result.StavkeFakture.Add(stavkaFakture);
            _context.Fakture.Update(result);
            await _context.SaveChangesAsync();

            return res;
        }
    }
}
