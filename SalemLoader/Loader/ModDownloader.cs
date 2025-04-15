namespace SalemLoader.Loader
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Handles the downloading of mods and its data.
    /// </summary>
    internal sealed class ModDownloader
    {
        private const long RepoId = 965640406;
        private const string GetReleasesTemplate = "https://api.github.com/{0}/releases";

        private static ModDownloader? _instance;
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModDownloader"/> class.
        /// </summary>
        private ModDownloader()
        {
            _client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(2.5f),
            };

            CheckForLoaderUpdates();
            ModLoader.Initialize();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        internal static ModDownloader Instance => _instance ??= new ModDownloader();

        private void CheckForLoaderUpdates()
        {
        }
    }
}