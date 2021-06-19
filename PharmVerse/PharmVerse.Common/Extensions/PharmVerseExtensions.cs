using System;

namespace PharmVerse.Common.Extensions
{
     public static class PharmVerseExtensions
     {
          public static string Slugify(this string str)
          {
               return str.ToLower().Replace(" ", "-").Replace(".", "").Replace("/", "-").Replace("\\", "-").Replace("@", "-").Replace("!", "").Replace(",", "").Replace("~", "").Replace("`", "").Replace("'", "").Replace("\"", "").Replace("#", "").Replace("&", "") + Guid.NewGuid().ToString().Substring(0, 12);
          }
     }
}