using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Factory Method Pattern [工廠方法模式]
namespace Design_Pattern_Example.FactoryMethodPattern
{
    /*
        在簡單工廠模式中,會因為種類變多而變得更複雜,耦合度會相對提高,為了應付這個問題,我們將建置的工廠再切分成各個小類
        將建置"工廠"(Factory Pattern是使用static)和"物件"都變成多個class來使用

        優點:當種類很多時將工廠切開來會有很大的幫助,降低耦合度
        缺點:code會變得更加複雜

        簡單來說就是,分成很多個工廠,各個工廠都有自己製作的東西
        我們看需要什麼物品再選擇哪個工廠來用

        工廠是依照物品的種類來區分
    */
    class FactoryMethod
    {
        //static void Main(string[] args)
        //{
        //    //呼叫工廠的介面和要建置物件的介面,再藉由要實作的物件來使用
        //    ToyManagerOrigin toyManager;
        //    Toy toy;

        //    toyManager = new ToyManagerAdult();//只修改了工廠就可以得到不同的結果
        //    toy = toyManager.CreateToy();
        //    toy.makeToy();

        //    toyManager = new ToyManagerChildern();
        //    toy = toyManager.CreateToy();
        //    toy.makeToy();

        //    Console.ReadLine();
        //}
    }

    //工廠的最初類
    interface ToyManagerOrigin
    {     
        Toy CreateToy();
    }
    //各種工廠的類
    class ToyManagerChildern:ToyManagerOrigin
    {
        public Toy CreateToy()
        {
            return new ChildrenToy();
        } 
    }
    class ToyManagerAdult : ToyManagerOrigin
    {
        public Toy CreateToy()
        {
            return new AdultToy();
        }
    }


    //一個介面,多個實作
    interface Toy
    {
        void makeToy();
    }

    class AdultToy : Toy
    {
        public void makeToy()
        {
            Console.WriteLine("得到一隻按摩棒");
        }
    }
    class ChildrenToy : Toy
    {
        public void makeToy()
        {
            Console.WriteLine("得到一台玩具車");
        }
    }


}
