namespace PayTime.Application.Dtos
{
    public class PaycheckDto
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public int NumOfDependents { get; set; }
        public int NumOfDiscounts { get; set; }
        public double GrossSalary => 2000D;
        public double DeductionAmount => (1000 / 26) + (NumOfDependents * (500 / 12)) * (1 - (0.10 * NumOfDiscounts));
        public double NetSalary { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

    }
}
