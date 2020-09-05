using Domain.Entities;

namespace Infra.Interfaces
{
    public interface IContaCorrenteRepository
    {
        int InserirContaCorrente(ContaCorrente contaCorrente);
        bool AtualizarContaCorrente(ContaCorrente contaCorrente);
        ContaCorrente GetContaCorrenteById(int id);
        int InserirLancamento(Lancamento lancamento);
    }
}