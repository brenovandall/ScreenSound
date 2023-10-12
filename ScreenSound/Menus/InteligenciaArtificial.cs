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
            Console.Clear();
            Console.Write("\nO que voce está pensando? ");
            string textMessage = Console.ReadLine();
            AuxMethod(textMessage);
            Console.ReadKey();
            Console.Clear();
        }
        private async void AuxMethod(string textMessage)
        {
            var client = new OpenAIAPI("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");

            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage(textMessage);
            Console.WriteLine(await chat.GetResponseFromChatbotAsync());
            
        }
        
    }
}
