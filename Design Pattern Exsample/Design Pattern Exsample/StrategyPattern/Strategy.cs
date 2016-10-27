using System;

//Strategy Pattern[策略模式]
namespace Design_Pattern_Exsample.StrategyPattern
{
    //參考https://dotblogs.com.tw/nobel12/2011/01/21/20947

    /*
    當一個"重複的動作各個類別都需要做"時,就可以使用這個策略模式
    1.一個介面類別,裡面會有各個需要實作的共同方法。
    2.將各種類別繼承並且實作出方法
    3.運用一個負責控制的類別,使用多型的方式來制定要做的事情
    4.main類別呼叫控制類別,接著藉由著傳入的實體,來判斷會運用哪一個類
    */

    //class main
    //{
    //    static void Main(string[] args)
    //    {
    //        PeopleControl sp = new PeopleControl(new Man());
    //        sp.doWork();
    //        sp.setPeople(new Girl());
    //        sp.doWork();

    //        Console.Read();
    //    }
    //}

    class PeopleControl
    {
        private people p;

        public PeopleControl(people p)
        {
            this.p = p;
        }
        public void setPeople(people p)
        {
            this.p = p;
        }
        public void doWork()
        {
            Console.WriteLine("做了一系列的研究" + p.self());
        }
    }

    interface people
    {
        string self();
    }

    public class Man:people
    {
        public string self()
        {
            return "我是男生";
        }
    }

    public class Girl : people
    {
        public string self()
        {
            return "我是女生";
        }
    }

}
