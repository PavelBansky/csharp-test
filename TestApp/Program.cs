// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter some value to be hashed:");
        MD5 md5 = MD5.Create();
        string s = Console.ReadLine();
        byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(s));

        foreach (byte b in hash)
        {
            Console.Write(b.ToString("X2"));
        }
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
}