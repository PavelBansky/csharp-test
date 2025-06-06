using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    [Serializable()]
    public class ExampleClass : IDeserializationCallback
    {
        private string member;
        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            var sourceFileName = "malicious file";
            var destFileName = "sensitive file";
            File.Copy(sourceFileName, destFileName);
        }

        public SerializationBinder SomeBinder { get; set; }

        public object DoDeserialization(byte[] bytes)
        {
            //BAD
            var formatter = new BinaryFormatter();
            formatter.Binder = SomeBinder;
            return formatter.Deserialize(new MemoryStream(bytes));
        }
    }


}
