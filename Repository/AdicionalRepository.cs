#nullable disable

using LancheBom.Context;
using LancheBom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LancheBom.Repository
{
    public class AdicionalRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public AdicionalRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Adicional>> Get()
        {
            return await _applicationDbContext.Adicionais.ToListAsync();
        }

        public async Task<Adicional> GetById(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException("Digite um id válido.");
            else return await _applicationDbContext.Adicionais.FirstOrDefaultAsync(Adicional => Adicional.Id == id);          
        }

        public async Task<Adicional> Create(Adicional Adicional)
        {
            _applicationDbContext.Adicionais.Add(Adicional);
            await _applicationDbContext.SaveChangesAsync();
            return Adicional;
        }

        public async Task<Adicional> Update(Adicional Adicional)
        {
            _applicationDbContext.Update(Adicional);
            await _applicationDbContext.SaveChangesAsync();
            return Adicional;
        }
    }
}