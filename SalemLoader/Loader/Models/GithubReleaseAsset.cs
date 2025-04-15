namespace SalemLoader.Loader.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Data about a release's assets. Credit to ExMod-Team/EXILED for this.
    /// </summary>
    public readonly struct GithubReleaseAsset
    {
        /// <summary>
        /// The release's id.
        /// </summary>
        [DataMember(Name = "id")]
        public readonly int Id;

        /// <summary>
        /// The release's name.
        /// </summary>
        [DataMember(Name = "name")]
        public readonly string Name;

        /// <summary>
        /// The release's size.
        /// </summary>
        [DataMember(Name = "size")]
        public readonly int Size;

        /// <summary>
        /// The release's URL.
        /// </summary>
        [DataMember(Name = "url")]
        public readonly string Url;

        /// <summary>
        /// The release's download URL.
        /// </summary>
        [DataMember(Name = "browser_download_url")]
        public readonly string BrowserDownloadUrl;
    }
}