using CRUD_MVC.Data.Entities;

namespace CRUD_MVC.Services.Contracts
{
    public interface IPlayersService: IBaseService
    {
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetById(int id);

        Task AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void RemovePlayer(Player player);
    }
}
