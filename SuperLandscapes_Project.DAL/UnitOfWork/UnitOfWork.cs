
using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using SuperLandscapes_Project.DAL.UnitOfWork.Interface;
using System.Data.SqlClient;
using System.Data;
using SuperLandscapes_Project.DAL.Repositories;

namespace SuperLandscapes_Project.DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbTransaction _transaction;
        private readonly SqlConnection _connection;

        public UnitOfWork(IDbTransaction transaction, SqlConnection connection)
        {
            _transaction = transaction;
            _connection = connection;

            CountryRepository = new CountryRepository(_connection, _transaction);
            PictureRepository = new PictureRepository(_connection, _transaction);
            ParagraphRepository = new ParagraphRepository(_connection, _transaction);
            ProjectRepository = new ProjectRepository(_connection, _transaction);
            TechnologyRepository = new TechnologyRepository(_connection, _transaction);
            ProjectTechnologyRepository = new ProjectTechnologyRepository(_connection);
        }
        
        public ICountryRepository CountryRepository { get; set; }

        public IPictureRepository PictureRepository { get; set; }

        public IParagraphRepository ParagraphRepository { get; set; }

        public IProjectRepository ProjectRepository { get; set; }

        public ITechnologyRepository TechnologyRepository { get; set; }

        public IProjectTechnologyRepository ProjectTechnologyRepository { get; set; }

        public void Dispose() => _transaction.Dispose();

        public void Save()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
            }
        }
    }
}
