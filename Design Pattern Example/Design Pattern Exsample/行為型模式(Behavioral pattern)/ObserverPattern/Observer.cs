using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Observer Pattern [觀察者模式]
namespace Design_Pattern_Example.ObserverPattern
{
    /*
        流程上是會有一個"主題"和多個"觀察者"
        多個觀察者可以跟同一個主題綁定,當主題有訊息進入時,會發訊息給所有的訂閱者

        很多語言中的委派、Callback、Event都算是這個模式下的延伸
    */
    class Observer
    {
        //static void Main(string[] args)
        //{
        //    Hospital hospital = new Hospital();

        //    hospital.Add(new Doctors("小名"));
        //    hospital.Add(new Doctors("Steven"));
        //    hospital.Add(new Doctors("阿華"));
        //    hospital.Add(new Doctors("建宏"));

        //    hospital.Add(new Enginner("姍姍"));
        //    hospital.Add(new Enginner("大頭"));

        //    Enginner e = new Enginner("小詹");//要是物件還需要刪除,不能使用匿名,不然刪除時會找不到
        //    hospital.Add(e);
        //    hospital.Remove(e);

        //    hospital.Notify();

        //    Console.ReadLine();
        //}
    }

    abstract class ObserverManager//使用繼承的方式建立主題,好處可以建立各種不同的主題,使用abstract雖然不能直接用,但可以先將方法寫好使code不需要重寫
    {
        protected List<IObserver> iObserverList = new List<IObserver>();
        public void Add(IObserver iObserver)
        {
            iObserverList.Add(iObserver);
        }

        public void Remove(IObserver iObserver)
        {
            iObserverList.Remove(iObserver);
        }

        public abstract void Notify();//發給有訂閱的觀察者
    }

    class Hospital:ObserverManager
    {
        public override void Notify()//發給有訂閱的觀察者
        {
            Console.WriteLine("這邊是醫院,發給所有在醫院訂閱的人");
            foreach (var data in iObserverList)
            {
                data.Update();
            }
        }
    }

    abstract class IObserver//各種觀察者
    {
        protected string name;
        public IObserver(string name)
        {
            this.name = name;
        }
        public abstract void Update();
   
    }
    class Doctors : IObserver//醫生類型的觀察者
    {
        public Doctors(string name):base(name)
        {

        }
        public override void Update()
        {
            Console.WriteLine("收到訊息的是一名醫生:" + name);
        }

    }

    class Enginner : IObserver//工程師類型的觀察者
    {
        public Enginner(string name) : base(name)
        {

        }

        public override void Update()
        {
            Console.WriteLine("收到訊息的是一名工程師:" + name);
        }
    }


}
