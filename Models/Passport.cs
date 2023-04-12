namespace FSP_Return_Task3.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string? PassportNumber { get; set; }

        public DateTime ValidDate { get; set; }
        public Passenger? Passenger { get; set; }
    }
}


