#pragma warning disable S6605

using System.IO;
using System.Linq;
using System.Reflection;

namespace Audio
{
    internal static class HelperFunctions
    {
        public static string LoadEmbeddedSound(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            Assembly a = typeof(HelperFunctions).Assembly;
            string resourceName = $"{a.GetName().Name}.Sounds.{name}";

            if (!a.GetManifestResourceNames().Any(x => x == resourceName))
            {
                return null;
            }

            using (Stream s = a.GetManifestResourceStream(resourceName))
            {
                using (StreamReader r = new(s))
                {
                    return r.ReadToEnd();
                }
            }
        }
    }
}
