using Azure;
using CRUD_MVC.Data.Entities;
using CRUD_MVC.Models;
using CRUD_MVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class PlayersController : Controller
    {
        readonly IPlayersService _playerService;

        public PlayersController(IPlayersService playersService)
        {
            _playerService = playersService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Player> players = await _playerService.GetAll();
            IEnumerable<PlayerViewModel> viewModels = players.Select(player => new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name,
                CurrentTeam = player.CurrentTeam,
                GoldenBoots = player.GoldenBoots,
            });
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            Player player = await _playerService.GetById(id);
            PlayerViewModel viewModel = new()
            {
                Id = player.Id,
                Name = player.Name,
                CurrentTeam = player.CurrentTeam,
                GoldenBoots = player.GoldenBoots,
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerViewModel viewModel)
        {   
            if (!ModelState.IsValid)
            {
                return View(viewModel);

            }
            Player player = new()
            {
                Name = viewModel.Name,
                CurrentTeam = viewModel.CurrentTeam,
                GoldenBoots = viewModel.GoldenBoots ?? 0,
            };
            await _playerService.AddPlayer(player);
            await _playerService.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Player player = await _playerService.GetById(id);
            PlayerViewModel viewModel = new()
            {
                Id = player.Id,
                Name = player.Name,
                CurrentTeam = player.CurrentTeam,
                GoldenBoots = player.GoldenBoots,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(PlayerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            Player player = await _playerService.GetById(viewModel.Id);
            player.Name = viewModel.Name;
            player.CurrentTeam = viewModel.CurrentTeam;
            player.GoldenBoots  = viewModel.GoldenBoots ?? 0;
            _playerService.UpdatePlayer(player);
            await _playerService.Save();
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            Player player = await _playerService.GetById(id);
            PlayerViewModel viewModel = new()
            {
                Id = player.Id,
                Name = player.Name,
                CurrentTeam = player.CurrentTeam,
                GoldenBoots = player.GoldenBoots,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(PlayerViewModel viewModel)
        {
            Player player = await _playerService.GetById(viewModel.Id);
            _playerService.RemovePlayer(player);
            await _playerService.Save(); 
            return View(viewModel);
        }
    }
}
