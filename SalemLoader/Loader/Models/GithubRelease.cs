namespace SalemLoader.Loader.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Struct handling github release data.
    /// </summary>
    public readonly struct GithubRelease
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public readonly int Id;

        /// <summary>
        /// Gets the tag name.
        /// </summary>
        [DataMember(Name = "tag_name")]
        public readonly string TagName;

        /// <summary>
        /// Gets whether it is a pre-release.
        /// </summary>
        [DataMember(Name = "prerelease")]
        public readonly bool PreRelease;

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        [DataMember(Name = "created_at")]
        public readonly DateTime CreatedAt;

        /// <summary>
        /// The release's assets.
        /// </summary>
        [DataMember(Name = "assets")]
        public readonly GithubReleaseAsset[] Assets;

        /// <summary>
        /// Initializes a new instance of the <see cref="GithubRelease"/> struct.
        /// </summary>
        /// <param name="id"><inheritdoc cref="Id"/></param>
        /// <param name="tag_name"><inheritdoc cref="TagName"/></param>
        /// <param name="prerelease"><inheritdoc cref="PreRelease"/></param>
        /// <param name="created_at"><inheritdoc cref="CreatedAt"/></param>
        /// <param name="assets"><inheritdoc cref="Assets"/></param>
        public GithubRelease(int id, string tag_name, bool prerelease, DateTime created_at, GithubReleaseAsset[] assets)
        {
            Id = id;
            TagName = tag_name;
            PreRelease = prerelease;
            CreatedAt = created_at;
            Assets = assets;
        }
    }
}