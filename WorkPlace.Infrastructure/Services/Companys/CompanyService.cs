using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;

namespace WorkPlace.Infrastructure.Services.Companys;
using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

public class CompanyService : ICompanyService
{
    private readonly NpgsqlConnection npgsqlConnection;
    private const string connectionString =
        "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";

    public async Task<Company> AddCompanyAsync(Company company)
    {
        using var connection= new NpgsqlConnection(connectionString);
        var insertSql =
            """
            Insert into Company(id,name)
            values(@id, @name)
            """;
        await connection.ExecuteAsync(insertSql, company);
        return (company);
    }

    public async Task<List<Company>> GetCompaniesAsync()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var selectSql = "select * from Company";
        var result = await connection.QueryAsync<Company>(selectSql);
        return result.ToList();
    }

    public async Task<Company> UpdateCompanyAsync(int id, Company company)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var updateSql =
            """
            Update Company
            Set name = @name
            Where id = @id
            """;
        await connection.ExecuteAsync(updateSql,  company);
        return (company);
    }

    public async Task<Company> DeleteCompanyAsync(int id)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var deleteSql="delete from Company where id = @id";
        var company = await connection.QueryFirstOrDefaultAsync(deleteSql, new { id });

        return (company);
    }

}