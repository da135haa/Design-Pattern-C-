using System;

//Factory Pattern [簡單工廠模式]
namespace Design_Pattern_Exsample.FactoryPattern
{
    /*
    跟Singleton有點像,但是多了每次使用都要指定要用哪個物件
    跟Strategy有點像,但不需要自己建立實體物件
    */
    //class Factory
    //{
    //    static void Main(string[] args)
    //    {
    //        Toy toy;
    //        toy = ToyManager.CreateToy("成人");
    //        toy.getToy();
    //        toy = ToyManager.CreateToy("兒童");
    //        toy.getToy();
    //        toy = ToyManager.CreateToy("小人");
    //        toy.getToy();//這時收到之前的物件
    //        Console.ReadLine();
    //    }
    //}

    //控制物件(工廠)
    class ToyManager
    {
        private static Toy toy;

        public static Toy CreateToy(string flag)
        {
            if(flag == "成人")
            {
                toy = new AdultToy();
            }
            else if(flag == "兒童")
            {
                toy = new ChildrenToy();
            }
            else
            {
                Console.WriteLine("沒有此物件");
            }

            return toy;
        }
    }

    //一個介面,多個實作
    interface Toy
    {
        void getToy();
    }

    class AdultToy : Toy
    {
        public void getToy()
        {
            Console.WriteLine("得到一隻按摩棒");
        }
    }
    class ChildrenToy : Toy
    {
        public void getToy()
        {
            Console.WriteLine("得到一台玩具車");
        }
    }
}
