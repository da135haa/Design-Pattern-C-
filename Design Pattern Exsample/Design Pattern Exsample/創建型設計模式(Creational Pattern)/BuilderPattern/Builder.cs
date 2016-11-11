using System;


//Builder Pattern [產生器模式]
namespace Design_Pattern_Exsample.BuilderPattern
{
    /*
         分成建造者和被建造的物件

         被建造的物件:使用多型的方式,同一個origin各自分支下去,都會有共同的一系列動作
         建造者:裡面會有一個方法已經設置好一系列的動作,藉由著傳入的物件來執行不同的內容

    */
    class Builder
    {
        //static void Main(string[] args)
        //{
        //    BuilderManager builderManger = new BuilderManager();//建立的創建者
        //    People people;

        //    people = new Swordsman();//經由建立實體的物件不同,所執行的一系列動作也會不相同
        //    builderManger.setPeople(people);
        //    builderManger.PeopleGo();

        //    Console.WriteLine("-------------------------");

        //    people = new Magician();
        //    builderManger.setPeople(people);
        //    builderManger.PeopleGo();

        //    Console.ReadLine();
        //}
    }

    //建造者
    class BuilderManager
    {
        private People people;

        public void setPeople(People people)
        {
            this.people = people;
        }

        public void PeopleGo()//制定好一系列的動作
        {
            people.Run();
            people.Run();
            people.Magic();
            people.Attack();
            people.Jump();
        }
    }

    //被建造物件
    interface People
    {
        void Jump();
        void Attack();
        void Magic();
        void Run();
    } 

    class Swordsman : People
    {
        public void Jump()
        {
            Console.WriteLine("劍士使用了二段跳");
        }
        public void Attack()
        {
            Console.WriteLine("劍士使用了劈砍");
        }
        public void Magic()
        {
            Console.WriteLine("劍士放不出法術");
        }
        public void Run()
        {
            Console.WriteLine("劍士往前移動了一大段距離");
        }
    }

    class Magician : People
    {
        public void Jump()
        {
            Console.WriteLine("魔法師微微的跳起來");
        }
        public void Attack()
        {
            Console.WriteLine("魔法師使用了微弱的揮擊");
        }
        public void Magic()
        {
            Console.WriteLine("魔法師放出強大的火球樹");
        }
        public void Run()
        {
            Console.WriteLine("魔法師往前移動了一小格");
        }
    }
}
