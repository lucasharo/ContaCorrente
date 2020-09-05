using Dapper.Contrib.Extensions;
using System;

namespace Domain.Entities
{
    [Table("Lancamento")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }
        public int ContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public char Tipo { get; set; }
        public Guid IdTransacao { get; set; }
    }
}
