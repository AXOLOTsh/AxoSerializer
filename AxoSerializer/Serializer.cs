using System.Text.Json;

namespace AxoSerializer
{
    /// <summary>
    /// Static class for serializing objects.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializationObject">Serialization object.</param>
        /// <param name="filePath">The file path where to save the object.</param>
        /// <param name="serializerOptions">Serializer options.</param>
        public static void Serialize(object serializationObject, string filePath, JsonSerializerOptions serializerOptions)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(serializationObject, serializerOptions));
        }

        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <param name="filePath">Path to the file to be deserialized.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">Exception thrown if file not found.</exception>
        public static object Deserialize(string filePath)
        {
            if (File.Exists(filePath))
            {
                return JsonSerializer.Deserialize<object>(File.ReadAllText(filePath));
            }
            else
            {
                throw new FileNotFoundException($"File {filePath} not found.");
            }
        }
    }
}
