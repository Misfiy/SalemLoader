namespace SalemLoader
{
    using BepInEx;
    using BepInEx.Logging;
    using Loader;

    [BepInPlugin(Guid, Name, Version)]
    public class Entry : BaseUnityPlugin
    {
        public const string Guid = "com.eves.salemloader";
        public const string Name = "SalemLoader";
        public const string Version = "0.1.0";

        internal new static ManualLogSource Logger { get; private set; } = null!;
        
        private void Awake()
        {
            Logger = base.Logger;
            ModLoader.Initialize();
        }
    }
}