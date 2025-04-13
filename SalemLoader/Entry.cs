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
        private const string Guid = "com.eves.salemloader";
        private const string Name = "SalemLoader";
        private const string Version = "0.1.0";

        private void Awake()
        {
            ModLoader.Initialize();
        }
    }
}