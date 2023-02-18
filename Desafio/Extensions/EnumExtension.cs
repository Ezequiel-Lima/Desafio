using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;

namespace Desafio.Extensions
{
    public static class EnumExtension
    {
        private static readonly
            ConcurrentDictionary<string, string> GetDescriptionCache = new ConcurrentDictionary<string, string>();

        public static string GetDescription(this Enum value)
        {
            var key = $"{value.GetType().FullName}.{value}";

            var getDescription = GetDescriptionCache.GetOrAdd(key, x =>
            {
                var name = (DescriptionAttribute[])value
                    .GetType()
                    .GetTypeInfo()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

                return name.Length > 0 ? name[0].Description : value.ToString();
            });

            return getDescription;
        }
    }
}
