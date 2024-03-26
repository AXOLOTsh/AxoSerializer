using System.Text.Json;
using System.Text.Json.Serialization;

namespace AxoSerializer
{
    /// <summary>
    /// Represents the base class for classes that need to be serialized.
    /// </summary>
    /// <typeparam name="T">Class to serialize (specify the heir).</typeparam>
    public abstract class Serializable<T> where T : new()
    {
        /// <summary>
        /// Get or set serializer options.
        /// </summary>
        [JsonIgnore]
        public JsonSerializerOptions SerializerOptions { get; set; } = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        /// <summary>
        /// Get or set the path to the directory where the serialization file will be written.
        /// </summary>
        public string SerializationPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Serializes a object to a file.
        /// </summary>
        /// <param name="serializationObject">The class to be serialized.</param>
        public virtual void Serialize(T serializationObject)
        {
            Serializer.Serialize(serializationObject, Path.Combine(SerializationPath, $"{typeof(T).Name}.json"), SerializerOptions);
        }

        /// <summary>
        /// Deserializes a object from a file.
        /// </summary>
        /// <returns>Deserialized object.</returns>
        public T Deserialize()
        {
            try
            {
                return (T)Serializer.Deserialize(Path.Combine(SerializationPath, $"{typeof(T).Name}.json"));
            }
            catch
            {
                return new T();
            } 
        }
    }
}
