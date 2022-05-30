using EmotionalIntelligenceBot.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EmotionalIntelligenceBot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class TelegramBotController: ControllerBase
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly DataContext _context;

        public TelegramBotController(TelegramBot telegramBot, DataContext context)
        {
            _telegramBotClient = telegramBot.GetBot().Result;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]object update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            var chat = upd.Message?.Chat;
            if(chat == null)
            {
                return Ok();
            }
            var appUser = new AppUser
            {
                Username = chat.Username,
                ChatId = chat.Id,
                FirstName = chat.FirstName,
                LastName = chat.LastName
            };

            var result = await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();
            await _telegramBotClient.SendTextMessageAsync(chat.Id, "You log in", Telegram.Bot.Types.Enums.ParseMode.Markdown);
            return Ok();
        }
    }
}
