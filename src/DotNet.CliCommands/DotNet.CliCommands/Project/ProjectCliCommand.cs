﻿using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project
{
    /// <summary>
    /// Represents the CLI command for working with .NET projects.
    /// </summary>
    [Command(Name = "project", Description = "Work with .NET projects.")]
    [Subcommand(
        typeof(AddCliCommand))]
    public class ProjectCliCommand : CliCommand
    {
    }
}