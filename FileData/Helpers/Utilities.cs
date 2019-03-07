using System;
using System.Linq;
using FileData.Models;
using FileData.Services;
using ThirdPartyTools;

namespace FileData.Helpers
{
    public static class Utilities
    {
        private const string VersionOptionName = "Version";
        private const string SizeOptionName = "Size";

        private static readonly CommandArgumentInfo[] Options = new[]
        {
            new CommandArgumentInfo
            {
                Name = VersionOptionName,
                Aliases = new[] {"-v", "--v", "/v", "--version"},
                Description = "to get version of the file"
            },
            new CommandArgumentInfo
            {
                Name = SizeOptionName,
                Aliases = new[] {"-s", "--s", "/s", "--size"},
                Description = "to get the size of the file"
            }
        };

        private static bool TryParseOptions(string[] args, out CommandOption option)
        {
            if (args == null || args.Length != 2)
            {
                option = null;
                return false;
            }

            if (!IsValidOption(args[0]))
            {
                option = null;
                return false;
            }

            option = new CommandOption
            {
                Name = Options.First(o => o.Aliases.Contains(args[0])).Name,
                Value = args[1]
            };
            
            return true;
        }

        private static bool IsValidOption(string name)
        {
            return Options.Any(o => o.Aliases.Contains(name));
        }

        public static void Execute(string[] args)
        {
            if (!TryParseOptions(args, out var commandOption))
            {
                Console.WriteLine("Error : invalid usage");
                foreach (var commandArgumentInfo in Options)
                {
                    Console.WriteLine($"Use {string.Join(" or ", commandArgumentInfo.Aliases)} {commandArgumentInfo.Description}");
                }
                // Environment.Exit(1);
                return;
            }

            IFileDetailsService fileDetailsService = new FileDetailsService(new FileDetails());

            Console.Write(commandOption.Name == VersionOptionName
                ? $"{fileDetailsService.GetVersion(commandOption.Value)}"
                : $"{fileDetailsService.GetSize(commandOption.Value)}");
        }

    }
}
