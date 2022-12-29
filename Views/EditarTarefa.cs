using GerenciadorDeTarefas.Database;

namespace GerenciadorDeTarefas.Views
{
    public static class EditarTarefa
    {
        public static void EditarUmaTarefa()
        {
            System.Console.WriteLine("EDITAR UMA TAREFA");
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Se deseja continuar editando uma tarefa, pressione qualquer tecla. Se deseja voltar ao menu de escolha, pressione 0: ");
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
            System.Console.Write("Digite o ID da tarefa que você quer editar: ");
            int idTarefaEditar = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            DbContext.EditarTarefa(idTarefaEditar);

            System.Console.WriteLine();
            System.Console.WriteLine("Deseja continuar editando uma tarefa? s/n");
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