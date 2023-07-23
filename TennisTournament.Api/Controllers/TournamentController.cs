using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TennisTournament.Api.DTOs;
using TennisTournament.Domain;
using TennisTournament.Domain.Gender;
using TennisTournament.Infra.Repositories.Interfaces;

namespace TennisTournament.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {

        private readonly ILogger<TournamentController> _logger;
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentController(ILogger<TournamentController> logger, IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
        }

        [Route("Male")]
        [HttpPost]
        public async Task<MalePlayerDTO> PlayMaleTournament(List<MalePlayerDTO> players)
        {
            Player winner = await CreateAndPlayTournament(_mapper.Map<List<Player>>(players), PlayerGender.Male);

            return _mapper.Map<MalePlayerDTO>(winner);
        }

        [Route("Male")]
        [HttpGet]
        public List<TournamentDTO> GetMaleTournaments()
        {
            var tournaments = _tournamentRepository.GetMaleTournaments();

            return _mapper.Map<List<TournamentDTO>>(tournaments);
        }

        [Route("Female")]
        [HttpPost]
        public async Task<FemalePlayerDTO> PlayFemaleTournament(List<FemalePlayerDTO> players)
        {
            Player winner = await CreateAndPlayTournament(_mapper.Map<List<Player>>(players), PlayerGender.Female);

            return _mapper.Map<FemalePlayerDTO>(winner);
        }

        [Route("Female")]
        [HttpGet]
        public List<TournamentDTO> GetFemaleTournaments()
        {
            var tournaments = _tournamentRepository.GetFemaleTournaments();

            return _mapper.Map<List<TournamentDTO>>(tournaments);
        }

        private async Task<Player> CreateAndPlayTournament(List<Player> players, PlayerGender gender)
        {
            var tournament = new Tournament() { Gender = gender };
            var winner = tournament.PlayTournament(players);

            await _tournamentRepository.SaveTournamentAsync(tournament);

            return winner;
        }

        [HttpGet]
        public List<TournamentDTO> GetTournaments()
        {
            var tournaments = _tournamentRepository.GetTournaments();

            return _mapper.Map<List<TournamentDTO>>(tournaments);
        }
    }
}