namespace WorkPlace.Domain;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int BranchId { get; set; }
    public int DepartmentId { get; set; }
    // public Department Department { get; set; } = default!;
    //
    //
    //
    // public Branch Branch { get; set; } = default!;
}