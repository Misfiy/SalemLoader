namespace SalemLoader.Loader.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Struct handling GitHub release data. Credit to ExMod-Team/EXILED for this.
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
    }
}