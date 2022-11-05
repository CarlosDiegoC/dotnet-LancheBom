#nullable disable

using LancheBom.Domain.Validation;

namespace LancheBom.Domain.Models
{
    public sealed class Pedido
    {
        public int Id { get; private set; }
        public int LancheId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool Status { get; private set; }
        public Lanche Lanche { get; private set; }
        public List<Adicional> Adicionais { get; set; } = new List<Adicional>();

        public Pedido(int lancheId)
        {
            ValidateDomain(lancheId);
        }

        public Pedido(int id, int lancheId)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido, o id não pode ser negativo");
            Id = id;
            ValidateDomain(lancheId);
        }

        private decimal CalcularValorTotal()
        {
            decimal totalAdicionais = 0;
            if(Adicionais is not null)
            {         
                Adicionais.ForEach(adicional => totalAdicionais += adicional.Preco);
            }
            ValorTotal = Lanche.Preco + totalAdicionais;
            return ValorTotal;
        }

        public void RemoverPedido()
        {
            Status = false;
        }

        private void ValidateDomain(int lancheId)
        {          
            DomainExceptionValidation.When(lancheId <= 0, "Id de lanche inválido, o id não pode ser menor ou igual a zero.");
            LancheId = lancheId;
            ValorTotal = CalcularValorTotal();
            Status = true;
        }
    }
}