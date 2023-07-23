namespace TennisTournament.Domain.Gender
{
    public class MaleStrengths : IGenderStrengths
    {
        public int Power { get; }
        public int Speed { get; }

        public MaleStrengths(int power, int speed)
        {
            Power = power;
            Speed = speed;
        }

        public int GetAdditionalStrengths()
        {
            return Power + Speed;
        }
    }
}
