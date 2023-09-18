using System.ComponentModel;

namespace DiskSpaceWatcher {
    public static class StringHelper {

        /// <summary>
        /// Convert string to object
        /// </summary>
        /// <typeparam name="T">target type</typeparam>
        /// <param name="text">text to convert</param>
        /// <returns>T type object</returns>
        public static T TryParse<T>(this string text) {
            return text.TryParse(default(T));
        }

        /// <summary>
        /// Convert string to object
        /// </summary>
        /// <typeparam name="T">target type</typeparam>
        /// <param name="text">text to convert</param>
        /// <param name="defaultValue">return value if fail</param>
        /// <returns>T type object</returns>
        public static T TryParse<T>(this string text, T defaultValue) {

            // コンバーターを作成
            var converter = TypeDescriptor.GetConverter(typeof(T));

            // text が null 、または変換不可能な場合は規定値を返す
            if (text == null || !converter.CanConvertFrom(typeof(string))) {
                return defaultValue;
            }

            try {
                // 変換した値を返す
                return (T)converter.ConvertFrom(text);
            } catch {
                // 変換に失敗したら規定値を返す
                return defaultValue;
            }
        }
    }
}
