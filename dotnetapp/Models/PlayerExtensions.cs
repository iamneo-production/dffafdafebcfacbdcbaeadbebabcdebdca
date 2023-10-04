namespace dotnetapp.Models
{
    public partial class Player
    {
        // Define the navigation property to the related Position entity
        public Position Position { get; set; }
    }
}
