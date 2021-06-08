using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class ElGamal
    {
        private Random random = new Random();
        private BigInteger p, g, x, y;
        private string hash = "";
        public static string res="";

        private BigInteger GeneratePrimeNumber()
        {
            BigInteger number = random.Next(4, 1000);
            while (!GCD.IsSimple(number))
            {
                number = random.Next(4, 1000);
            }
            return number;
        }

        public int GetPRoot(BigInteger p)
        {
            for (int i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return 0;
        }

        public bool IsPRoot(BigInteger p, BigInteger a)
        {
            if (a == 0 || a == 1)
                return false;
            BigInteger last = 1;
            HashSet<BigInteger> set = new HashSet<BigInteger>();
            for (int i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last))
                    return false;
                set.Add(last);
            }
            return true;
        }

        public ElGamal()
        {
            res = "";
            p = GeneratePrimeNumber();
            g = GetPRoot(p);
            x = random.Next(2, (int)p);
            y = BigInteger.ModPow(g, x, p);
            res+=$"p = {p}, g = {g}, x = {x}, y = {y}\n";
            res+=$"PUBLIC KEY: (p, g, y) = ({p}, {g}, {y})";
            res+=$"PRIVATE KEY: (p, g, x) = ({p}, {g}, {x})";
        }

        public BigInteger[,] CreateDigitalSign(string text)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                hash = MD5Hash.GetMd5Hash(md5Hash, text);
            }
            byte[] bytes = Encoding.ASCII.GetBytes(hash);
            BigInteger[,] digitalSign = new BigInteger[bytes.Length, 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                do
                {
                    BigInteger k = random.Next(2, (int)p - 2);
                    while (GCD.GetNOD(k, p - 1) != 1)
                    {
                        k = random.Next(2, (int)p - 2);
                    }
                    digitalSign[i, 0] = BigInteger.ModPow(g, k, p);
                    BigInteger temp = BigInteger.Multiply(BigInteger.Subtract(bytes[i], BigInteger.Multiply(x, digitalSign[i, 0])), GCD.ModInverse(k, p - 1));
                    digitalSign[i, 1] = temp < 0 ? (p - 1) - BigInteger.ModPow(BigInteger.Negate(temp), 1, p - 1) : BigInteger.ModPow(temp, 1, p - 1);
                } while (digitalSign[i, 1] == 0);
            }
            return digitalSign;
        }

        public bool VerifyDigitalSign(string text, BigInteger[,] digitalSign)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                hash = MD5Hash.GetMd5Hash(md5Hash, text);
            }
            byte[] hashBytes = Encoding.ASCII.GetBytes(hash);
            bool result = true;
            for (int i = 0; i < digitalSign.GetUpperBound(0) + 1; i++)
            {
                BigInteger leftPart = BigInteger.ModPow(g, hashBytes[i], p);
                BigInteger rightPart = BigInteger.ModPow(BigInteger.Multiply(BigInteger.Pow(y, (int)digitalSign[i, 0]), BigInteger.Pow(digitalSign[i, 0], (int)digitalSign[i, 1])), 1, p);
                bool compareResult = leftPart == rightPart;
                result = result && compareResult;
            }
            return result;
        }
    }
}
