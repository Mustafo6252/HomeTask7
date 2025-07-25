namespace WorkPlace.Domain;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Foreign key
    public int CompanyId { get; set; }

    // Navigation properties
    // public Company Company { get; set; } = default!;
    // public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}