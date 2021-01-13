using Newtonsoft.Json;

namespace CreationalPatterns.Prototype {
    public static class DeepCloner {
        /// <summary>
        /// Perform a deep Copy of the object, using Json as the mode of serialization.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneJson<T>(this T source) {
            return source == null 
                ? default 
                : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}
