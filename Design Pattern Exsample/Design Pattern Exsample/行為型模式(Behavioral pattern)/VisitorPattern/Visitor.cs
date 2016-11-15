using System;
using System.Collections.Generic;

//Visitor Pattern [訪問者模式]
namespace Design_Pattern_Exsample.VisitorPattern
{
    /*
         http://blog.csdn.net/zhengzhb/article/details/7489639
        此模式的組成元素有兩個1.元素物件 2.元素的行為物件(訪問)
        適合此模式的條件有兩個 1.元素物件不會變動了 2.元素行為或數量頻繁的變動

        一個對象中存在著與自己不相關(或是關係較弱)的操作時,希望不影響原本的對象,可以將這些操作封裝到訪問者中去

        優點:優秀的擴展性、符合單一職責原則
        缺點:元素物件要更改比較困難、違反了最少知識原則、違反了依賴倒轉原則
    */
    class Visitor
    {
        static void Main(string[] args)
        {
            Element element1 = new ConcreteElement1();//元素1和元素2  要增加第3個就很麻煩
            Element element2 = new ConcreteElement2();

            element1.accept(new Visitors());//呼叫訪問者,但訪問者其實也只是用自己的方法
            element2.accept(new Visitors());


            Console.ReadLine();
        }
    }
 
    //訪問者的抽象
    abstract class Element
    {
        public abstract void accept(IVisitor visitor);
        public abstract void doSomething();
    }

    //一個訪問者搭配一個元素
    class ConcreteElement1 : Element
    {
        public override void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void doSomething()
        {
            Console.WriteLine("這是元素1");
        }
    }
    //一個訪問者搭配一個元素
    class ConcreteElement2 : Element
    {
        public override void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void doSomething()
        {
            Console.WriteLine("這是元素2");
        }
    }

    
    interface IVisitor
    {
        void visit(ConcreteElement1 el1);//2個元素在這邊就已經訂好了,是用多型的方式來區分元素
        void visit(ConcreteElement2 el2);
    }
    //訪問元素的實作
    class Visitors : IVisitor
    {
        public void visit(ConcreteElement1 el1)
        {
            el1.doSomething();
        }

        public void visit(ConcreteElement2 el2)
        {
            el2.doSomething();
        }
    }
}
