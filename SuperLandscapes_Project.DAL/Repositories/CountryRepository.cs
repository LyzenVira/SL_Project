using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.GenericRepository;
using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace SuperLandscapes_Project.DAL.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(SqlConnection connection, IDbTransaction transaction)
            :base(connection,transaction,"Country")
        {        }
    }
}
