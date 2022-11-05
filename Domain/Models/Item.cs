#nullable disable

using LancheBom.Domain.Validation;

namespace LancheBom.Domain.Models
{
    public sealed class Item
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public int AdicionalId { get; private set; }
        public Pedido Pedido { get; set; }
        public Adicional Adicional { get; set; }

        public Item(int pedidoId, int adicionalId)
        {   
            ValidateDomain(pedidoId, adicionalId);
        }
        
        public Item(int id, int pedidoId, int adicionalId)
        {   
            DomainExceptionValidation.When(id <= 0, "Id inválido, o id não pode ser menor ou igual a zero.");
            Id = id;
            ValidateDomain(pedidoId, adicionalId);
        }

        private void ValidateDomain(int pedidoId, int adicionalId)
        {
            
            DomainExceptionValidation.When(pedidoId <= 0, "Id de pedido inválido, o id não pode ser menor ou igual a zero.");
            DomainExceptionValidation.When(adicionalId <= 0, "Id de adicional inválido, o id não pode ser menor ou igual a zero.");
            PedidoId = pedidoId;
            AdicionalId = adicionalId;
        }
    }
}