using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Domain
{
    public  class Match
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public Match(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Player Play() => _player1.GetScore() > _player2.GetScore() ? _player1 : _player2; 
    }
}
