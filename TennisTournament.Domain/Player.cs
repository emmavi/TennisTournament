using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Domain.Gender;

namespace TennisTournament.Domain
{
    public  class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerGender Gender { get; set; }
        public int Skill { get; set; }
        public int Luck { get; set; }
        public IGenderStrengths GenderStrengths { get; set; }
        public IEnumerable<Tournament> Tournaments { get; set; }

        public Player() { }
        public Player(string name, PlayerGender gender, int skill,int luck, IGenderStrengths genderStrengths)
        {
            Name = name;
            Gender = gender;
            Skill = skill;
            Luck = luck;
            GenderStrengths = genderStrengths;
        }


        public int GetScore() => Skill + Luck + GenderStrengths.GetAdditionalStrengths();
    }
}
