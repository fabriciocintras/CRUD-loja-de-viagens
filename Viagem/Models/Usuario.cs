using System;

namespace Viagem.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
    }
}