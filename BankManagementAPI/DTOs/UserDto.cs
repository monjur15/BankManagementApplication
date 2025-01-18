namespace BankManagementAPI.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UserDto2
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
