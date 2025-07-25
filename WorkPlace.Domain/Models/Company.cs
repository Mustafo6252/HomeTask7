namespace WorkPlace.Domain;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}