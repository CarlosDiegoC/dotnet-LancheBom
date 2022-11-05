#nullable disable

using LancheBom.Domain.Validation;

namespace LancheBom.Domain.Models
{
    public sealed class Lanche
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public Lanche(int id, string nome, decimal preco)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;
            ValidateDomain(nome, preco);
        }
        private void ValidateDomain(string nome, decimal preco)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido, o nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 2, "Nome inválido, é necessário pelo menos 2 caracteres.");
            DomainExceptionValidation.When(preco <= 0, "Valor de preço inválido.");
            Nome = nome;
            Preco = preco;
        }
    }
}