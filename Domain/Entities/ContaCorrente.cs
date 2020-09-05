using Dapper.Contrib.Extensions;

namespace Domain.Entities
{
    [Table("ContaCorrente")]
    public class ContaCorrente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public void Creditar(decimal valor){
            Saldo += valor;
        }
    }
}
