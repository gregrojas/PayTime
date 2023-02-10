using System.Collections.ObjectModel;

namespace PayTime.Application.Dtos
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public bool ApplyDiscount
        {
            get
            {
                if (!String.IsNullOrEmpty(FirstName))
                {
                    return FirstName.Substring(0, 1) == "A" ? true : false;
                }
                return false;
            }
        }

        public EmployeeDto()
        {   
            var employees = new ReadOnlyCollection<EmployeeDto>(new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Id = "A1",
                    FirstName = "John",
                    LastName = "Smith",
                    JobTitleId= 1,
                    DepartmentId= 1,
                    Address = "Address1",
                    City = "City1",
                    State = "State1",
                    PostalCode = "Zip1",
                    Country = "US",
                    Email = "jsmith@gmail.com"
                },
                new EmployeeDto()
                {
                    Id = "A2",
                    FirstName = "Sally",
                    LastName = "Jones",
                    JobTitleId= 3,
                    DepartmentId= 2,
                    Address = "Address2",
                    City = "City2",
                    State = "State2",
                    PostalCode = "Zip2",
                    Country = "US",
                    Email = "sjones@gmail.com"
                },
                new EmployeeDto()
                {
                    Id = "A3",
                    FirstName = "Bill",
                    LastName = "Thompson",
                    JobTitleId= 2,
                    DepartmentId= 4,
                    Address = "Address3",
                    City = "City3",
                    State = "State3",
                    PostalCode = "Zip3",
                    Country = "US",
                    Email = "bthompson@gmail.com"
                }
            });
        }
    }
}