using System;
using System.Collections.Generic;
using System.Text;

//Interpreter Pattern [解釋器模式]
namespace Design_Pattern_Exsample.Interpreter_Pattern
{
    /*
        只有滿足"有一套規則但頻繁變化"、"類似情況不斷出現"、"容易抽象為語法規則"的問題才適合使用此模式

        此模式就像是翻譯一樣,傳入中文會翻譯成英文那種感覺

        優點:易於改變何況展、易於實現文法
        缺點:應用場景很少、對於複雜文法難以維護、效能差

        使用場合:翻譯、爬蟲

        範例中使用
        string[]來將原本的文字各自拆開
        StringBuilder用來拼接最後組合好的文字      
        Dictionary來當比對的字典

        範例流程:
        要轉換的文字傳送給Translator來進行翻譯
        Translator將文字一個個切開來給字典比對,並重新拼成轉換好的內容後回傳

    */
    class Interpreter
    {
        static void Main(string[] args)
        {
            string english = "This is an apple.";
            string chinese = Translator.Translate(english);//翻譯機
            Console.WriteLine(chinese);
            Console.ReadLine();
        }
    }

    //將各部分解釋器組合起來進行包裝，方便用戶調用(將句子拆分再從新組合的地方)。
    public static class Translator
    {
        public static string Translate(string sentense)
        {
            StringBuilder sb = new StringBuilder();
            List<IExpression> expressions = new List<IExpression>();//用來存放一組組單字物件的

            string[] elements = sentense.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);//先移除.號

            foreach (string element in elements)
            {
                string[] words = element.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//將字依照空格切開並存入words中
                foreach (string word in words)
                {
                    expressions.Add(new WordEnglishExpression(word));
                }
                expressions.Add(new WordEnglishExpression("."));//最後再將句號加入
            }

            foreach (IExpression expression in expressions)//將全部物件轉解譯
            {
                expression.Interpret(sb);
            }
            return sb.ToString();
        }
    }

    //定義AbstractExpression接口,要是沒有使用接口而直接定義,差別在於未來較無擴充性
    public abstract class IExpression
    {
        protected string _value;

        public IExpression(string value)
        {
            _value = value;
        }

        public abstract void Interpret(StringBuilder sb);
    }

    //定義具體的Expression，這裏負責管理要對上哪一種翻譯,需要增加語言只需要重新建立一個子類即可。
    public class WordEnglishExpression : IExpression
    {
        public WordEnglishExpression(string value) : base(value)
        {

        }
        public override void Interpret(StringBuilder sb)
        {
            sb.Append(ChineseEnglishDict.GetEnglish(_value.ToLower()));//傳址呼叫,傳進去後內容已被改變
        }
    }

    public static class ChineseEnglishDict//一個翻譯字典核心的概念
    {
        private static Dictionary<string, string> _dictory = new Dictionary<string, string>();

        static ChineseEnglishDict()//建構中使用Dictionary來存放轉換語言的資料
        {
            _dictory.Add("this", "這");
            _dictory.Add("is", "是");
            _dictory.Add("an", "一個");
            _dictory.Add("apple", "蘋果");
            _dictory.Add(".", "。");
        }

        public static string GetEnglish(string key)
        {
            return _dictory[key];//傳入key來取得value
        }
    }
}
