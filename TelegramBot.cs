﻿using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EmotionalIntelligenceBot
{
    public class TelegramBot
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient;

        public TelegramBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            _botClient = new TelegramBotClient(_configuration["Token"]);
            var hook = $"{_configuration["Url"]}api/message/update";
            await _botClient.SetWebhookAsync(hook);
            return _botClient;
        }
    }
}
