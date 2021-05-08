using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var timer = new Stopwatch();
            var a = new BigInteger(13);
            var n = new BigInteger(Encoding.UTF8.GetBytes("13131139780205884014566051738979"));
            var x = new BigInteger(10);
            var xArray = new BigInteger[]
            {
                BigInteger.Pow(x, 3),
                BigInteger.Pow(x, 11),
                BigInteger.Pow(x, 27),
                BigInteger.Pow(x, 43),
                BigInteger.Pow(x, 56)
            };

            foreach (var num in xArray)
            {
                timer.Start();
                var y = BigInteger.ModPow(a, num, n);
                timer.Stop();
                Console.WriteLine($"y = {y}, a = {a}, n = {n}, x = {num},\n time = {timer.Elapsed}");

                timer.Reset();
            }

            Console.ReadKey();
        }
    }
}
