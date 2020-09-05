namespace Infra.Interfaces
{
    public interface IUnitOfWork
    {
        IContaCorrenteRepository ContaCorrenteRepository { get; }

        void Commit();
    }
}