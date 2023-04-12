namespace FSP_Return_Task3.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Passport? Passport { get; set; }
    }
}
