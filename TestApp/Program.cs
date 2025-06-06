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



        SHA1 sha1 = SHA1.Create();

        string s = Console.ReadLine();
        byte[] hash = sha1.ComputeHash(Encoding.ASCII.GetBytes(s));

        foreach (byte b in hash)
        {
            Console.Write(b.ToString("X2"));
        }
    }


}

