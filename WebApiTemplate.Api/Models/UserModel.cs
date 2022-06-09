namespace WebApiTemplate.Api.Models
{
    //this is the base model for our user that will be used to create the database and
    //retrieve the information from the database to use in your APP
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}
