using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Data.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
