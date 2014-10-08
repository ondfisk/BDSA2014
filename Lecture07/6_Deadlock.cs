using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    public class Account
    {
        public string Name { get; private set; }
        
        public decimal Balance { get; private set; }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }

    public class Bank
    {
        public void Transfer(Account from, Account to, decimal amount)
        {
            from.Withdraw(amount);
            to.Withdraw(amount);
        }
    }

    public class Deadlock
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            var a = new Account("a", 100.0m);
            var b = new Account("b", 500.0m);

            var t1 = new Thread(() =>
            {
                lock (a)
                {
                    Thread.Sleep(500);
                    lock (b)
                    {
                        Thread.Sleep(500);
                        bank.Transfer(a, b, 100.0m);
                    }
                }
            });
            var t2 = new Thread(() =>
            {
                lock (b)
                {
                    Thread.Sleep(500);
                    lock (a)
                    {
                        Thread.Sleep(500);
                        bank.Transfer(a, b, 100.0m);
                    }
                }
            }); 
            //var t1 = new Thread(() =>
            //{
            //    Console.WriteLine("t1 aquiring lock on account {0}", a.Name);
            //    lock (a) 
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine("t1 lock aquired on account {0}", a.Name);
            //        Console.WriteLine("t1 aquiring lock on account {0}", b.Name);
            //        lock (b)
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("t1 lock aquired on account {0}", b.Name);
            //            bank.Transfer(a, b, 100.0m);
            //        }
            //        Console.WriteLine("t1 lock released on account {0}", b.Name);
            //    }
            //    Console.WriteLine("t1 lock released on account {0}", a.Name);
            //});
            //var t2 = new Thread(() =>
            //{
            //    Console.WriteLine("t2 aquiring lock on account {0}", b.Name);
            //    lock (b)
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine("t2 lock aquired on account {0}", b.Name);
            //        Console.WriteLine("t2 aquiring lock on account {0}", a.Name);
            //        lock (a)
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("t2 lock aquired on account {0}", a.Name);
            //            bank.Transfer(a, b, 100.0m);
            //        }
            //        Console.WriteLine("t2 lock released on account {0}", a.Name);
            //    }
            //    Console.WriteLine("t2 lock released on account {0}", a.Name);
            //});
            
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("Program terminated");
            Console.ReadKey();
        }
    }
}
