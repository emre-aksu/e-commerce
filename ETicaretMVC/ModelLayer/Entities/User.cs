using Infrastructure.Model;

namespace ModelLayer.Entities
{
    public class User : AuditableEntity<int>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
