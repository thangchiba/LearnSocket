using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestSocket
{
	public static class TMExtensionMethods
	{
        public static byte[] Serialize(this TransformModel obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, obj);
            return stream.ToArray();
        }

        public static TransformModel Deserialize(this byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BinaryFormatter bf = new BinaryFormatter();
            return (TransformModel)bf.Deserialize(stream);
        }
    }
}

