namespace GerenciadorDeTarefas.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

        public Tarefa()
        {

        }

        public Tarefa(int id, string nome, string descricao, DateTime data)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Data = data;
        }
    }
}