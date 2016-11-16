using System;

//Chain_of_responsibility Pattern [責任鏈模式]
namespace Design_Pattern_Example.Chain_of_responsibilityPattern
{
    /*
        跟狀態模式極為相似,差別只在於"責任鏈模式"是將串連的動作放在Clien端做,但"狀態模式"卻是已經封裝在每個類別中
        兩個相較來說"責任鏈模式"可以更靈活的控制階層關係     
    */
    class Chain_of_responsibility
    {
        //static void Main(string[] args)
        //{
        //    Player player = new Player();
        //    player.StateWork(60);//輸入等級
        //    player.StateWork(23);
        //    player.StateWork(101);

        //    Console.ReadLine();
        //}
    }

    public class Player//負責組裝責任鏈的面相Clien類
    {
        private ResponsibilityOrigin chain;

        public Player()
        {
            chain = new PlayerLogic_LV100(new PlayerLogic_LV50(new PlayerLogic_LV10(null)));//連接責任鏈
        }
        public void StateWork(int level)
        {
            chain.StateWork(level);
        }
    }

    public abstract class ResponsibilityOrigin//最基礎的抽象類
    {
        protected ResponsibilityOrigin responsibilityOrigin;
        public ResponsibilityOrigin(ResponsibilityOrigin responsibilityOrigin)
        {
            this.responsibilityOrigin = responsibilityOrigin;
        }
        public abstract void StateWork(int level);
    }

    public class PlayerLogic_LV100 : ResponsibilityOrigin//每一個類都專注負責於自己的一份工作
    {
        public PlayerLogic_LV100(ResponsibilityOrigin responsibilityOrigin) :base(responsibilityOrigin)
        {

        }
        public override void StateWork(int level)
        {
            if (level > 100)
            {
                Console.WriteLine("等級高於100,神");
            }
            else
            {
                responsibilityOrigin.StateWork(level);//當條件都不符合時,就丟給下一個class

            }
        }
    }
    public class PlayerLogic_LV50 : ResponsibilityOrigin
    {
        public PlayerLogic_LV50(ResponsibilityOrigin responsibilityOrigin) : base(responsibilityOrigin)
        {

        }
        public override void StateWork(int level)
        {
            if (level > 50)
            {
                Console.WriteLine("等級高於50,普通");
            }
            else
            {
                responsibilityOrigin.StateWork(level);
            }
        }
    }
    public class PlayerLogic_LV10 : ResponsibilityOrigin
    {
        public PlayerLogic_LV10(ResponsibilityOrigin responsibilityOrigin) : base(responsibilityOrigin)
        {

        }
        public override void StateWork(int level)
        {
            if (level >= 10)
            {
                Console.WriteLine("等級高於10,新手");
            }
            else
            {
                Console.WriteLine("等級低於10,還未出新手村");
            }
        }
    }

}
