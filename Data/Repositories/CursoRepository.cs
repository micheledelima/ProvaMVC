using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Data.Repositories
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
