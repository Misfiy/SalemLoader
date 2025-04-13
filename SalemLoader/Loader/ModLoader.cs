namespace SalemLoader.Loader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public static class ModLoader
    {
        private const string ModSearchPatten = "*.dll";
        private const string PdbExtension = ".pdb";

        public static Dictionary<SalemMod, Assembly> Mods { get; } = [];

        public static void Initialize()
        {
            LoadAllMods(Path.Combine(Directory.GetCurrentDirectory(), "SalemMods"));
        }

        private static void LoadAllMods(string directory)
        {
            foreach (string fileName in Directory.GetFiles(directory, ModSearchPatten))
            {
                FileInfo mod = new(fileName);
                FileInfo pdb = new(Path.ChangeExtension(fileName, PdbExtension));

                LoadMod(mod, pdb);
            }
        }

        private static void LoadMod(FileInfo modFile, FileInfo pdbFile)
        {
            Assembly assembly = pdbFile.Exists
                ? Assembly.Load(File.ReadAllBytes(modFile.FullName), File.ReadAllBytes(pdbFile.FullName))
                : Assembly.Load(modFile.FullName);
            
            InitializeModData(assembly);
        }

        private static void InitializeModData(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(SalemMod)))
                    continue;

                if (Activator.CreateInstance(type) is not SalemMod salemMod)
                    continue;
                
                Mods.Add(salemMod, assembly);
            }
        }
    }
}