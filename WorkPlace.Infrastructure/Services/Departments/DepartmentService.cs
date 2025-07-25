using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

namespace WorkPlace.Infrastructure.Services.Departments;

public class DepartmentService: IDepartmentService
{
    private readonly NpgsqlConnection npgsqlconnection;
    private const string connectionString =
        "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";
    
    public async Task<Department> AddDepartmentAsync(Department department)
    {
        using var connection=new NpgsqlConnection(connectionString);
        var insertSql =
            """
            Insert into Department(id,name,companyId)
            values(@id, @name, @companyId)
            """;
        await connection.ExecuteAsync(insertSql, department);
        return (department);
    }

    public async Task<List<Department>> GetAllDepartmentAsync()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var selectSql = "SELECT * FROM Department";
        var departments = await connection.QueryAsync<Department>(selectSql);
        return (departments.ToList());
    }

    public async Task<Department> UpdateDepartmentAsync(int id, Department department)
    {
        using var connection=new NpgsqlConnection(connectionString);
        var updateSql =
            """
            update Department
            Set name=@name, companyId=@companyId
            where id=@id
            """;
        await connection.ExecuteAsync(updateSql, department);
        return (department);
    }

    public async Task<Department> DeleteDepartmentAsync(int id)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var deleteSql = "DELETE FROM Department WHERE id=@id";
        var department=await connection.QueryFirstOrDefaultAsync(deleteSql, new { id });
        return (department);
    }
}