namespace SalemLoader.Loader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using SalemLoader.Loader.Models;
    using Server.Shared.Utils.Json;

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
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        internal static ModDownloader Instance => _instance ??= new ModDownloader();

        private void CheckForLoaderUpdates()
        {
            GithubRelease[] releases = GetRecentReleases().GetAwaiter().GetResult();
            IEnumerable<GithubRelease> orderedReleases = releases.OrderBy(r => r.CreatedAt);

            // do version check on them
            GithubRelease? toUpdate = null;
            if (toUpdate != null)
            {
                // update
            }

            // load all mods after checking ModLoader updates
            ModLoader.Initialize();
        }

        private async Task<GithubRelease[]> GetRecentReleases()
        {
            string url = string.Format(GetReleasesTemplate, RepoId);
            using HttpResponseMessage httpResponse = await _client.GetAsync(url).ConfigureAwait(false);
            string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerialization.Deserialize<GithubRelease[]>(content) ?? [];
        }
    }
}