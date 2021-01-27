using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_Crypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> primes = GetPrimes(1000);
            int p = random.Next(1, primes.Count);
            int pervoobrazKoren = GFG.findPrimitive(p);

            while (pervoobrazKoren<0)
            {
                p = random.Next(1, primes.Count);
                pervoobrazKoren = GFG.findPrimitive(p);
            }

            Console.WriteLine("Smallest primitive root of " + p + " is " + GFG.findPrimitive(p));

            int x = GetVzaimnoProstoe(random.Next(2,p-1),p,random);
            Console.WriteLine($"Vzaimo prostoe x: {x}");

            double y = Math.Pow(pervoobrazKoren, x) * p % 10;

            string mes = "abc";
            string mesNums="";
            foreach (var letter in mes)
            {
                mesNums += Convert.ToString((int)letter);
            }

            double a=0;
            double b=0;
            if (mes.Length<p)
            {
                int k = GetVzaimnoProstoe(random.Next(2, p - 1), p, random);
                a = Math.Pow(pervoobrazKoren, k) * p % 10;
                b = Math.Pow(y, k) * int.Parse(mesNums) * p % 10;
            }

            Console.WriteLine($"Шифротекст:({a},{b})");
            

            Console.ReadLine();

        }

        public static List<int> GetPrimes(int n)
        {

            bool[] is_prime = new bool[n + 1];
            for (int i = 2; i <= n; ++i)
            {
                is_prime[i] = true;
            }

            List<int> primes = new List<int>();

            for (int i = 2; i <= n; ++i)
                if (is_prime[i])
                {
                    primes.Add(i);
                    if (i * i <= n)
                        for (int j = i * i; j <= n; j += i)
                            is_prime[j] = false;
                }

            return primes;
        }

        public static int GetVzaimnoProstoe(int p,int x,Random random)
        {
            while (x>1 && x<-1 && GCD(p-1,x)==1)
            {
                p = random.Next(1,p-1);
            }
            return p;
        }

        static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                while (b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                return a;
            }
        }
    }
}
