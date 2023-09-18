using System;
using System.ComponentModel;
using System.Linq;

namespace DiskSpaceWatcher {
    public static class EnumHelper {
        public static TAttr GetAttribute<TEnum, TAttr>(this TEnum en, Func<TAttr, bool> predicate = null)
            where TEnum : struct, IConvertible
            where TAttr : Attribute {
            var memInfos = typeof(TEnum).GetMember(en.ToString());
            if (memInfos == null || memInfos.Count() == 0) { return null; }
            var attrs = memInfos.First().GetCustomAttributes(typeof(TAttr), false) as TAttr[];
            if (attrs == null || attrs.Count() == 0) { return null; }
            return predicate == null
                ? attrs.FirstOrDefault()
                : attrs.FirstOrDefault(predicate);
        }

        public static string ToDescription<TEnum>(this TEnum en)
            where TEnum : struct, IConvertible {
            var descriptionAttribute = en.GetAttribute<TEnum, DescriptionAttribute>();
            return descriptionAttribute == null
                ? null
                : descriptionAttribute.Description;
        }
    }
}
