#nullable disable
using LancheBom.Context;
using LancheBom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LancheBom.Repository
{
    public class LancheRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public LancheRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Lanche>> Get()
        {
            return await _applicationDbContext.Lanches.ToListAsync();
        }

        public async Task<Lanche> GetById(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException("Digite um id válido.");
            else return await _applicationDbContext.Lanches.FirstOrDefaultAsync(Lanche => Lanche.Id == id);          
        }

        public async Task<Lanche> Create(Lanche Lanche)
        {
            _applicationDbContext.Lanches.Add(Lanche);
            await _applicationDbContext.SaveChangesAsync();
            return Lanche;
        }

        public async Task<Lanche> Update(Lanche Lanche)
        {
            _applicationDbContext.Update(Lanche);
            await _applicationDbContext.SaveChangesAsync();
            return Lanche;
        }
    }
}