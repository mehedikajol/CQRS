using CQRS.Core.Entities;
using CQRS.Core.Repositories.Query;
using CQRS.Infrastructure.Repositories.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CQRS.Infrastructure.Repositories.Query
{
    public class CustomerQueryRepository : QueryRepository<Customer>, ICustomerQueryRepository
    {
        protected CustomerQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyList<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Customer>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("id", id, DbType.Guid);

                using (var connection = CreateConnection())
                {
                    return await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Email = @email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);

                using (var connection = CreateConnection())
                {
                    return await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
