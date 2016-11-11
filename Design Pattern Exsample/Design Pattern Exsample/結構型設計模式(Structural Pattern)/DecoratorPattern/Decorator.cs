using System;

//Decorator Pattern [裝飾模式]
namespace Design_Pattern_Exsample.DecoratorPattern
{
    /* 
        此模式可以在物件上動態的加上其它功能物件,就像"增加資料片"的那種感覺

        真實世界中需求可能會一直有所異動,假設需求需要"更改一個已經寫好的function",而我們可以做的行為有
        1.直接更改那個function
        對於開發"封閉原則:對修改封閉,擴充開放" 不太建議使用這方法,要是整個類別已經建構完成,這樣隨意修改會有
        可能出錯的風險
        2.繼承class後再做功能的修正
        要是未來又有新功能或是需要將舊功能刪除時,這樣也可能會增加系統錯誤的風險

        而假設新加的這個功能是要可以給其他類別也使用時,上述的方式就更不適合了
        最好的方法就是不要修改已經通過測試的程式碼，這時設計就可以不採取繼承改採取"組合"的方式

        優點:可擴展性很好
        缺點:過度使用時,會有一大推的小對象類別出現,讓程序變得更複雜

        架構技巧在於不管是「被裝飾者」or「裝飾者」都會"共同繼承於一個父類",使它們可以被共用
        (因為裝飾物品功能套件可能是"直接面對被裝飾者"或是"接在其它裝飾者之後")

        此模式會使用到的類型物件有:主要物件、當成裝飾物品的功能物件

        此模式就是會在最初的父類class中設定方法,後面繼承的子類別再由功能各自＂加工那些方法＂,需要用時一層層建立實體套入即可
        
        而裝飾者物件放入建構物件這個動作代表著＂接在xxx物件之後＂，有一點Callback的感覺在裡面,這邊概念需要多思考一下才會清楚
    */

    class Decorator
    {
        //static void Main(string[] args)
        //{
        //    //最基本的報表,沒有任何判定
        //    SimpleReport simpleReport = new SimpleReport();
        //    simpleReport.Show();
        //    Console.WriteLine("");
        //    simpleReport.DownLoad();

        //    Console.WriteLine("--------------------------------------");

        //    //增加名子判定
        //    Authority authority = new Authority(simpleReport, "Steven");
        //    authority.Show();
        //    Console.WriteLine("");
        //    authority.DownLoad();

        //    Console.WriteLine("--------------------------------------");

        //    //像這樣將時間判定接在authority之後,這樣所執行的順序會是  時間判定過了 > 名子判定過了 > 表單內容
        //    SystemDate systemDate = new SystemDate(authority);
        //    systemDate.Show();
        //    Console.WriteLine("");
        //    systemDate.DownLoad();

        //    Console.ReadLine();
        //}
    }

    //使用一個報表當做範例

    //<summary>
    //最原始的父類，所以這代表未來會持續加工判斷的方法是Show、DownLoad
    //</summary>
    public interface Component
    {
        void Show();
        void DownLoad();
    }

    // <summary>
    // 被裝飾者 　跟裝飾者套件"最大的差別在於沒有建構子"（意味者不會接在別人之後）　　這邊代表報表本身
    // </summary>
    public class SimpleReport : Component
    {
        public void Show()
        {
            Console.WriteLine("展示報表");
        }
        public void DownLoad()
        {
            Console.WriteLine("下載報表");
        }
    }

    // <summary>
    // 裝飾者 　先繼承一個成有建構子的父類,後面再做擴充 設置Show和DownLoad可以被複寫
    // </summary>
    public class ReportDecorator : Component
    {
        private Component component;

        public ReportDecorator(Component component)
        {
            this.component = component;
        }

        public virtual void Show()
        {
            component.Show();
        }
        public virtual void DownLoad()
        {
            component.DownLoad();
        }
    }

    // <summary>
    // 各種功能的套件
    // </summary>
    public class Authority : ReportDecorator
    {
        //權限判定套件
        private string name { get; set; }

        public Authority(Component component,string name):base(component)
        {
            this.name = name;
        }

        public override void Show()
        {
            if (CheckAut())
            {
                Console.WriteLine("權限檢查正常");
                base.Show();
            }
            else
                Console.WriteLine("無相關權限");
        }
        public override void DownLoad()
        {
            if (CheckAut())
            {
                Console.WriteLine("權限檢查正常");
                base.DownLoad();
            }
            else
                Console.WriteLine("無相關權限");
        }

        public bool CheckAut()
        {
            if (this.name == "Steven")
                return true;
            else
                return false;
        }
    }


    public class SystemDate : ReportDecorator
    {
        public SystemDate(Component component):base(component)//C#規則,父類有寫建構需要手動選則
        {

        }

        //時間判定套件
        public override void Show()
        {
            if (CheckSysDate())
            {
                Console.WriteLine("系統日期檢查正常");
                base.Show();
            }
            else
                Console.WriteLine("系統日期小於5");     
        }
        public override void DownLoad()
        {
            if (CheckSysDate())
            {
                Console.WriteLine("系統日期檢查正常");
                base.DownLoad();
            }
            else
                Console.WriteLine("系統日期小於5");          
        }

        public bool CheckSysDate()
        {
            if (DateTime.Today.Day >= 5)
                return true;
            else
                return false;
        }
    }
}
