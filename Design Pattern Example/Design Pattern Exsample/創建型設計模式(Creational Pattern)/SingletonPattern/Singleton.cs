using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    用在只想出現一個單獨的實體物件時
    好處:在物件需要產生時再產出、永遠只會有一個物件、不需要設定多個static
    跟直接設定成static不同的部分:記憶體位置一個在stack 一個在heap    
    不是全部語言都有static
*/
namespace Design_Pattern_Example.SingletonPattern
{
    //class main
    //{
    //    static void Main(string[] args)
    //    {
    //        SingletonProject.Instance().talk();
    //        SingletonProject.Instance().talk2();
    //        Console.Read();
    //    }
    //}

    class SingletonProject
    {
        //不能直接刪除他,當呼叫時就會自動判斷有無實體,沒有的話會自己創立
        static SingletonProject instance;

        public static SingletonProject Instance()
        {
            if (instance == null)
                instance = new SingletonProject();

            return instance;
        }

        public void talk()
        {
            Console.WriteLine("我已經有實體瞜");
        }

        public void talk2()
        {
            Console.WriteLine("隨便呼叫、直接使用");
        }

    }
}
