namespace PinewoodApi.Models
{
    public class CustomerDto
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Town { get; set; }
        public string? YourReference { get; set; }
        public string? Comments { get; set; }
    }
}
