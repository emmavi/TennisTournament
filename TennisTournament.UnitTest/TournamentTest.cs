using TennisTournament.Domain;
using TennisTournament.Domain.Gender;
using Xunit;

namespace TennisTournament.UnitTest
{
    public class TournamentTest
    {
        [Fact]
        public void TestMaleTournament()
        {
            var players = new List<Player>()
            {
                new Player("Player 1", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 2", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 3", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 4", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 5", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 6", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 7", PlayerGender.Male, 1, 1, new MaleStrengths(1, 2)),
                new Player("Player 8", PlayerGender.Male, 11, 11, new MaleStrengths(1, 2))

            };

            var tournament = new Tournament();
            var winner = tournament.PlayTournament(players);

            Assert.NotNull(winner);
            Assert.True(winner.Name == "Player 8");
        }
        [Fact]
        public void TestFemaleTournament()
        {
            var players = new List<Player>()
            {
                new Player("Player 1", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 2", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 3", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 4", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 5", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 6", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 7", PlayerGender.Female, 1, 1, new FemaleStrengths(1)),
                new Player("Player 8", PlayerGender.Female, 11, 11, new FemaleStrengths(1))                                       
            };

            var tournament = new Tournament();
            var winner = tournament.PlayTournament(players);

            Assert.NotNull(winner);
            Assert.True(winner.Name == "Player 8");
        }
    }
}