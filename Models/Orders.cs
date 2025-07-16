namespace e_commerce_api.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
      
    }
}
