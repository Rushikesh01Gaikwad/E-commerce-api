namespace e_commerce_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
        public string? Password { get; set; }
        public ICollection<Orders>? Orders { get; set; } = new List<Orders>();
    }
}
