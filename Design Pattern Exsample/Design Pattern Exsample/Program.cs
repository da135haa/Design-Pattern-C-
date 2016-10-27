using Design_Pattern_Exsample.SingletonPattern;
using Design_Pattern_Exsample.StatePattern;
using Design_Pattern_Exsample.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Pattern_Exsample
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleControl sp = new PeopleControl(new Man());
            sp.doWork();
            sp.setPeople(new Girl());
            sp.doWork();

            Console.Read();
        }
    }
}
