using System;

namespace Viagem.Models
{
    public class PacotesTuristicos
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string  Origem { get; set; }
        public string Destino { get; set; }
        public string Atrativos { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string Usuario { get; set; }
    }
}