using System;

//Template Method Pattern [模板方法模式]
namespace Design_Pattern_Exsample.Template_Method_Pattern
{
    /*
        假設有一個固定的工作流程,但其中一個環節需要動態的,那就適合使用這個模式
        例如去銀行辦事的工作流程是:取號碼牌 > "辦事情" > 給工作人員打分數  (辦事情可能會有各種不同的處理方式,但取號碼牌和給工作人員打分數都是一樣的)

        此設計模式算是較常使用的一種,算是很重要的基礎概念

        總結:將不變的部分移到父類別，去除子類別重覆的程式碼

        優點:代碼可以重複使用,更加符合"單一職責原則",使得類的內聚性得以提高
        缺點:每一個功能都需要定義一個子類,會使類別越來越多
    */
    class TemplateMethod
    {
        //static void Main(string[] args)
        //{
        //    Loan loan = new Loan();//使用貸款的物件
        //    loan.Process();

        //    Console.ReadLine();
        //}
    }

    //一個最原始的抽象類
    public abstract class Bank
    {
        public void Process()
        {
            Console.WriteLine("銀行辦事流程");
            DrawNumber();
            Work();
            Score();
        }
        public void DrawNumber()
        {
            Console.WriteLine("抽號碼牌");
        }

        public abstract void Work();//經由繼承下來的類來實作

        public void Score()
        {
            Console.WriteLine("打分數");
        }
    }

    //兩種實作類
    public class Loan : Bank
    {
        public override void Work()
        {
            Console.WriteLine("辦理貸款");
        }
    }

    public class FixedDeposit : Bank
    {
        public override void Work()
        {
            Console.WriteLine("辦理定存");
        }
    }

}
