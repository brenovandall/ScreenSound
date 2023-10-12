
using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public async void ChatAI(string banda)
    {
        var client = new OpenAIAPI("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");

        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Fale em 1 parágrafo sobre a banda {banda}. Use um diálogo informal.");
        string response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response);
    }
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            Banda banda = bandasRegistradas[nomeDaBanda];
            banda.AdicionarAlbum(new Album(tituloAlbum));
            Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!\n");
            ChatAI(nomeDaBanda);
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
