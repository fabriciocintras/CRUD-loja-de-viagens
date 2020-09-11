using System.Collections.Generic;
using MySqlConnector;

namespace Viagem.Models
{
    public class MensagemBanco
    {
         private const string dadosConexao = "Database=Viagem; Data Source= localhost;User Id= root";

        public void Inserir(Mensagem novaMensagem)
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);

            Conexao.Open();

            string query = "INSERT INTO MensagemFaleConosco(Nome,Contato,Texto) VALUES (@Nome,@Contato, @Texto)";

            MySqlCommand comando = new MySqlCommand(query,Conexao);

            comando.Parameters.AddWithValue("@Nome", novaMensagem.Nome);
            comando.Parameters.AddWithValue("@Contato", novaMensagem.Contato);
            comando.Parameters.AddWithValue("@Texto", novaMensagem.Texto);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }

         public List<Mensagem> Buscar()
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);
            Conexao.Open();
            string query = "SELECT * FROM MensagemFaleConosco";
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            List<Mensagem> listaMensagem = new List<Mensagem>();
            while (reader.Read())
            {
                Mensagem user = new Mensagem();
                user.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                {
                    user.Nome = reader.GetString("Nome");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Contato")))
                {
                    user.Contato = reader.GetString("Contato");
                }
                if(!reader.IsDBNull(reader.GetOrdinal("Texto")))
                {
                    user.Texto = reader.GetString("Texto");
                }
               
                listaMensagem.Add(user);
                
            }
            Conexao.Close();
            return listaMensagem;
        }


    }
}