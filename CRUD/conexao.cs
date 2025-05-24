using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CRUD
{
    public class conexao
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=!to5ebrc;Database=empresa";
        private NpgsqlConnection connection;
        public conexao()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public void conectar()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão aberta com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir a conexão: " + ex.Message);
            }
        }

        public void desligar()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Conexão fechada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
            }
        }

        public void inserir(Funcionario funcionario)
        {
            string query = "INSERT INTO funcionario(nome, idade) VALUES (@nome, @idade)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("nome", funcionario.nome);
                command.Parameters.AddWithValue("idade", funcionario.idade);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Funcionário inserido com sucesso!");
        }

        public void leitura()
        {
            string query = "SELECT * FROM funcionario";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, Idade: {reader["idade"]}");
                    }
                }
            }
        }

        public void demitir(int id)
        {
            string query = "DELETE FROM funcionario WHERE id = @id";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Funcionário deletado com sucesso!");
        }
        
        public void atualizar(Funcionario funcionario, int id)
        {
            string query = "UPDATE funcionario SET nome = @nome, idade = @idade WHERE id = @id";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("nome", funcionario.nome);
                command.Parameters.AddWithValue("idade", funcionario.idade);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Funcionário atualizado com sucesso!");
        }
    }
}

