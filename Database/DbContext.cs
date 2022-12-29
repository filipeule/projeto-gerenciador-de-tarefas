using System.Globalization;
using GerenciadorDeTarefas.Entities;
using Microsoft.Data.Sqlite;

namespace GerenciadorDeTarefas.Database
{
    public class DbContext
    {
        public static string _connectionString = @"Data Source=.\GerenciadorDeTarefas.db";

        public static void CriarTabela()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS tarefas (
					Id INTEGER PRIMARY KEY AUTOINCREMENT,
					Nome TEXT,
					Descricao TEXT,
					Data TEXT
				)";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static string AdicionarTarefa(string nome, string descricao, string data)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @$"INSERT INTO tarefas(Nome, Descricao, Data) VALUES('{nome}', '{descricao}', '{data}')";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

            return "Adicionado com sucesso!";
        }

        public static void MostrarTarefas()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @$"SELECT * FROM tarefas";
                SqliteDataReader reader = tableCmd.ExecuteReader();

                var listaTarefas = new List<Tarefa>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listaTarefas.Add(new Tarefa
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Descricao = reader.GetString(2),
                            Data = DateTime.ParseExact(reader.GetString(3), "dd/MM/yyyy HH:mm:ss", new CultureInfo("pt-BR"))
                        });
                    }
                }
                else
                {
                    System.Console.WriteLine("Sem tarefas cadastradas.");
                    System.Console.WriteLine();
                }

                connection.Close();

                foreach (Tarefa item in listaTarefas)
                {
                    System.Console.WriteLine($"ID: {item.Id} - DATA: {item.Data} - NOME: {item.Nome} - DESCRIÇÃO: {item.Descricao}");
                    System.Console.WriteLine();
                }
            }
        }

        public static void RemoverTarefa(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @$"DELETE FROM tarefas WHERE Id = '{id}'";
                int valorTabela = tableCmd.ExecuteNonQuery();

                if (valorTabela == 0)
                {
                    System.Console.WriteLine($"Não existe nenhuma tarefa com o ID {id}");
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Tarefa com o ID {id} deletada com sucesso!");
                }

                connection.Close();
            }
        }

        public static void EditarTarefa(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var checkCmd = connection.CreateCommand();
                checkCmd.CommandText = @$"SELECT EXISTS(SELECT 1 FROM tarefas WHERE Id = '{id}')";
                int verificarConsulta = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (verificarConsulta == 0)
                {
                    System.Console.WriteLine($"Não existe nenhuma tarefa com o ID {id}");
                }
                else
                {
                    System.Console.WriteLine("Qual campo você quer editar?");
                    System.Console.WriteLine("1 - NOME");
                    System.Console.WriteLine("2 - DESCRIÇÃO");
                    System.Console.WriteLine("3 - AMBOS OS CAMPOS");
                    System.Console.WriteLine();
                    System.Console.Write("Opção: ");
                    int escolhaCampo = int.Parse(Console.ReadLine());
                    System.Console.WriteLine();

                    if (escolhaCampo != 1 && escolhaCampo != 2 && escolhaCampo != 3)
                    {
                        System.Console.Write("Valor de escolha inválido! Digite um valor entre 1, 2 ou 3! ");
                        System.Console.ReadKey();
                        System.Console.Clear();
                    }
                    else
                    {
                        if (escolhaCampo == 1)
                        {
                            System.Console.Write("Digite o novo nome da tarefa: ");
                            string novoNome = Console.ReadLine();

                            var tableCmd = connection.CreateCommand();
                            tableCmd.CommandText = @$"UPDATE tarefas SET Nome = '{novoNome}' WHERE Id = '{id}'";
                            int valorTabela = tableCmd.ExecuteNonQuery();

                            System.Console.WriteLine();
                            System.Console.WriteLine($"Tarefa com ID {id} atualizada com sucesso!");
                        }
                        else if (escolhaCampo == 2)
                        {
                            System.Console.Write("Digite a nova descrição da tarefa: ");
                            string novaDescricao = Console.ReadLine();

                            var tableCmd = connection.CreateCommand();
                            tableCmd.CommandText = @$"UPDATE tarefas SET Descricao = '{novaDescricao}' WHERE Id = '{id}'";
                            int valorTabela = tableCmd.ExecuteNonQuery();

                            System.Console.WriteLine();
                            System.Console.WriteLine($"Tarefa com ID {id} atualizada com sucesso!");
                        }
                        else
                        {
                            System.Console.Write("Digite o novo nome da tarefa: ");
                            string novoNome = Console.ReadLine();
                            System.Console.WriteLine();
                            System.Console.Write("Digite a nova descrição da tarefa: ");
                            string novaDescricao = Console.ReadLine();

                            var tableCmd = connection.CreateCommand();
                            tableCmd.CommandText = @$"UPDATE tarefas SET Nome = '{novoNome}', Descricao = '{novaDescricao}' WHERE Id = '{id}'";
                            int valorTabela = tableCmd.ExecuteNonQuery();

                            System.Console.WriteLine();
                            System.Console.WriteLine($"Tarefa com ID {id} atualizada com sucesso!");
                        }
                    }

                }

                connection.Close();
            }

        }
    }
}