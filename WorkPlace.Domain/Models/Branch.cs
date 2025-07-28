namespace WorkPlace.Domain;

public class Branch
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;

    // Foreign key
    public int CompanyId { get; set; }

    // Navigation properties
    public Company Companies { get; set; } = default!;
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}