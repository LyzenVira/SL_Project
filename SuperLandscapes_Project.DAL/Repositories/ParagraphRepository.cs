using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Data;
using SuperLandscapes_Project.DAL.GenericRepository;

namespace SuperLandscapes_Project.DAL.Repositories
{
    public class ParagraphRepository : GenericRepository<Paragraph>, IParagraphRepository
    {
        public ParagraphRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Paragraph")
        { }
    }
}
