using System.Collections.Generic;
using MySqlConnector;

namespace Viagem.Models
{
    public class PacotesTuristicosBanco
    {
         private const string dadosConexao = "Database=Viagem; Data Source= localhost;User Id= root";

        public void Inserir(PacotesTuristicos novoPacote, int idUsuario)
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);

            Conexao.Open();

            string query = "INSERT INTO PacotesTuristicos(Nome,Origem, Destino, Atrativos, DataSaida, DataRetorno, Usuario) VALUES (@Nome,@Origem, @Destino, @Atrativos, @DataSaida, @DataRetorno, @Usuario)";

            MySqlCommand comando = new MySqlCommand(query,Conexao);

            comando.Parameters.AddWithValue("@Nome", novoPacote.Nome);
            comando.Parameters.AddWithValue("@Origem", novoPacote.Origem);
            comando.Parameters.AddWithValue("@Destino", novoPacote.Destino);
            comando.Parameters.AddWithValue("@Atrativos", novoPacote.Atrativos);
            comando.Parameters.AddWithValue("@DataSaida", novoPacote.DataSaida);
            comando.Parameters.AddWithValue("@DataRetorno", novoPacote.DataRetorno);
            comando.Parameters.AddWithValue("@Usuario", idUsuario);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<PacotesTuristicos> BuscarTodos()
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);
            Conexao.Open();

            string query = "SELECT PacotesTuristicos.*, Usuario.Nome as  NomeUsuario FROM PacotesTuristicos LEFT JOIN Usuario ON PacotesTuristicos.Usuario = Usuario.Id";
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            List<PacotesTuristicos> lista = new List<PacotesTuristicos>();
            while (reader.Read())
            {
                PacotesTuristicos pacote = new PacotesTuristicos();
                pacote.Id = reader.GetInt32("id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                {
                    pacote.Nome = reader.GetString("Nome");
                }

                if(!reader.IsDBNull(reader.GetOrdinal("NomeUsuario")))
                {
                    pacote.Usuario = reader.GetString("NomeUsuario");
                }
                
                if(!reader.IsDBNull(reader.GetOrdinal("Origem")))
                {
                    pacote.Origem = reader.GetString("Origem");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Destino")))
                {
                    pacote.Destino = reader.GetString("Destino");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Atrativos")))
                {
                    pacote.Atrativos = reader.GetString("Atrativos");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("DataSaida")))
                {
                    pacote.DataSaida = reader.GetDateTime("DataSaida");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("DataRetorno")))
                {
                    pacote.DataRetorno = reader.GetDateTime("DataRetorno");
                }
                lista.Add(pacote);
                
            }
            Conexao.Close();
            return lista;
        }

        public List<PacotesTuristicos> MostrarPacotes()
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);
            Conexao.Open();

            string query = "SELECT * FROM PacotesTuristicos";
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            List<PacotesTuristicos> lista = new List<PacotesTuristicos>();
            while (reader.Read())
            {
                PacotesTuristicos pacote = new PacotesTuristicos();
                pacote.Id = reader.GetInt32("id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                {
                    pacote.Nome = reader.GetString("Nome");
                }

               
                
                if(!reader.IsDBNull(reader.GetOrdinal("Origem")))
                {
                    pacote.Origem = reader.GetString("Origem");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Destino")))
                {
                    pacote.Destino = reader.GetString("Destino");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Atrativos")))
                {
                    pacote.Atrativos = reader.GetString("Atrativos");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("DataSaida")))
                {
                    pacote.DataSaida = reader.GetDateTime("DataSaida");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("DataRetorno")))
                {
                    pacote.DataRetorno = reader.GetDateTime("DataRetorno");
                }
                lista.Add(pacote);
                
            }
            Conexao.Close();
            return lista;
        }

    }
}