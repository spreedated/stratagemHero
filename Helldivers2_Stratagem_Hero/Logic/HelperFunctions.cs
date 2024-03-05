#pragma warning disable S6605

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Helldivers2_Stratagem_Hero.Logic
{
    public static class HelperFunctions
    {
        public static byte[] LoadEmbeddedStratagem(string imagename)
        {
            if (string.IsNullOrEmpty(imagename))
            {
                return [];
            }

            if (!imagename.EndsWith(".png"))
            {
                imagename += ".png";
            }

            Assembly a = typeof(HelperFunctions).Assembly;

            if (!a.GetManifestResourceNames().Any(x => x.EndsWith(imagename, StringComparison.CurrentCultureIgnoreCase)))
            {
                return [];
            }

            using (Stream s = a.GetManifestResourceStream($"{a.GetName().Name}.Resources.Images.Stratagems.{imagename}"))
            {
                if (s == null)
                {
                    return [];
                }

                byte[] buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
