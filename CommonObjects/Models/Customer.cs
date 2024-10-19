 
namespace Common.Entities
{
    public class Customer
    {
        public Guid? Id { get; set; } 
 
        public string? Name { get; set; } 
 
        public string? PhoneNumber { get; set; }
       
        public string? Town { get; set; }
      
        public string? YourReference { get; set; } 
       
        public string? Comments { get; set; }
        public Customer() { }
        public Customer(Guid? id, string name, string? phoneNumber, string town, string? yourReference, string? comments)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Town = town;
            YourReference = yourReference;
            Comments = comments;
        }



    }
 
 
}
