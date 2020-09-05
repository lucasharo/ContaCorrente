using Infra.Interfaces;
using System.Data.SqlClient;
using System;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlTransaction _sqlTransaction;

        public IContaCorrenteRepository ContaCorrenteRepository { get; }

        public UnitOfWork(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            _sqlConnection = sqlConnection;
            _sqlTransaction = sqlTransaction;

            ContaCorrenteRepository = new ContaCorrenteRepository(sqlConnection, sqlTransaction);
        }

        public void Commit()
        {
            _sqlTransaction.Commit();
        }

        public void Dispose()
        {
            _sqlTransaction.Dispose();
            _sqlConnection.Dispose();
        }
    }
}