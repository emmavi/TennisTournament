using TennisTournament.Domain.Gender;
using TennisTournament.Domain;

namespace TennisTournament.Api.DTOs
{
    public class TournamentDTO
    {
        public string Gender { get; set; } 
        public DateTime PlayedDateTime { get; set; }
        public string Winner { get; set; }
    }
}
