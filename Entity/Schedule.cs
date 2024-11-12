using System.ComponentModel.DataAnnotations;
using burulas.Entity;

public class Schedule
{
    [Key]
    public int Id { get; set; }
    public string Day { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
}