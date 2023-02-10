using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTime.Application.Dtos
{
    public class JobTitleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public JobTitleDto() 
        {
            var jobTitles = new ReadOnlyCollection<JobTitleDto>(new List<JobTitleDto>()
            {
                new JobTitleDto()
                {
                    Id = 1,
                    Title = "Manager"
                },
                new JobTitleDto()
                {
                    Id = 2,
                    Title = "Accountant"
                },
                new JobTitleDto()
                {
                    Id = 3,
                    Title = "Clerk"
                },
                new JobTitleDto()
                {
                    Id = 4,
                    Title = "Engineer"
                }
            });
        }
    }
}
