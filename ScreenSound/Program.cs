
using ScreenSound.Modelos;
using ScreenSound.Menus;

internal class Program
{
    private static void Main(string[] args)
    {
        Banda ira = new Banda("Ira!");

        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));

        Banda beatles = new Banda("Beatles");

        Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();
        bandasRegistradas.Add(ira.Nome, ira);
        bandasRegistradas.Add(beatles.Nome, beatles);

        Dictionary<int, Menu> opcoesMenu = new Dictionary<int, Menu>();
        opcoesMenu.Add(1, new MenuRegistrarBanda());
        opcoesMenu.Add(2, new MenuRegistrarAlbum());
        opcoesMenu.Add(3, new MenuBandasRegistradas());
        opcoesMenu.Add(4, new MenuAvaliarBanda());
        opcoesMenu.Add(5, new MenuAvaliarAlbum());
        opcoesMenu.Add(6, new MenuExibirDetalhes());
        opcoesMenu.Add(7, new InteligenciaArtificial());
        opcoesMenu.Add(-1, new MenuSair());


        void ExibirLogo()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para avaliar um album");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite 7 para conversar com a Inteligencia Artificial");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoesMenu.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = opcoesMenu[opcaoEscolhidaNumerica];
                menuASerExibido.Executar(bandasRegistradas);
                if (opcaoEscolhidaNumerica > 0)
                {
                    ExibirOpcoesDoMenu();
                }
            } else
            {
                Console.WriteLine("Opção inválida");
            }

        }

        ExibirOpcoesDoMenu();
    }
}