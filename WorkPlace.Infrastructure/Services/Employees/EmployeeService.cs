using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Employees;

namespace WorkPlace.Infrastructure.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly NpgsqlConnection npgsqlConnection;
    private const string connectionString =
        "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";

    public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee employee)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var insertSql =
            """
            Insert into Employee(id, firstName, lastName, email, departmentId, branchId)
            Values(@id, @firstName, @lastName, @email, @departmentId, @branchId)
            """;
        await connection.ExecuteAsync(insertSql, employee);
        return (employee);
    }

    public async Task<ActionResult<List<Employee>>> GetAllEmployeesAsync()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var selectSql = "SELECT * FROM Employee";
        var employee = await connection.QueryAsync<Employee>(selectSql);
        return (employee.ToList());
    }

    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var updateSql =
            """"
                UPDATE Employee
                SET firstName = @firstName,
                lastName = @lastName,
                email = @email,
                departmentId = @departmentId,
                branchId = @branchId
                WHERE id = @id
            """";
        await connection.ExecuteAsync(updateSql, employee);
        return (employee);
    }

    public async Task<ActionResult<Employee>> DeleteEmployeeAsync(int id)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var deleteSql = "DELETE FROM Employee WHERE id=@id";
        var employee=await connection.QueryFirstOrDefaultAsync(deleteSql, new { id });
        return (employee);
    }
}