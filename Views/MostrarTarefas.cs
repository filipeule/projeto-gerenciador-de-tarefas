using GerenciadorDeTarefas.Database;

namespace GerenciadorDeTarefas.Views
{
    public static class MostrarTarefas
    {
        public static void TarefasCadastradas()
        {
            System.Console.WriteLine("TAREFAS CADASTRADAS");
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine();

            DbContext.MostrarTarefas();

            System.Console.WriteLine("----------------------------------");
        }
    }
}