namespace TravelDestination.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Destination { get; set; }
    public string Country { get; set; }

    public string City { get; set; }

    public int Rating { get; set; }
  }
}