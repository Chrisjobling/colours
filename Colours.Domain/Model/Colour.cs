namespace Colours.Domain.Model
{
    public class Colour
    {
        public Colour(int colourId, string name, bool isEnabled)
        {
            ColourId = colourId;
            Name = name;
            IsEnabled = isEnabled;
        }

        public int ColourId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
