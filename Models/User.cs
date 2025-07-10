namespace TaskManagerAPI1.Models
{
    public enum Role { Admin, User }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }

}
