using GerenciadorDeTarefas.Database;

namespace GerenciadorDeTarefas.Views
{
    public static class AdicionarTarefa
    {
        public static void NovaTarefa()
        {
            System.Console.WriteLine("ADICIONAR NOVA TAREFA");
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Se deseja continuar adicionando uma tarefa, pressione qualquer tecla. Se deseja voltar ao menu de escolha, pressione 0: ");
            System.Console.WriteLine();
            System.Console.Write("Opção: ");
            string escolha = Console.ReadLine();

            if (escolha == "0")
            {
                System.Console.Clear();
                MenuPrincipal.MostrarOpcoes();
            }

        Tarefa:
            System.Console.WriteLine();
            System.Console.Write("Digite o nome da tarefa: ");
            string nomeTarefa = Console.ReadLine();
            System.Console.Write("Digite a descrição da tarefa: ");
            string descricaoTarefa = Console.ReadLine();

            string dataTarefa = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            System.Console.WriteLine();
            System.Console.Write(DbContext.AdicionarTarefa(nomeTarefa, descricaoTarefa, dataTarefa));
            System.Console.WriteLine();
            System.Console.WriteLine("Deseja adicionar mais uma tarefa? s/n");
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