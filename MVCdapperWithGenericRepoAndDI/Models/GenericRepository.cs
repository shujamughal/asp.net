using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
namespace MVCdapperWithGenericRepoAndDI.Models
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly string _connectionString;

		public GenericRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public void Add(TEntity entity)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				var properties = GetProperties(entity).ToArray();
				var columnNames = string.Join(", ", properties.Select(p => p.Name));
				var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));
				var query = $"INSERT INTO {typeof(TEntity).Name}s ({columnNames}) VALUES ({parameterNames})";
				connection.Execute(query, entity);
			}
		}

		public TEntity GetById(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				return connection.QueryFirstOrDefault<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s WHERE Id = @Id", new { Id = id });
			}
		}

		public IEnumerable<TEntity> GetAll()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				return connection.Query<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s");
			}
		}

		public void Update(TEntity entity)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				var properties = GetProperties(entity).Where(p => p.Name != "Id").ToArray();
				var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
				var query = $"UPDATE {typeof(TEntity).Name}s SET {setClause} WHERE Id = @Id";
				connection.Execute(query, entity);
			}
		}

		public void Delete(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				connection.Execute($"DELETE FROM {typeof(TEntity).Name}s WHERE Id = @Id", new { Id = id });
			}
		}

		private IEnumerable<System.Reflection.PropertyInfo> GetProperties(TEntity entity)
		{
			return typeof(TEntity).GetProperties().Where(prop => prop.CanWrite && prop.Name != "Id");
		}
	}
}
