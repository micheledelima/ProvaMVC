﻿namespace ProvaMVC.Models
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int MaxAlunos { get; set; } = 30; 
    }
}
