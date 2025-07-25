using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;


namespace WorkPlace.Infrastructure.Services.Branches;

public class BranchService: IBranchService
{
    private readonly NpgsqlConnection npgsqlConnection;

    private const string connectionString =
        "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";

    public async Task<Branch> AddBranchAsync(Branch branch)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var insertSql =
            """
            Insert into Branch(id,location,companyId)
            Values(@id, @location, @companyId)
            """;
        await connection.ExecuteAsync(insertSql, branch);
        return (branch);
    }

    public async Task<List<Branch>> GetAllBranchesAsync()
    {
        using var connection=new NpgsqlConnection(connectionString);
        var selectSql="Select * from Branch";
        var branches = await connection.QueryAsync<Branch>(selectSql);
        return branches.ToList();
    }

    public async Task<Branch> UpdateBranchAsync(int id, Branch branch)
    {
        using var connection=new NpgsqlConnection(connectionString);
        var updateSql =
            """
            Update Branch
            Set location=@location, companyId=@companyId
            Where id=@id
            """;
        await connection.ExecuteAsync(updateSql, branch);
        return (branch);
    }

    public async Task<Branch> DeleteBranchAsync(int id)
    {   
        using var connection=new NpgsqlConnection(connectionString);
        var deleteSql = "Delete from Branch where id=@id";
        var branch=await connection.QueryFirstOrDefaultAsync(deleteSql, new { id });
        return (branch);
    }
}