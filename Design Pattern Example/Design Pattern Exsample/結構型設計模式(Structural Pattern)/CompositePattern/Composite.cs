using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Composite Pattern [組合模式]
namespace Design_Pattern_Example.CompositePattern
{
    /*
        用於建立一組樹狀的結構、可以依照自己的用途規劃
        訣竅:"全部繼承於同一個base class",這樣方便制定"結構共有的方法",而且因為是同一個父類,放入時"可以使用同一個Type"

        好處:非常的自由而且萬用
        壞處:刪除元件時可能會不太方便
    */

    class Composite
    {
        //static void Main(string[] args)
        //{
        //    CompositeMenu compositeMenu = new CompositeMenu("資料表");

        //    CompositeMenu compositeMenuA = new CompositeMenu("A表單");
        //    compositeMenuA.add(new Element("Steven"));
        //    compositeMenuA.add(new Element("Elsa"));
        //    compositeMenuA.add(new Element("強生"));

        //    CompositeMenu compositeMenuB = new CompositeMenu("B表單");
        //    compositeMenuB.add(new Element("大頭"));
        //    compositeMenuB.add(new Element("小華"));
        //    compositeMenuB.add(new Element("阿明"));
        //    compositeMenuB.add(new Element("小詹"));

        //    CompositeMenu compositeMenuBB = new CompositeMenu("B表單分頁");
        //    compositeMenuBB.add(new Element("報到新生"));
        //    compositeMenuB.add(compositeMenuBB);


        //    compositeMenu.add(compositeMenuA);
        //    compositeMenu.add(compositeMenuB);

        //    compositeMenu.print();

        //    Console.ReadLine();
        //}
    }
}


abstract class MenuComponent//最原始有多功能用途的
{
    protected string name;
    public MenuComponent(string name)
    {
        this.name = name;
    }
    public abstract void print();
}

class CompositeMenu : MenuComponent//關鍵於蒐集結構資訊的
{
    List<MenuComponent> menuComponentList = new List<MenuComponent>();
    public CompositeMenu(string name):base(name)
    {
        
    }
    public void add(MenuComponent menuComponent)
    {
        menuComponentList.Add(menuComponent);
    }
    public override void print()//印出自己和取出自己所收集的內容
    {
        Console.WriteLine("----------------------");
        Console.WriteLine(name);
        Console.WriteLine("----------------------");

        foreach (var data in menuComponentList)
        {
            data.print();
        }
    }
}

class Element : MenuComponent//元件節點
{ 
    public Element(string name) : base(name)
    {

    } 
    public override void print()
    {
        Console.WriteLine(name);
    }
}



