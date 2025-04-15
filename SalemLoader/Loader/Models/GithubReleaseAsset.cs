namespace SalemLoader.Loader.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Data about a release's assets.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="GithubReleaseAsset"/> struct.
        /// </summary>
        /// <param name="id"><inheritdoc cref="Id"/></param>
        /// <param name="name"><inheritdoc cref="Name"/></param>
        /// <param name="size"><inheritdoc cref="Size"/></param>
        /// <param name="url"><inheritdoc cref="Url"/></param>
        /// <param name="browser_download_url"><inheritdoc cref="BrowserDownloadUrl"/></param>
        public GithubReleaseAsset(int id, string name, int size, string url, string browser_download_url)
        {
            Id = id;
            Name = name;
            Size = size;
            Url = url;
            BrowserDownloadUrl = browser_download_url;
        }
    }
}