using System.Linq;

namespace AggregateGroot.Git.Tools.GitIgnore
{
    /// <summary>
    /// Provides a catalog of git ignore definitions.
    /// </summary>
    public static class GitIgnoreCatalog
    {
        /// <summary>
        /// Gets the list of paths to ignore for .NET.
        /// </summary>
        public static string[] DotNet { get; } = new []
        {
            "bin/",
            "obj/",
        };
        
        /// <summary>
        /// Gets the list of paths to ignore for Jet Brains Rider.
        /// </summary>
        public static string[] Rider { get; } = DotNet.Concat(new []
        {
            ".idea/",
            "*.iml",
        }).ToArray();
        
        /// <summary>
        /// Gets the list of paths to ignore for Visual Studio.
        /// </summary>
        public static string[] VisualStudio { get; } = DotNet.Concat(new []
        {
            ".vs/",
        }).ToArray();

        /// <summary>
        /// Gets the list of paths to ignore for Structurizr.
        /// </summary>
        public static string[] Structurizr { get; } = new[]
        {
            ".structurizr/",
        };
    }
}