namespace GameBackend.Models
{
    public class MatchResponse
    {
        public bool Matched { get; set; }
        public string? MatchId { get; set; }
        public string[]? Players { get; set; }
    }
}
