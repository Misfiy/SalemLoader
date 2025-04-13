namespace SalemLoader.Loader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Handles the loading of all mods.
    /// </summary>
    public static class ModLoader
    {
        private const string ModSearchPatten = "*.dll";

        /// <summary>
        /// Gets a list of mods.
        /// </summary>
        public static List<SalemMod> Mods { get; } = [];

        /// <summary>
        /// Initializes the ModLoader and loads it.
        /// </summary>
        internal static void Initialize()
        {
            LoadAllMods(Path.Combine(Directory.GetCurrentDirectory(), "SalemMods"));
        }

        private static void LoadAllMods(string directory)
        {
            foreach (string fileName in Directory.GetFiles(directory, ModSearchPatten))
            {
                FileInfo mod = new(fileName);

                LoadMod(mod);
            }

            foreach (SalemMod salemMod in Mods.OrderBy(x => x.LoadPriority))
            {
                salemMod.Load();
            }
        }

        private static void LoadMod(FileInfo modFile)
        {
            Assembly assembly = Assembly.Load(File.ReadAllBytes(modFile.FullName));

            foreach (Type type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(SalemMod)))
                    continue;

                if (Activator.CreateInstance(type) is not SalemMod salemMod)
                    continue;

                salemMod.Assembly = assembly;
                Mods.Add(salemMod);
            }
        }
    }
}