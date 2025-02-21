﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Architecture.CliCommands;
using AggregateGroot.DocFx.CliCommands;
using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands;
using AggregateGroot.Git.CliCommands;
using AggregateGroot.Templating.CliCommands;

namespace AggregateGroot.Cli
{
    /// <summary>
    /// Represents the root command for the CLI.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Subcommand(
        typeof(DocFxCliCommand),
        typeof(DotNetRootCliCommand),
        typeof(ArchitectureCliCommand),
        typeof(GitCliCommand),
        typeof(RootTemplateCliCommand))]
    public class RootCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        /// <param name="console">
        /// Required console.
        /// </param>
        public int OnExecute(CommandLineApplication application, IConsole console)
        {
            string versionNumber = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version?
                .ToString()!;
            
            console.WriteLine("-----------------------------------");
            console.WriteLine("Welcome.");
            console.WriteLine("Use -h for more help.");
            console.WriteLine($"Version: {versionNumber}");
            console.WriteLine("-----------------------------------");
            
            application.ShowHelp();
            return 1;
        }
    }
}