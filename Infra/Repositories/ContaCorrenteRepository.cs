using Infra.Interfaces;
using Dapper.Contrib.Extensions;
using Domain.Entities;
using System.Data.SqlClient;
using Dapper;

namespace Infra.Repositories
{
    public class ContaCorrenteRepository : Repository, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(SqlConnection sqlConnection, SqlTransaction transaction) : base(sqlConnection, transaction)
        {
        }

        public int InserirContaCorrente(ContaCorrente contaCorrente)
        {
            var result = _sqlConnection.Insert(contaCorrente, _sqlTransaction);

            return (int)result;
        }

        public bool AtualizarContaCorrente(ContaCorrente contaCorrente)
        {
            var result = _sqlConnection.Update(contaCorrente, _sqlTransaction);

            return result;
        }

        public ContaCorrente GetContaCorrenteById(int id)
        {
            string query = @"SELECT * FROM CONTACORRENTE WHERE ID = @ID";

            var result = _sqlConnection.QueryFirstOrDefault<ContaCorrente>(query, new { ID = id }, transaction: _sqlTransaction);

            return result;
        }

        public int InserirLancamento(Lancamento lancamento)
        {
            var result = _sqlConnection.Insert(lancamento, _sqlTransaction);

            return (int)result;
        }
    }
}