using Ejercicio1.Repositorio;
using AutoMapper;
using Ejercicio1.Entidades;
using Ejercicio1.Interfaces;
using Ejercicio1.Repositorio.Repositorio.Maestros;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ejercicio1.Repositorio.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EjerciciosContext _context;
        private readonly IMapper _mapper;
        private IMedicionLuzRepository _medicionLuzRepository;
        private IPatronLuzRepository _petronLuzRepository;

        public UnitOfWork(EjerciciosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IMedicionLuzRepository MedicionLuzRepository => _medicionLuzRepository ??= new MedicionLuzRepository(_context, _mapper);
        public IPatronLuzRepository PatronLuzRepository => _petronLuzRepository ??= new PatronLuzRepository(_context, _mapper);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
