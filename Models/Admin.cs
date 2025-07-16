namespace e_commerce_api.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public bool Incart { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }

    }

}
