using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Data.Repositories
{
    public class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
