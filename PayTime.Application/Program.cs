using PayTime.Application.Dtos;
using System.Text.Json;

namespace PayTime.Application
{
    public class Program
    {
        public static async Task Main()
        {
            var dependent = new DependentDto
            {
                Id = Guid.NewGuid(),
                EmployeeId = "A1",
                FirstName = "FirstName",
                LastName = "LastName",
                Relation = 0
            };

            string fileName = "Dependents.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, dependent);
            await createStream.DisposeAsync();

            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}