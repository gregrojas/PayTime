using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PayTime.Application.Dtos
{
    public class DependentDto
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Relation { get; set; }

        public enum RelationToEmployee
        {
            Spouse,
            Child
        }

        public string EmployeeId { get; set; }

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
    }
}
