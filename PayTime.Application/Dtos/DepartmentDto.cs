using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTime.Application.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentDto()
        {
            var jobTitles = new ReadOnlyCollection<DepartmentDto>(new List<DepartmentDto>()
            {
                new DepartmentDto()
                {
                    Id = 1,
                    Name = "Executive"
                },
                new DepartmentDto()
                {
                    Id = 2,
                    Name = "Finance"
                },
                new DepartmentDto()
                {
                    Id = 3,
                    Name = "Marketing"
                },
                new DepartmentDto()
                {
                    Id = 4,
                    Name = "IT"
                }
            });
        }
    }
}
