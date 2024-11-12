using System.ComponentModel.DataAnnotations;
using burulas.Entity;

public class DayAndEmployeeIds
{
    [Required]
    public int dayId { get; set; }  // EmployeeId'yi almak için
    [Required]
    public int employeId { get; set; }  // FirstName'yi almak için
}