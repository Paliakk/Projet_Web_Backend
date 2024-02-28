namespace Domain.Models
{
    public class LocalUser
    {
        public int LocalUserId { get; set; }
        public string? LocalUserUsername { get; set; }
        public string? LocalUserPassword { get; set; }  

        public string? Role { get; set; }

    }
}
