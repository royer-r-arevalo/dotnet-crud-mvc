using CRUD_MVC.Data;
using CRUD_MVC.Services.Contracts;

namespace CRUD_MVC.Services
{
    public class BaseService
    {
        protected AppDbContext _db;

        public BaseService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Save()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
