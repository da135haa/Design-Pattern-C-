using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adapter Pattern [適配器模式]
namespace Design_Pattern_Example.AdapterPattern
{
    /*
        轉接器故名思義，在真實世界中，我們常常會看到，像是三孔轉兩孔的電源插頭、不同國家電壓切換的旅行用轉接頭。透過轉接器的轉換，就可以讓不同的裝置取得電力或是資訊！
        在物件導向的轉接器是什麼呢？
        假如我們有一套軟體系統，希望和其他廠商即有的程式庫搭配使用，但是這個新廠商所設計出來的介面，不同於舊廠商的介面。
        你一定不會想改變既有的程式碼來解決這個問題，而我們也無法改變廠商的程式碼。
        轉接器類別就此誔生！我們可以寫一個類別，將新廠商介面轉接成我們所期盼的介面吧！

        這模式的重點在於原本訂好的工作流程可以不變動
        備註:
        這例子是使用將類別的實例包在Adpater的方式,稱為Object Adapter Pattern (對象適配器模式)
        要是使用的是可以多重繼承的語言,可以一次將需要轉換的兩個類別直接繼承下來實作,稱為Class Adapter Pattern (類適配器模式)
    */
    class Adapter
    {
        //static void Main(string[] args)
        //{
        //    //這邊就可以看是要使用哪一個物件就好,後面原本寫好的工作流程完全不用變動

        //    //MyAPI myAPI = new MyAPI();
        //    //CompanyAPI_A_Adapter myAPI = new CompanyAPI_A_Adapter();
        //    CompanyAPI_B_Adapter myAPI = new CompanyAPI_B_Adapter();

        //    myAPI.socketConnection();
        //    myAPI.stringConversion();
        //    myAPI.httpConnection();

        //    Console.ReadLine();
        //}
    }

    class MyAPI//自己原本使用的api
    {
        protected string site = "http//test.com";

        public  void socketConnection()
        {
            Console.WriteLine("使用了socket.io的方式連線");
        }
        public void stringConversion()
        {
            Console.WriteLine("使用了json格式轉換");
        }
        public void httpConnection()
        {
            Console.WriteLine("連接http:"+ site);
        }
    }

    class CompanyAPI_A//廠商的api
    {
        public void socketConnection()
        {
            Console.WriteLine("廠商A:使用了WebSocket的方式連線");
        }
        public void stringConversion()
        {
            Console.WriteLine("廠商A:使用了MsgPack格式轉換");
        }
    }

    class CompanyAPI_B//廠商的api
    {
        public void socketConnection()
        {
            Console.WriteLine("廠商B:使用了WebSocket的方式連線");
        }
        public void httpConnection(string site)//假設這家廠商連http的api需要自己設定網址而不是封裝在裡面了
        {
            Console.WriteLine("廠商B:連接http:" + site);
        }
    }

    //將廠商api轉換成我們自己的API介面,這一個個Adapter就像是插座的轉接頭
    class CompanyAPI_A_Adapter: MyAPI//繼承原本的api來讓所有原本工作的方法都能相容,要是沒有更改的就是使用原本的API方法
    {
        public CompanyAPI_A companyAPI_A;//設置public 假設companyAPI_A有我們本來api沒有的功能也可以直接呼叫使用
        public CompanyAPI_A_Adapter()
        {
            companyAPI_A = new CompanyAPI_A();
        }
        public new void socketConnection()
        {
            companyAPI_A.socketConnection();
        }
        public new void stringConversion()
        {
            companyAPI_A.stringConversion();
        }
    }

    //要是有對為什麼要建立兩個轉接口而不能共用有所疑問的,可以想想三孔轉接頭跟四孔轉接頭能不能共用?
    class CompanyAPI_B_Adapter : MyAPI
    {
        public CompanyAPI_B companyAPI_B;
        public CompanyAPI_B_Adapter()
        {
            companyAPI_B = new CompanyAPI_B();
        }
        public new void socketConnection()
        {
            companyAPI_B.socketConnection();
        }
        public new void httpConnection()//就算方法不同,也可以直接封裝進去
        {
            companyAPI_B.httpConnection(site);
        }
    }

}
