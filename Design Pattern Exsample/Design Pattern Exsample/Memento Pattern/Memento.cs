using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Memento Pattern [備忘錄模式]
namespace Design_Pattern_Exsample.Memento_Pattern
{
    /*
        記住目前的狀態,就像是遊戲存檔的紀錄點,讓我們需要時可以讀取回來
        跟Prototy Pattern差別在於,Prototy是將整個物件Clone一個出來,而Memento只是將數值存下來

        像是瀏覽器中的上一步功能和遊戲的存檔功能就是備忘錄模式的體現方式

        複習:
        方法傳送參數要是Object時,只是傳送記憶體的位置而已,所以他們其實都是指向"同一個本體"
        要是"基本型別"的話才會直接複製出一個新的空間出來
    */
    class Memento
    {
        static void Main(string[] args)
        {
            Hero play1 = new Hero(100, 10, 15);
            StoragePoint storagePoint = new StoragePoint();
            storagePoint.SaveHero(play1);
            play1.ShowHero();//原本的數值

            play1.hp -= 20;
            play1.sp -= 10;

            play1.ShowHero();
            storagePoint.LoadHero(play1);

            play1.ShowHero();//因為物件都是傳址呼叫的關係,數值已經直接被更改了

            Console.ReadLine();
        }
    }

    class Hero
    {
        public int hp;
        public int sp;
        public int atk;
        public Hero(int hp,int sp,int atk)
        {
            this.hp = hp;
            this.sp = sp;
            this.atk = atk;
        }
        public void ShowHero()
        {
            Console.WriteLine("HP:" + hp + "  SP:" + sp + "  ATK:" + atk);
        }
    }
    //一個純檔點
    class StoragePoint
    {
        int hp = 0;
        int sp = 0;
        int atk = 0;
        public void SaveHero(Hero hero)
        {
            hp = hero.hp;
            sp = hero.sp;
            atk = hero.atk;
        }
        public void LoadHero(Hero hero)
        {
            hero.hp = hp;
            hero.sp = sp;
            hero.atk = atk;
        }
    }
}
