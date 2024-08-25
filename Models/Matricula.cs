namespace ProvaMVC.Models
{
    public class Matricula
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public string Status { get; set; }
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }

        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
    }
}
