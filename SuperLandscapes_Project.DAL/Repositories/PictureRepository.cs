using System.Data.SqlClient;
using System.Data;
using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using SuperLandscapes_Project.DAL.GenericRepository;

namespace SuperLandscapes_Project.DAL.Repositories
{
    public class PictureRepository: GenericRepository<Picture>, IPictureRepository
    {
        public PictureRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Picture")
        { }
    }
}
