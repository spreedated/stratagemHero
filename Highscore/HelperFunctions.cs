﻿#pragma warning disable S6605

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Highscore
{
    internal static class HelperFunctions
    {
        public static string LoadEmbeddedSql(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (!name.EndsWith(".sql"))
            {
                name += ".sql";
            }

            Assembly a = typeof(HelperFunctions).Assembly;
            string resourceName = $"{a.GetName().Name}.Sql.{name}";

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

        public static string ToSqlDateTime(this DateTime dt)
        {
            return dt.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public static string ToSqlDate(this DateTime dt)
        {
            return dt.ToString("dd-MM-yyyy");
        }
    }
}
