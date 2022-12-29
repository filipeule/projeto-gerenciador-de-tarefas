using GerenciadorDeTarefas.Database;

namespace GerenciadorDeTarefas.Views
{
    public static class RemoverTarefa
    {
        public static void DeletarTarefa()
        {
            System.Console.WriteLine("REMOVER UMA TAREFA");
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Se deseja continuar deletando uma tarefa, pressione qualquer tecla. Se deseja voltar ao menu de escolha, pressione 0: ");
            System.Console.WriteLine();
            System.Console.Write("Opção: ");
            string escolha = Console.ReadLine();

            if (escolha == "0")
            {
                System.Console.Clear();
                MenuPrincipal.MostrarOpcoes();
            }

            System.Console.WriteLine();

        Tarefa:
            MostrarTarefas.TarefasCadastradas();

            System.Console.WriteLine();
            System.Console.Write("Digite o ID da tarefa que você quer deletar: ");
            int idTarefaDeletada = int.Parse(Console.ReadLine());

            DbContext.RemoverTarefa(idTarefaDeletada);

            System.Console.WriteLine();
            System.Console.WriteLine("Deseja continuar removendo tarefas? s/n");
            System.Console.WriteLine();
            System.Console.Write("Opção: ");
            string continuar = Console.ReadLine();
            System.Console.Clear();

            if (continuar == "s" || continuar == "S")
            {
                goto Tarefa;
            }
        }
    }
}