namespace SalemLoader
{
    using BepInEx;
    using SalemLoader.Loader;

    /// <summary>
    /// The entry plugin for BepInEx, handles initializing the ModLoader.
    /// </summary>
    [BepInPlugin(Guid, Name, Version)]
    public class Entry : BaseUnityPlugin
    {
        /// <summary>
        /// Gets the Guid of the ModLoader.
        /// </summary>
        public const string Guid = "com.eves.salemloader";

        /// <summary>
        /// Gets the name of the ModLoader.
        /// </summary>
        public const string Name = "SalemLoader";

        /// <summary>
        /// Gets the current version of the ModLoader.
        /// </summary>
        public const string Version = "0.1.0";

        private void Awake()
        {
            ModLoader.Initialize();
        }
    }
}