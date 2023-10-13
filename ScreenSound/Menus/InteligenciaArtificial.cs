using OpenAI_API;
using ScreenSound.Modelos;
using System.Globalization;
using System.Xml.Serialization;

namespace ScreenSound.Menus
{
    internal class InteligenciaArtificial : Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Sobre a Banda");
            Console.Write("Qual banda voce deseja saber mais? ");
            string textMessage = Console.ReadLine();
            if (bandasRegistradas.ContainsKey(textMessage))
            {
                AuxMethod(textMessage);
            } else
            {
                Console.WriteLine($"\nA banda {textMessage} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            }
            Console.ReadKey();
            Console.Clear();
        }
        private async void AuxMethod(string textMessage)
        {
            var client = new OpenAIAPI("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");

            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Me fale um parágrafo sobre a banda {textMessage}. Use diálogo informal.");
            Console.WriteLine(await chat.GetResponseFromChatbotAsync());
            
        }
        
    }
}
