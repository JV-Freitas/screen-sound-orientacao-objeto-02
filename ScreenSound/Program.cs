using ScreenSound.Menus;
using ScreenSound.Modelos;
using OpenAI_API;



Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();

Banda rhcp = new("Red Hot Chili Peppers");
rhcp.AdicionarNota(new Avaliacao(10));
rhcp.AdicionarNota(new Avaliacao(9));


Banda linkinPark = new("Linkin Park");
linkinPark.AdicionarNota(new Avaliacao(9));
linkinPark.AdicionarNota(new Avaliacao(8));
linkinPark.AdicionarNota(new Avaliacao(7));

bandasRegistradas.Add(rhcp.Nome, rhcp);
bandasRegistradas.Add(linkinPark.Nome, linkinPark);


Dictionary<int, Menu> opcoesDoMenu = new();
opcoesDoMenu.Add(1, new MenuRegistrarBanda());
opcoesDoMenu.Add(2, new MenuRegistrarAlbum());
opcoesDoMenu.Add(3, new MenuMostrarBandasRegistradas());
opcoesDoMenu.Add(4, new MenuAvaliarBanda()); 
opcoesDoMenu.Add(5, new MenuAvaliarAlbum()); 
opcoesDoMenu.Add(6, new MenuExibirDetalhes());
opcoesDoMenu.Add(-1, new MenuSair());

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
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoesDoMenu.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoesDoMenu[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(bandasRegistradas);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();