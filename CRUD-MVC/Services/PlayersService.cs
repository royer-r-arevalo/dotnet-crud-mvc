using CRUD_MVC.Data;
using CRUD_MVC.Data.Entities;
using CRUD_MVC.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Services
{
    public class PlayersService : BaseService, IPlayersService 
    {
        public PlayersService(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Player>> GetAll() => await _db.Players.AsNoTracking().ToListAsync();
        public async Task<Player> GetById(int id) => await _db.Players.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddPlayer(Player player)
        {
            var currentDateTime = DateTime.Now;
            player.CreatedAt = currentDateTime;
            player.UpdatedAt = currentDateTime;
            await _db.Players.AddAsync(player);
        }

        public void UpdatePlayer(Player player)
        {
            player.UpdatedAt = DateTime.Now;
            _db.Players.Update(player);
        }

        public void RemovePlayer(Player player)
        {
            _db.Players.Remove(player);
        }
    }
}
