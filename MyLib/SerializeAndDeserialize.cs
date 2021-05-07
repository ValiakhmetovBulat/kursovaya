using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Security.Permissions;
namespace MyLib
{
    public class SerializeAndDeserialize
    {
        public static Message Serialize(object anySerializableObject)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream,
                anySerializableObject);
                return new Message{Data = memoryStream.ToArray()};
            }
        }
        public static object Deserialize(Message message)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (var memoryStream = new MemoryStream(message.Data))
            {
                return formatter.Deserialize(memoryStream);
            }
        }
    }
}
