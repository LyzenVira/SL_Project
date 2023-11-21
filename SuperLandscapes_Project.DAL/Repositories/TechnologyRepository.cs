using System.Data.SqlClient;
using System.Data;
using SuperLandscapes_Project.DAL.GenericRepository;
using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.Repositories.Interfaces;

namespace SuperLandscapes_Project.DAL.Repositories
{
    internal class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Technology")
        { }
    }
}
