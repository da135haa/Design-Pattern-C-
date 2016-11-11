using System;

//Proxy Pattern [代理模式]
namespace Design_Pattern_Exsample.ProxyPattern
{
    /*
        在訪問和被訪問者之間建立一個中間層,這層控制能不能被訪問、是否創造物件等相關功能

        會用到的元件:介面、功能類、中間層(Proxy)類

        此模式架構跟裝飾模式很相近,但是著重的點不太一樣
        裝飾模式:著重於"動態的添加方法",功能類會像是參數般的傳入
        代理模式:著重於"控制對象的訪問",功能類會在訪問Proxy時,Proxy裡面在自己判斷要不要建置
        
        總結:
        使用代理模式代表對象之間的關係在編譯時就已經確定了,而裝飾模式能在運行階段時動態的建立關係
        但他們共同都有類似加強一個方法各種功能的概念
      
        優點:
        降低系耦合度
        高擴展性

        缺點:
        溝通間增加了代理對象,某些時後會使程式速度變慢
        程式會變得更為複雜
    */

    class Proxy
    {
        //static void Main(string[] args)
        //{
        //    //這邊只需要建立Proxy物件並且執行需要的功能,不需要自行建立其它物件
        //    ProxyImage image = new ProxyImage("Steven","test.jpg");
        //    image.display();

        //    image = new ProxyImage("大頭", "test.jpg");
        //    image.display();

        //    Console.ReadLine();
        //}
    }
    public interface Image//最原始的介面
    {
        void display();
    }

    public class RealImage : Image//一個功能類
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }

        public void display()
        {
            Console.WriteLine("展示圖檔:" + fileName);
        }

        private void loadFromDisk(string fileName)
        {
            Console.WriteLine("讀取圖檔:" + fileName);
        }
    }

    //中間層,用來做權限的判斷和物件是否建立
    public class ProxyImage : Image
    {
        private RealImage realImage;

        private string fileName;
        private string name;

        public ProxyImage(string name, string fileName)
        {
            this.name = name;
            this.fileName = fileName;
        }

        public void display()//要是權限符合才會下載
        {
            if (name == "Steven")
            {
                if (realImage == null)
                {
                    realImage = new RealImage(fileName);
                }
                realImage.display();
            }
            else
                Console.WriteLine("你沒有權限");
        }
    }
}


