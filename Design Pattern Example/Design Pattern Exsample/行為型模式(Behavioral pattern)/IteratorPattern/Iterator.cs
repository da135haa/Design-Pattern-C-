using System;

//Iterator Pattern [迭代器模式]
namespace Design_Pattern_Exsample.IteratorPattern
{
    /*
        針對"集合對象"而生的一種模式
        用處:可以檢查整個集合對象,而又不暴露對象內部的表示
     
        簡單來說就是:一個集合的類中可能會有很多的方法功能,如:add、remove...等等,但由於檢查整個集合這相關功能較複雜,就拉出來一個稱為Iterator的類來單獨處理這些事情  
        
        Java和.Net中已經完整的實現了所有集合的迭代,迭代器的作用就是把集合的管理和迭代算法分離,為了貫徹"單一職責原則",這就是主要作用     
    */
    class Iterator
    {
        //static void Main(string[] args)
        //{
        //    MyIntList list = new MyIntList();
        //    list.Add(2);
        //    list.Add(4);
        //    list.Add(6);
        //    list.Add(9);

        //    IteratorOrigin iterator = list.GetIterator();//取得這個集合的迭代器

        //    while (iterator.MoveNext())//運用跟該迭代器有關的功能
        //    {
        //        int i = (int)iterator.GetCurrent();
        //        Console.WriteLine(i.ToString());
        //        iterator.Next();
        //    }

        //    Console.ReadLine();          
        //}
    }

    // 一個跟檢查整個集合對象有相關的功能,迭代器的介面
    public interface IteratorOrigin
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Reset();
    }
    // 實作相關功能
    public class ConcreteIntIterator : IteratorOrigin
    {
        // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private MyIntList _list;
        private int _index;

        public ConcreteIntIterator(MyIntList list)//取得集合對象
        {
            _list = list;
            _index = 0;
        }

        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }

        }
    }

    //一個集合的介面,所有集合的實作都是從這邊發展出來的,一定會跟迭代綁定
    public interface IListCollection
    {
        IteratorOrigin GetIterator();
    }

    //這是一個自己寫的範例集合,只能存放int的集合
    //集合的實作
    public class MyIntList : IListCollection
    {
        int[] collection = new int[0];

        public void Add(int number)
        {
            int[] numberBuffer = new int[Length + 1];

            for(int i=0;i< collection.Length;i++)
                numberBuffer[i] = collection[i];

            numberBuffer[numberBuffer.Length-1] = number;
            collection = numberBuffer;
        }

        public int Length//一些集合自己的功能
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }

        public IteratorOrigin GetIterator()//迭代的相關功能外包了給迭代器類
        {
            return new ConcreteIntIterator(this);//這邊看new的物件是哪個就是使用了哪種迭代器
        }

    }










}
