using SuperLandscapes_Project.DAL.Repositories.Interfaces;
using System.Data.SqlClient;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.DAL.Repositories
{
    public class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly SqlConnection _connection;
        public ProjectTechnologyRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public void AddProjectTechnology(Project project, Technology technology)
        {
            string query = "INSERT INTO ProjectTechnology (TechnologyId, ProjectId) VALUES (@TechnologyId, @ProjectId)";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@TechnologyId", technology.Id);
                command.Parameters.AddWithValue("@ProjectId",project.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteProjectTechnology(Guid projectId, Guid technologyId)
        {
            string query = "DELETE FROM ProjectTechnology WHERE ProjectId = @ProjectId AND TechnologyId = @TechnologyId";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@TechnologyId", technologyId);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProjectTechnology> GetAllProjectTechnologies()
        {
            List<ProjectTechnology> projectTechnologies = new List<ProjectTechnology>();

            string query = "SELECT * FROM ProjectTechnology";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProjectTechnology projectTechnology = new ProjectTechnology
                        {
                            TechnologyId = (Guid)reader["TechnologyId"],
                            ProjectId = (Guid)reader["ProjectId"]
                        };

                        projectTechnologies.Add(projectTechnology);
                    }
                }
            }

            return projectTechnologies;
        }

        public IEnumerable<Technology> GetTechnologiesByProjectId(Guid projectId)
        {
            string query = @"
        SELECT Technology.*
        FROM Technology
        JOIN ProjectTechnology ON Technology.TechnologyId = ProjectTechnology.TechnologyId
        WHERE ProjectTechnology.ProjectId = @ProjectId";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);

                List<Technology> technologies = new List<Technology>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Technology technology = new Technology
                        {
                            Id = (Guid)reader["TechnologyId"],
                            Name = reader["Name"].ToString(),
                            CreatedDateTime = (DateTime)reader["CreatedDateTime"],
                            UpdatedDateTime = reader["UpdatedDateTime"] != DBNull.Value ? (DateTime?)reader["UpdatedDateTime"] : null
                        };

                        technologies.Add(technology);
                    }
                }

                return technologies;
            }
        }


        public IEnumerable<ProjectTechnology> GetProjectTechnologiesByProjectId(Guid projectId)
        {
            List<ProjectTechnology> projectTechnologies = new List<ProjectTechnology>();

            string query = "SELECT * FROM ProjectTechnology WHERE ProjectId = @ProjectId";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProjectTechnology projectTechnology = new ProjectTechnology
                        {
                            TechnologyId = (Guid)reader["TechnologyId"],
                            ProjectId = (Guid)reader["ProjectId"]
                        };

                        projectTechnologies.Add(projectTechnology);
                    }
                }
            }

            return projectTechnologies;
        }

    }
}
