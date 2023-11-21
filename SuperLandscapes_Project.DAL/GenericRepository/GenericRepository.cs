using SuperLandscapes_Project.DAL.Entities.Base;
using SuperLandscapes_Project.DAL.GenericRepository.Interface;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace SuperLandscapes_Project.DAL.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly SqlConnection _connection;
        protected readonly IDbTransaction _transaction;
        protected readonly string _table;

        public GenericRepository(SqlConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;
            _transaction = transaction;
            _table = table;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            string query = GenerateInsertQuery();
            var task = await _connection.ExecuteAsync(query, param: entity, transaction: _transaction);
            var result = await GetByIdAsync(entity.Id);

            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            string query = $"DELETE From {_table} where Id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id }, transaction: _transaction);
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            string query = $"Select * From {_table}";
            var result = await _connection.QueryAsync<TEntity>(query, transaction: _transaction);
            return result;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            string query = $"Select * From {_table} where Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<TEntity>(query, param: new { Id = id }, transaction: _transaction);
            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entity1 = await GetByIdAsync(entity.Id);
            if (entity1 == null)
            {
                throw new Exception();
            }
            string query = GenerateUpdateQuery();
            await _connection.ExecuteAsync(query, param: entity, transaction: _transaction);
            var result = await GetByIdAsync(entity.Id);
            return result;
        }
        private string GenerateInsertQuery()
        {
            var builder = new StringBuilder($"Insert into {_table}");
            builder.Append(" (");

            var properties = ListProperties(typeof(TEntity).GetProperties());
            properties.ForEach(property => { builder.Append($"[{property}],"); });

            builder.Remove(builder.Length - 1, 1).Append(") Values (");

            properties.ForEach(property => { builder.Append($"@{property},"); });

            builder.Remove(builder.Length - 1, 1).Append(")");

            return builder.ToString();
        }
        private string GenerateUpdateQuery()
        {
            var builder = new StringBuilder($"Update {_table} set ");
            var properties = ListProperties(typeof(TEntity).GetProperties());

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    builder.Append($"{property} = @{property},");
                }
            });

            builder.Remove(builder.Length - 1, 1).Append(" Where Id = @Id");

            return builder.ToString();
        }

        private static List<string> ListProperties(IEnumerable<PropertyInfo> list_Properties)
        {
            return (from property in list_Properties
                    let attributes =
                property.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 ||
                (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select property.Name).ToList();
        }
    }
}
