using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Domain;
using TennisTournament.Infra.Repositories.Interfaces;
using TennisTournament.Domain.Gender;

namespace TennisTournament.Infra.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentContext _tournamentContext;
        private DbSet<Tournament> Tournaments => _tournamentContext.Tournaments;
        public TournamentRepository(TournamentContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public List<Tournament> GetTournaments() => Tournaments.Include(x => x.Winner).ToList();

        public List<Tournament> GetMaleTournaments() => Tournaments.Where(x => x.Gender == PlayerGender.Male).Include(x => x.Winner).ToList();

        public List<Tournament> GetFemaleTournaments() => Tournaments.Where(x => x.Gender == PlayerGender.Female).Include(x => x.Winner).ToList();

        public async Task SaveTournamentAsync(Tournament tournament)
        {
            _tournamentContext.Tournaments.Add(tournament);
            await _tournamentContext.SaveChangesAsync();
        }
    }
}
