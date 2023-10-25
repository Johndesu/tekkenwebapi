using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await gameRepository.GetAllAsync();

            var response = new List<GameDto>();

            foreach (var game in games)
            {
                response.Add(new GameDto
                {
                    Id = game.Id,
                    Description = game.Description,
                    StartggId = game.StartggId,
                    ChallongeId = game.ChallongeId,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var existingGame = await gameRepository.GetById(id);

            if (existingGame != null)
            {
                var response = new GameDto
                {
                    Id = existingGame.Id,
                    Description = existingGame.Description,
                    StartggId = existingGame.StartggId,
                    ChallongeId = existingGame.ChallongeId,
                };
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateGame(CreateGameRequestDto request)
        {
            //Map DTO to Domain Model

            var game = new Game
            {
                Description = request.Description,
                StartggId = request.StartggId,
                ChallongeId = request.ChallongeId,
            };

            await gameRepository.CreateAsync(game);

            var response = new GameDto
            {
                Description = game.Description,
                StartggId = game.StartggId,
                ChallongeId = game.ChallongeId,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateGame(int id, UpdateGameRequestDto request)
        {
            // Convert DTO to Domain Model
            var game = new Game
            {
                Id = id,
                Description = request.Description,
                StartggId = request.StartggId,
                ChallongeId = request.ChallongeId,
            };

            game = await gameRepository.UpdateAsync(game);

            if (game == null)
            {
                return NotFound();
            }

            var response = new GameDto
            {
                Id = game.Id,
                Description = game.Description,
                StartggId = game.StartggId,
                ChallongeId = game.ChallongeId,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await gameRepository.DeleteAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var response = new GameDto
            {
                Id = game.Id,
                Description = game.Description,
                StartggId = game.StartggId,
                ChallongeId = game.ChallongeId,
            };

            return Ok(response);
        }
    }
}
