using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Facade Pattern [外觀模式]
namespace Design_Pattern_Exsample.FacadePattern
{
    /*
        各個功能class和User中間會有一個外觀的class,負責將各個功能建立物件出來,而User只需要操控外觀class就可以控制各個功能
        簡單來說就是只提供給User一個入口而已

        優點:對使用者來說簡單好使用、方便好管理、移植專案時方便(偶合度低)
        缺點:較缺少靈活性、增加新功能需要更改原碼(違背了"關閉原則")
    */

    class Facade
    {
        //static void Main(string[] args)
        //{
        //    //只需要操控一個物件就可以使用各種功能
        //    InternetManager internet = new InternetManager();
        //    internet.http.GetHttp();
        //    internet.json.ToJson("test");
        //    internet.socket.GetSocket();

        //    Console.ReadLine();
        //}
    }

    //集結一些網路會用到的工具
    class InternetManager
    {
        public Socket socket { get;private set; }
        public Http http{ get;private set; }
        public Json json{ get;private set; }

        public InternetManager()
        {
            socket = new Socket();
            http = new Http();
            json = new Json();
        }        
    }

    //各個功能類
    class Socket
    {
        public void GetSocket()
        {
            Console.WriteLine("連上Socket");
        }
    }
    class Http
    {
        public void GetHttp()
        {
            Console.WriteLine("連上網路");
        }
    }
    class Json
    {
        public void ToJson(string s)
        {
            Console.WriteLine("將" + s + "轉換成Json格式");
        }
    }




}
