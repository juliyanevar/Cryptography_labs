using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_06
{
    public class Enigma
    {
        private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
        private static readonly string _rotor8 = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        private static readonly string _rotor4 = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
        private static readonly string[] _reflectorB = { "AY", "BR", "CU", "DH", "EQ", "FS", "GL", "IP", "JX", "KN", "MO", "TZ", "VW", "TV" };

        public string Crypt(string text, int posR, int posM, int posL)
        {
            var rotorR = new Rotor(_rotor4, posR);
            var rotorM = new Rotor(_rotor2, posM);
            var rotorL = new Rotor(_rotor8, posL);
            var result = new StringBuilder(text.Length);
            char symbol;

            

            foreach (var ch in text)
            {
                Console.Write(ch);

                if (ch == ' ')
                {
                    Console.Write("(space like X)");
                    symbol = rotorR[_alphabet.IndexOf('X')];
                }
                else
                {
                    symbol = rotorR[_alphabet.IndexOf(ch)];
                }
                Console.Write(" => " + symbol);
                symbol = rotorM[_alphabet.IndexOf(symbol)];
                Console.Write(" => " + symbol);
                symbol = rotorL[_alphabet.IndexOf(symbol)];
                Console.Write(" => " + symbol);
                symbol = _reflectorB.First(x => x.Contains(symbol)).First(x => !x.Equals(symbol));
                Console.Write(" => " + symbol);
                symbol = _alphabet[rotorL.IndexOf(symbol)];
                Console.Write(" => " + symbol);
                symbol = _alphabet[rotorM.IndexOf(symbol)];
                Console.Write(" => " + symbol);
                symbol = _alphabet[rotorR.IndexOf(symbol)];
                Console.Write(" => " + symbol);
                Console.WriteLine();
                result.Append(symbol);
                Console.WriteLine("RororR: " + rotorR.GetRotor());
                Console.WriteLine("RororM: " + rotorM.GetRotor());
                Console.WriteLine("RororL: " + rotorL.GetRotor());



                if (posL == 0)
                {
                    if (rotorM.isRevolution)
                    {
                        rotorL.MoveRotor(1);
                    }
                    rotorR.MoveRotor(posR);
                    rotorM.MoveRotor(posM);
                }
                else if(posM==0)
                {
                    if (rotorR.isRevolution)
                    {
                        rotorM.MoveRotor(1);
                    }
                    rotorR.MoveRotor(posR);
                    rotorL.MoveRotor(posL);
                }
                else
                {
                    rotorR.MoveRotor(posR);
                    rotorM.MoveRotor(posM);
                    rotorL.MoveRotor(posL);
                }
            }

            return result.ToString();
        }
    }
}
