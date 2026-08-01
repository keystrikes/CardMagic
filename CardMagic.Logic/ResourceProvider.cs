using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;

namespace CardMagic.Logic
{
    /// <summary>
    /// Provides access to card images. Attempts multiple strategies:
    /// 1) Load embedded resources from this assembly (CardMagic.Logic)
    /// 2) Use the UI project's ResourceManager (CardMagic.Properties.Resources) if available
    /// 3) Load from common runtime file locations (Resources folders)
    /// This approach keeps the UI working while enabling migration of images into the logic assembly later.
    /// </summary>
    public static class ResourceProvider
    {
        /// <summary>
        /// Get card image for the given 1-based index (1..53).
        /// Returns null if image cannot be found.
        /// </summary>
        public static Image GetCardImage(int index)
        {
            if (index <= 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            // 1) Try to load as embedded resource from this assembly (CardMagic.Logic.Resources.{index}.png)
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                string name = asm.GetName().Name + ".Resources." + index + ".png"; // e.g. CardMagic.Logic.Resources.1.png
                using (var s = asm.GetManifestResourceStream(name))
                {
                    if (s != null)
                    {
                        return Image.FromStream(s);
                    }
                }
            }
            catch
            {
                // ignore and fall through
            }

            // 2) Try to use UI project's generated Resources class: CardMagic.Properties.Resources.ResourceManager
            try
            {
                var uiAssembly = Assembly.Load("CardMagic");
                if (uiAssembly != null)
                {
                    var resType = uiAssembly.GetType("CardMagic.Properties.Resources");
                    if (resType != null)
                    {
                        var prop = resType.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public);
                        if (prop != null)
                        {
                            var rm = prop.GetValue(null) as ResourceManager;
                            if (rm != null)
                            {
                                var obj = rm.GetObject(index.ToString());
                                if (obj is Image img)
                                    return img;
                            }
                        }
                    }
                }
            }
            catch
            {
                // ignore and fall through
            }

            // 3) Try common file system locations relative to application base directory
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory ?? Directory.GetCurrentDirectory();
                // common places where images might reside during development
                string[] candidates = new[] {
                    Path.Combine(baseDir, "Resources", index + ".png"),
                    Path.Combine(baseDir, "CardMagic", "Resources", index + ".png"),
                    Path.Combine(baseDir, "..", "CardMagic", "Resources", index + ".png")
                };

                foreach (var c in candidates)
                {
                    if (File.Exists(c))
                    {
                        return Image.FromFile(c);
                    }
                }
            }
            catch
            {
                // ignore
            }

            // not found
            return null;
        }
    }
}
