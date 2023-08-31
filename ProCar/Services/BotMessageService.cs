using Telegram.Bot;

namespace ProCar.Services
{
    public class BotMessageService : IBotMessageService
    {
        private readonly IConfiguration _conf;
        public BotMessageService(IConfiguration conf)
        {
            _conf = conf;
        }
        public async Task Send(string message)
        {
            string token = _conf.GetValue<string>("BotSettings:Token");
            string chatId = _conf.GetValue<string>("BotSettings:ChatId");

            if (token == null || chatId == null)
            {
                return;
            }

            var api = new TelegramBotClient(token);
            await api.SendTextMessageAsync(chatId, message);
        }
    }
}
