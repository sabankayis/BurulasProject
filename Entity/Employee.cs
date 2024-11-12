using System.ComponentModel.DataAnnotations;

namespace burulas.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();

    }
}