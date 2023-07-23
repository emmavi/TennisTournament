using TennisTournament.Domain.Gender;

namespace TennisTournament.Domain
{
    public class Tournament
    {
        public int Id { get; set; }
        public List<Player> Players { get; set; }
        public PlayerGender Gender { get; set; } = PlayerGender.Male;
        public DateTime PlayedDateTime { get; set; }
        public Player Winner { get; set; }
        public int WinnerId { get; set; }

        public Player PlayTournament(List<Player> players)
        {
            Players = players;
            PlayedDateTime = DateTime.Now;
            List<Player> currentRoundPlayers = new List<Player>(Players);

            while (currentRoundPlayers.Count > 1)
            {
                List<Player> nextRoundPlayers = new();

                int matchesPerRound = currentRoundPlayers.Count / 2;
                for (int i = 0; i < matchesPerRound; i++)
                {
                    var player1 = GetRandomPlayerFromPool(currentRoundPlayers);
                    var player2 = GetRandomPlayerFromPool(currentRoundPlayers);
                    var match = new Match(player1, player2);

                    var winner = match.Play();
                    nextRoundPlayers.Add(winner);
                }

                currentRoundPlayers = nextRoundPlayers;
            }

            Winner = currentRoundPlayers.First();

            return Winner;
        }

        private Player GetRandomPlayerFromPool(List<Player> poolOfPlayers) 
        {
            Random rnd = new Random();
            int index = rnd.Next(poolOfPlayers.Count);

            var selectedPlayer = poolOfPlayers[index];
            poolOfPlayers.RemoveAt(index);

            return selectedPlayer;
        }
    }
}