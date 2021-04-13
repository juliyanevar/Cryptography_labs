using System;

namespace LAB_06
{
    class Program
    {
        static void Main()
        {
            var enigma = new Enigma();
            var encoded = enigma.Crypt("NEVAR JULIYA VALERYEVNA",1 , 0, 1);
            Console.WriteLine($"Encoded:{encoded}\n");
            var decoded = enigma.Crypt(encoded, 1, 0, 1);
            Console.WriteLine($"Decoded:{decoded}");
        }
    }
}
