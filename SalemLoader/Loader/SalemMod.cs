namespace SalemLoader.Loader
{
    using System.Reflection;

    public abstract class SalemMod
    {
        /// <summary>
        /// Gets the name of the Mod.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        public virtual int Priority { get; } = 0;

        public Assembly Assembly { get; internal set; } = null!;

        /// <summary>
        /// Handles loading the <see cref="SalemMod"/>.
        /// </summary>
        public abstract void Load();
    }
}