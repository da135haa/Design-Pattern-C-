using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Abstract Factory Pattern [抽象工廠模式]
namespace Design_Pattern_Exsample.AbstractFactoryPattern
{
    /*
        假設"同一種東西但卻有不同品牌",這時就會使用到這個設計模式
        A工廠生產大人玩具和小孩玩具、B工廠也是生產大人玩具和小孩玩具

        工廠:
        一個父類和多個廠牌的子類工廠
        工廠產出的物件:
        從多個不同屬性物件繼承同一個父類物件,改成各種屬性的物件繼承自己的父類,並且分支出廠牌
        就像範例中是使用"玩具車"來當成最根部父類了,而不是使用"玩具"這個統稱來當作最基礎的父類

        好處:易於擴充,耦合度低
        壞處:類別爆炸多     
        工廠所生成的品項都相同,是依照物品的廠牌來區分           
    */
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            ToyManagerOrigin toyManager;
            ToyCar toyCar;
            ToyStick toyStick;

            toyManager = new ToyManager_A();//使用A牌的工廠,所製造出來的東西都會是A牌的
            toyCar = toyManager.CreateCarToy();
            toyStick = toyManager.CreateStickToy();
            toyCar.makeToy();
            toyStick.makeToy();

            toyManager = new ToyManager_B();//使用B牌的工廠,所製造出來的東西都會是A牌的
            toyCar = toyManager.CreateCarToy();
            toyStick = toyManager.CreateStickToy();
            toyCar.makeToy();
            toyStick.makeToy();

            Console.ReadLine();
        }
    }


    //工廠的最初類
    interface ToyManagerOrigin
    {
        ToyCar CreateCarToy();
        ToyStick CreateStickToy();
    }
    //兩個廠牌所生產的東西
    class ToyManager_A : ToyManagerOrigin
    {
        public ToyCar CreateCarToy()
        {
            return new ChildrenToyCar_A();
        }
        public ToyStick CreateStickToy()
        {
            return new AdultToyStick_A();
        }
    }
    class ToyManager_B : ToyManagerOrigin
    {
        public ToyCar CreateCarToy()
        {
            return new ChildrenToyCar_B();
        }
        public ToyStick CreateStickToy()
        {
            return new AdultToyStick_B();
        }
    }

    //兩種類型的玩具,各自有各自分支
    interface ToyCar
    {
        void makeToy();
    }
    class ChildrenToyCar_A : ToyCar
    {
        public void makeToy()
        {
            Console.WriteLine("得到一台玩具車,A牌的");
        }
    }

    class ChildrenToyCar_B : ToyCar
    {
        public void makeToy()
        {
            Console.WriteLine("得到一台玩具車,B牌的");
        }
    }

    interface ToyStick
    {
        void makeToy();
    }
    class AdultToyStick_A : ToyStick
    {
        public void makeToy()
        {
            Console.WriteLine("得到一隻按摩棒,A牌的");
        }
    }
    class AdultToyStick_B : ToyStick
    {
        public void makeToy()
        {
            Console.WriteLine("得到一隻按摩棒,B牌的");
        }
    }



}
