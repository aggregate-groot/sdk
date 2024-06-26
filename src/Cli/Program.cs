﻿using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.Architecture.Tools;
using AggregateGroot.CliCommands;
using AggregateGroot.Git.Tools;
using AggregateGroot.Templating;

namespace AggregateGroot.Cli
{
    /// <summary>
    /// Represents the main command line application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        private static void Main(string[] args)
        {         
            ServiceProvider services = new ServiceCollection()
                .AddSingleton(PhysicalConsole.Singleton)
                .AddCliCommands()
                .AddProjectTemplating()
                .AddArchitectureTools()
                .AddGitTooling()
                .BuildServiceProvider();

            CommandLineApplication<RootCommand> application = new ();
            application.HelpOption("-h|--help");

            application.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(services);
            
            application.Execute(args);
        }
    }
}