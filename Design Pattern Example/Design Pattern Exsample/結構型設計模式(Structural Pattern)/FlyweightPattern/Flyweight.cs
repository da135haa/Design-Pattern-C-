using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Flyweight Pattern [享元模式]
namespace Design_Pattern_Example.FlyweightPattern
{
    /*
        盡量使物件重複使用而不是生成新的物件出來,有助於降低記憶體的消耗

        用在於一些大型物件的使用上:圖檔物件

        優點:可以盡可能降低內存中物件的數量、物件獨立後可以在其它地方被重複利用
        缺點:程式變得更為複雜
    */
    class Flyweight
    {
        //static void Main(string[] args)
        //{
        //    Hero warrior_A = new Hero("Steven", 5, 9, 1);
        //    Hero warrior_B = new Hero("大頭", 3, 1, 1);
        //    Hero Master_A = new Hero("宅男", 8, 7, 2);


        //    warrior_A.ShowMessage();
        //    Console.WriteLine();
        //    warrior_B.ShowMessage();
        //    Console.WriteLine();
        //    Master_A.ShowMessage();

        //    Console.ReadLine();
        //}
    }

    //照片的部份因為消耗資源過大,所以使用享元模式來達成重複利用的方式
    class Hero
    {
        private string name = "";
        private float x = 0;
        private float y = 0;
        private string picture="";//正常情況照片是object,目前用string是為了展示

        public Hero(string name,float x,float y,int pictureType)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.picture = PictureFactory.getPicture(pictureType);//使用照片工廠

        }
        public void SetX(float x)
        {
            this.x = x;
        }
        public void SetY(float y)
        {
            this.y = y;
        }
        public void setPicture(int pictureType)
        {
            this.picture = PictureFactory.getPicture(pictureType);
        }        
        public void ShowMessage()
        {
            Console.WriteLine(name);
            Console.WriteLine("X:" + x + "  Y:" + y);
            Console.WriteLine(picture);
        }       
    }
    //重點code,這邊負責接收資料,並判斷目前有沒有這筆物件,有的話就直接使用,沒有的話就做一個新的並存放
    public class PictureFactory
    {
        private static Dictionary<int, string> pictureMuster = new Dictionary<int, string>();

        public static string getPicture(int type)
        {
            if(pictureMuster.ContainsKey(type))
            {
                return pictureMuster[type];
            }

            //要是沒有該所引的話就做一個出來
            string hero = "";
            switch(type)
            {
                case 1:
                    hero = "戰士頭貼";
                    break;
                case 2:
                    hero = "魔法師頭貼";
                    break;
                case 3:
                    hero = "盜賊頭貼";
                    break;
            }
            
            pictureMuster.Add(type, hero);//放入集合中,下次會先檢查有無

            return hero;
        }
    }

  
}



