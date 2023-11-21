using System.Data.SqlClient;
using System.Data;
using SuperLandscapes_Project.DAL.GenericRepository;
using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using System.Transactions;

namespace SuperLandscapes_Project.DAL.Repositories
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _transaction;
        public ProjectRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Project")
        { 
            _connection = connection;
            _transaction = transaction;
        }

        public void AddProject(Project project)
        {
            using (var command = new SqlCommand("AddProject", _connection, (SqlTransaction)_transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Title", project.Title);
                command.Parameters.AddWithValue("@Description", project.Description);
                command.Parameters.AddWithValue("@Period", project.Period);
                command.Parameters.AddWithValue("@DateYear", project.DateYear);
                command.Parameters.AddWithValue("@CountryId", project.CountryId);
                command.Parameters.AddWithValue("@RequestDescription", project.RequestDescription);
                command.Parameters.AddWithValue("@RequestList", project.RequestList);
                command.Parameters.AddWithValue("@SolutionDescription", project.SolutionDescription);
                command.Parameters.AddWithValue("@ResultFirstParagraph", project.ResultFirstParagraph);
                command.Parameters.AddWithValue("@ResultSecondParagraph", project.ResultSecondParagraph);
                command.Parameters.AddWithValue("@ResultThirdParagraph", project.ResultThirdParagraph);

                command.ExecuteNonQuery();
            }
        }
    }
}
