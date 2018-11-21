using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscordBotSerbaBisa.Scripts;
using DiscordBotSerbaBisa.Scripts.BDO;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

namespace DiscordBotSerbaBisa
{
    public class Bot
    {
        private static Bot _instance;
        public static Bot Instance
        {
            get { return _instance; }
        }

        private static DiscordClient _client;
        private static CommandsNextModule _commandsNextModule;

        public BdoBossSpawnTimer BdoBossSpawnTimer;
        public CommandHandler CommandHandler;

        public Bot()
        {
            _instance = this;
        }

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            _client = new DiscordClient(new DiscordConfiguration
            {
                Token = Const.BotToken,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            _client.MessageCreated += async e =>
            {

            };

            _commandsNextModule = _client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "?"
            });

            _commandsNextModule.RegisterCommands<CommandHandler>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
