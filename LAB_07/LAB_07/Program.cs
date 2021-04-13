using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            var encode = new DES_EEE2CryptoEncode();
            var decode = new DES_EEE2CryptoDecode();

            var crypted = encode.Encode("NEVAR JULIYA VALERYEVNA***********", "KEY12345", "KEY54321");
            var uncrypted = decode.Decode(crypted, "KEY12345", "KEY54321");

            Console.WriteLine(crypted);
            Console.WriteLine(uncrypted);
        }
    }
}
