using Domain.DTO;

namespace Service.Interfaces
{
    public interface IContaCorrenteService
    {
        ContaCorrenteDTO CadastrarContaCorrrente(ContaCorrenteDTO contaCorrenteDTO);
        string RealizarTransferencia(TransferenciaDTO pedidoDTO);
    }
}