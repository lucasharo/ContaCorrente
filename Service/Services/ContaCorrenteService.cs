using Infra.Interfaces;
using Service.Interfaces;
using System;
using Domain.DTO;
using Domain.Entities;
using System.Linq;
using Domain.Exceptions;

namespace Service.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContaCorrenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ContaCorrenteDTO CadastrarContaCorrrente(ContaCorrenteDTO contaCorrenteDTO)
        {
            var contaCorrente = new ContaCorrente
            {
                Nome = contaCorrenteDTO.Nome,
                Saldo = contaCorrenteDTO.Saldo
            };

            _unitOfWork.ContaCorrenteRepository.InserirContaCorrente(contaCorrente);

            _unitOfWork.Commit();

            contaCorrenteDTO.Id = contaCorrente.Id;

            return contaCorrenteDTO;
        }

        public string RealizarTransferencia(TransferenciaDTO transferenciaDTO)
        {
            try
            {
                var contaCorrenteOrigem = _unitOfWork.ContaCorrenteRepository.GetContaCorrenteById(transferenciaDTO.ContaCorrenteOrigem);

                if(contaCorrenteOrigem == null)
                {
                    throw new AppNotFoundException("Conta corrente de origem não encontrada");
                }

                var contaCorrenteDestino = _unitOfWork.ContaCorrenteRepository.GetContaCorrenteById(transferenciaDTO.ContaCorrenteDestino);

                if (contaCorrenteDestino == null)
                {
                    throw new AppNotFoundException("Conta corrente de destino não encontrada");
                }

                var guid = Guid.NewGuid();

                var lancamentoDebito = new Lancamento
                {
                    ContaCorrente = transferenciaDTO.ContaCorrenteOrigem,
                    Valor = transferenciaDTO.Valor,
                    Tipo = 'D',
                    IdTransacao = guid
                };

                _unitOfWork.ContaCorrenteRepository.InserirLancamento(lancamentoDebito);

                var lancamentoCredito = new Lancamento
                {
                    ContaCorrente = transferenciaDTO.ContaCorrenteDestino,
                    Valor = transferenciaDTO.Valor,
                    Tipo = 'C',
                    IdTransacao = guid
                };

                _unitOfWork.ContaCorrenteRepository.InserirLancamento(lancamentoCredito);

                contaCorrenteOrigem.Debitar(transferenciaDTO.Valor);

                _unitOfWork.ContaCorrenteRepository.AtualizarContaCorrente(contaCorrenteOrigem);

                contaCorrenteDestino.Creditar(transferenciaDTO.Valor);

                _unitOfWork.ContaCorrenteRepository.AtualizarContaCorrente(contaCorrenteDestino);

                _unitOfWork.Commit();

                return "Transferencia realizada com sucesso!";
            }
            catch (AppNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar tranferência", ex);
            }
        }
    }
}