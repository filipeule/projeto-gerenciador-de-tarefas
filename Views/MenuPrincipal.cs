namespace GerenciadorDeTarefas.Views
{
    public static class MenuPrincipal
    {
        public static void MostrarOpcoes()
        {
            bool finalizarPrograma = false;
            while (finalizarPrograma == false)
            {
                System.Console.WriteLine("GERENCIADOR DE TAREFAS");
                System.Console.WriteLine("----------------------------------");
                System.Console.WriteLine();

                MostrarTarefas.TarefasCadastradas();

                System.Console.WriteLine();
                System.Console.WriteLine("Digite o número da ação que deseja fazer:");
                System.Console.WriteLine("1 - Adicionar uma tarefa");
                System.Console.WriteLine("2 - Editar uma tarefa");
                System.Console.WriteLine("3 - Remover uma tarefa");
                System.Console.WriteLine("9 - Sair");
                System.Console.WriteLine();
                System.Console.Write("Opção: ");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        System.Console.Clear();
                        AdicionarTarefa.NovaTarefa();
                        break;
                    case 2:
                        System.Console.Clear();
                        EditarTarefa.EditarUmaTarefa();
                        break;
                    case 3:
                        System.Console.Clear();
                        RemoverTarefa.DeletarTarefa();
                        break;
                    case 9:
                        System.Console.Clear();
                        System.Console.WriteLine("Saindo...");
                        finalizarPrograma = true;
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida! Aperte qualquer botão para voltar");
                        System.Console.ReadKey();
                        System.Console.Clear();
                        break;
                }
            }
        }
    }
}