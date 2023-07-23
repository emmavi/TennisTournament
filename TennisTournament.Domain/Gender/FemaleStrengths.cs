namespace TennisTournament.Domain.Gender
{
    public class FemaleStrengths : IGenderStrengths
    {
        public int ReactionTime { get; }

        public FemaleStrengths(int reactionTime)
        {
            ReactionTime = reactionTime;
        }


        public int GetAdditionalStrengths()
        {
            return ReactionTime;
        }
    }
}
