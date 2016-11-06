using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//http://www.cnblogs.com/zhili/p/DecoratorPattern.html
//https://dotblogs.com.tw/ricochen/2012/08/02/73783
//http://xyz.cinc.biz/2013/05/decorator-pattern.html


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

        此模式會使用到的類型物件有:主要物件、裝飾物品的功能物件

    */

    class Decorator
    {
        static void Main(string[] args)
        {
            IReportControl myreport = new SimpleReportControl();
            ReportDecorator checkauth = new Authority(myreport) { Name = "rico" };
            ReportDecorator checksysdate = new SystemDate(checkauth);
            checkauth.Show();
            checksysdate.Show();
            checkauth.DownLoad();



            MemoryStream memoryStream = new MemoryStream(new byte[] { 95, 96, 97, 98, 99 });

            // 扩展缓冲的功能
            BufferedStream buffStream = new BufferedStream(memoryStream);

            // 添加加密的功能
            CryptoStream cryptoStream = new CryptoStream(memoryStream, new AesManaged().CreateEncryptor(), CryptoStreamMode.Write);
            // 添加压缩功能
            GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);


            Console.ReadLine();
        }
    }


    /// <summary>
    /// 報表介面
    /// </summary>
    public interface IReportControl
    {
        void Show();

        void DownLoad();
    }


    /// <summary>
    /// 被裝飾者 
    /// </summary>
    public class SimpleReportControl : IReportControl
    {
        public void Show()
        {
            Console.WriteLine("顯示報表");
        }

        public void DownLoad()
        {
            Console.WriteLine("下載報表");
        }

    }




    /// <summary>
    /// 裝飾者
    /// </summary>
    public abstract class ReportDecorator : IReportControl
    {
        private IReportControl _IReportControl;

        public ReportDecorator(IReportControl ireportControl)
        {
            this._IReportControl = ireportControl;
        }

        #region 虛擬方法

        public virtual void Show()
        {
            this._IReportControl.Show();
        }

        public virtual void DownLoad()
        {
            this._IReportControl.DownLoad();
        }

        #endregion
    }




    /// <summary>
    /// 擴充權限檢查(負責幫裝飾者新增方法)
    /// </summary>
    public class Authority : ReportDecorator
    {
        public string Name { get; set; }
        public Authority(IReportControl ireportControl)
            : base(ireportControl)
        {
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

        #region 權限檢查
        public bool CheckAut()
        {
            if (this.Name == "rico")
                return true;
            else
                return false;
        }
        #endregion       
    }




    /// <summary>
    /// 擴充系統日期檢查(負責幫裝飾者新增方法)
    /// </summary>
    public class SystemDate : ReportDecorator
    {
        public SystemDate(IReportControl ireportControl)
            : base(ireportControl)
        {
        }

        public override void Show()
        {
            if (CheckSysDate())
            {
                Console.WriteLine("系統日期檢查正常");
                base.Show();
            }
            else
                Console.WriteLine("系統日期小於30");
        }

        public override void DownLoad()
        {
            base.DownLoad();
        }

        #region 系統日期檢查

        public bool CheckSysDate()
        {
            if (DateTime.Today.Day >= 30)
                return true;
            else
                return false;
        }

        #endregion      
    }

}
