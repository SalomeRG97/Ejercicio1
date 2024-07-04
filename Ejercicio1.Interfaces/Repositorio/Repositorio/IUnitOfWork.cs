using Microsoft.EntityFrameworkCore.Storage;

namespace Ejercicio1.Interfaces
{
    public interface IUnitOfWork
    {
        IMedicionLuzRepository MedicionLuzRepository { get; }
        IPatronLuzRepository PatronLuzRepository { get; }

        IDbContextTransaction BeginTransaction();
        void Dispose();
        Task SaveChanges();
    }
}