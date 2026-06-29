using System.ComponentModel;

namespace SampleEmployeesManagementSystem.Models;

public class Employee
{
    public int Id { get; set; }

    [DisplayName("First Name")]
    public required string FistName { get; set; }

    [DisplayName("Middle Name")]
    public required string MiddleName { get; set; }

    [DisplayName("Last Name")]
    public required string LastName { get; set; }

    [DisplayName("Email Address")]
    public required string EmailAddress { get; set; }

    [DisplayName("Address")]
    public required string Address { get; set; }

    [DisplayName("Country Name")]
    public required string Country { get; set; }

    [DisplayName("Gender")]
     public required string Gender { get; set; }


    [DisplayName("Full Name")]
     public string FullName => $"{FistName} {MiddleName} {LastName}";

    [DisplayName("Ethnicity")]
     public string Ethnicity { get; set; }
}
