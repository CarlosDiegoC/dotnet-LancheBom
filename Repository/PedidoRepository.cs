#nullable disable

using LancheBom.Context;
using LancheBom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LancheBom.Repository
{
    public class PedidoRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public PedidoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _applicationDbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetPedido(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException("Digite um id válido.");
            return await _applicationDbContext.Pedidos.FirstOrDefaultAsync(pedido => pedido.Id == id);
        }

        public async Task<decimal> CriarPedido(Pedido pedido)
        {
            _applicationDbContext.Pedidos.Add(pedido);
            await _applicationDbContext.SaveChangesAsync();
            return pedido.ValorTotal;
        }

        public async Task<Pedido> AtualizarPedido(Pedido pedido)
        {
            _applicationDbContext.Update(pedido);
            await _applicationDbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task DeletePedido(int id)
        {
            var pedido = await _applicationDbContext.Pedidos.FirstOrDefaultAsync(pedido => pedido.Id == id);
            pedido.RemoverPedido();
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}