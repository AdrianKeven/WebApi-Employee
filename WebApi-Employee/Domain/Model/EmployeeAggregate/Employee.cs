using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Employee.Domain.Model.EmployeeAggregate
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Photo { get; set; }

        public Employee() { }

        public Employee(string name, int age, string? photo)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Age = age;
            this.Photo = photo;
        }
    }
}
