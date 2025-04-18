﻿namespace SalemLoader.Loader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
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
                Timeout = TimeSpan.FromSeconds(5),
            };

            Task.Run(Run);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        internal static ModDownloader Instance => _instance ??= new ModDownloader();

        private async Task Run()
        {
            await CheckForLoaderUpdates();
            ModLoader.Initialize();
        }

        private async Task CheckForLoaderUpdates()
        {
            GithubRelease[] releases = await GetRecentReleases();

            // do version check on them
            GithubRelease? toUpdate = releases.FirstOrDefault();
            if (toUpdate.HasValue)
            {
                // update from asset.Url
                GithubReleaseAsset? asset = toUpdate.Value.Assets.FirstOrDefault(asset => asset.Name.Contains(".dll"));
                if (asset.HasValue)
                {
                    byte[] newDllBytes = GetLatestReleaseBinary(asset.Value).GetAwaiter().GetResult();
                    string currentDllPath = Assembly.GetExecutingAssembly().Location;
                    string backupPath = currentDllPath + ".old";

                    File.Move(currentDllPath, backupPath);
                    File.WriteAllBytes(currentDllPath, newDllBytes);
                }
            }
        }

        private async Task<GithubRelease[]> GetRecentReleases()
        {
            string url = string.Format(GetReleasesTemplate, RepoId);
            using HttpResponseMessage httpResponse = await _client.GetAsync(url);
            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerialization.Deserialize<GithubRelease[]>(content) ?? [];
        }

        private async Task<byte[]> GetLatestReleaseBinary(GithubReleaseAsset url)
        {
            using HttpResponseMessage httpResponse = await _client.GetAsync(url.Url);
            return httpResponse.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
        }
    }
}