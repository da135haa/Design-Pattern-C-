using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bridge Pattern [橋接模式]
namespace Design_Pattern_Example.BridgePattern
{
    /*
        使用的電視和遙控器的例子,遙控器可以操控電視,此設計模式的關鍵價值在於"遙控器"上面
        
        遙控器的code中"本身沒有電視的相關動作",只是先跟電視配對後,藉由傳訊息給電視,再由"電視本身的code自己來做動作"
        就像現實中電視遙控器所做的事情也只是傳送紅外線給電視而已

        優點:讓類別間可以各自獨立變化,減少它們之間的耦合
        缺點:code會更為複雜
    */
    class Bridge
    {
        //static void Main(string[] args)
        //{
        //    RemoteControl remoteControl = new RemoteControl(new ChangHong());//一個萬用的遙控器控制了ChangHong電視
        //    remoteControl.Off();
        //    remoteControl.On();
        //    remoteControl.NextChannel();

        //    remoteControl = new RemoteControl(new Samsung());//Samsung
        //    remoteControl.Off();
        //    remoteControl.On();
        //    remoteControl.NextChannel();

        //    Console.ReadLine();
        //}
    }

    //一個電視的抽象類,會有各種基本功能
    abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void NextChannel();
    }
    //兩種廠牌的電視實作
    class ChangHong : TV
    {
        public override void On()
        {            
            Console.WriteLine("ChangHong:開電視");
        }
        public override void Off()
        {
            Console.WriteLine("ChangHong:關電視");
        }
        public override void NextChannel()
        {
            Console.WriteLine("ChangHong:下一台");
        }
    }
    class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("Samsung:開電視");
        }
        public override void Off()
        {
            Console.WriteLine("Samsung:關電視");
        }
        public override void NextChannel()
        {
            Console.WriteLine("Samsung:下一台");
        }
    }

    //一個遙控器,需要更複雜時也可以使用抽象的方式來製作更多廠牌的遙控
    class  RemoteControl
    {
        private TV tv;

        public RemoteControl(TV tv)
        {
            this.tv = tv;
        }

        public void On()
        {
            tv.On();
        }
        public void Off()
        {
            tv.Off();
        }
        public void NextChannel()
        {
            tv.NextChannel();
        }
    }

}
