namespace PayTime.Application.Dtos
{
    public class PayrollDto
    {
        public Guid Id { get; set; }
        public List<PaycheckDto> Paychecks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
