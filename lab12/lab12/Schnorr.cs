using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Schnorr
    {
        private Random random = new Random();
        private BigInteger p = 48731, q, g, x, y;
        private string hash = "";
        public static string res = "";

        private BigInteger GeneratePrimeNumber()
        {
            BigInteger number;
            do
            {
                number = random.Next(100, 500);
            } while (!GCD.IsSimple(number));
            return number;
        }

        public Schnorr()
        {
            res = "";
            do
            {
                q = GeneratePrimeNumber();
            } while ((p - 1) % q != 0);
            do
            {
                g = random.Next(10000, 15000);
            } while (g == 1 || BigInteger.ModPow(g, (int)q, p) != 1);
            do
            {
                x = random.Next((int)q);
            } while (x >= q);
            y = GCD.ModInverse(BigInteger.ModPow(g, x, p), p);
            res+=$"p = {p}, q = {q}, g = {g}, x = {x}, y = {y}\n";
            res+=$"PUBLIC KEY: (p, q, g, y) = ({p}, {q}, {g}, {y})";
            res+=$"PRIVATE KEY: (x) = ({x})";
        }

        public BigInteger[,] CreateDigitalSign(string text)
        {
            BigInteger k;
            do
            {
                k = random.Next();
            } while (!(k > 1 && k < q));
            BigInteger a = BigInteger.ModPow(g, k, p);
            text += a;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = MD5Hash.GetMd5Hash(md5Hash, text);
            }
            byte[] bytes = Encoding.ASCII.GetBytes(hash);
            BigInteger[,] digitalSign = new BigInteger[bytes.Length, 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                digitalSign[i, 0] = bytes[i];
                digitalSign[i, 1] = BigInteger.Add(k, BigInteger.Multiply(x, bytes[i])) % q;
            }
            return digitalSign;
        }

        public bool VerifyDigitalSign(string text, BigInteger[,] digitalSign)
        {
            BigInteger x = BigInteger.Multiply(BigInteger.ModPow(g, (int)digitalSign[0, 1], p), BigInteger.ModPow(y, (int)digitalSign[0, 0], p)) % p;
            text += x;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = MD5Hash.GetMd5Hash(md5Hash, text);
            }
            byte[] bytes = Encoding.ASCII.GetBytes(hash);
            return bytes.SequenceEqual(Enumerable.Range(0, digitalSign.GetLength(0)).Select(i => (byte)digitalSign[i, 0]).ToArray());
        }
    }
}
