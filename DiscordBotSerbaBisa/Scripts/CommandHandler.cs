using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBotSerbaBisa.Scripts.BDO;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;

namespace DiscordBotSerbaBisa.Scripts
{
    public class CommandHandler
    {
        [Command("bdo")]
        public async Task BdoCommandHandler(CommandContext ctx)
        {
            string[] split = ctx.Message.Content.Split(' ');
            string[] arguments = new string[split.Length-1];

            for (int i = 0; i < split.Length-1; i++)
            {
                arguments[i] = split[i+1];
            }

            switch (arguments[0])
            {
                case "start":
                    Bot.Instance.BdoBossSpawnTimer.StartTimer();
                    break;

                default:
                    throw new ArgumentException();
            }
        }
    }
}