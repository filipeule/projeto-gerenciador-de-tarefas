using GerenciadorDeTarefas.Database;
using GerenciadorDeTarefas.Views;

namespace GerenciadorDeTarefas
{
    class Program
    {
        static void Main()
        {
            DbContext.CriarTabela();

            MenuPrincipal.MostrarOpcoes();

            Encerramento.ConsideracoesFinais();
        }
    }
}
