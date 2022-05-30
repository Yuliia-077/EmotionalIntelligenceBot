using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace EmotionalIntelligenceBot.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController: ControllerBase
    {
        [HttpPost("update")]
        public IActionResult Update(Update update)
        {
            return Ok();
        }
    }
}
