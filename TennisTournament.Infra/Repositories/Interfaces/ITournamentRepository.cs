using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Domain;

namespace TennisTournament.Infra.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Task SaveTournamentAsync(Tournament tournament);
        List<Tournament> GetTournaments();
        List<Tournament> GetMaleTournaments();
        List<Tournament> GetFemaleTournaments();
    }
}
