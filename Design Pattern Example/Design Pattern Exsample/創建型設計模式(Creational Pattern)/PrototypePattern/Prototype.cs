using System;


//Prototype Pattern [原型模式]
namespace Design_Pattern_Exsample.PrototypePattern
{
    /*
        重點在於Clone,讓一個已經制定好屬性的物件可以直接Clone一個,而不需要重新設定屬性等細節  (屬於深拷貝)

        好處:不需要重新建構函數,對於大量重複執行時效能可以大大提升,可以隱藏創建的細節
        壞處:類別都要加讓Clone方法,在一開始規劃時就要架構好

        範例中使用C#內建的ICloneable只是方便建置Clone方法而已
        範例是使用了第二層Clone,也是可以只用上單層Clone就好的

        複習:要是你直接將 new出來的物件指定給另外一個變數,他們其實還是"共用同一個本體"  (屬於淺拷貝)
        例: 這時二次所顯示的值也會被更改成20
            Test test1 = new Test(100);
            Console.WriteLine(test1.number + "");
            Test test2 = test1;
            test2.number = 20;
            Console.WriteLine(test1.number + "");          
    */
    class Prototype
    {
        //static void Main(string[] args)
        //{
        //    Resume a = new Resume("kero小柯");
        //    a.SetPersonalInfo("男", "25");
        //    a.SetWorkExperience("2011-2012", "IT公司");

        //    Resume b = (Resume)a.Clone();
        //    b.SetWorkExperience("2012-2014", "IT創業");

        //    Resume c = (Resume)a.Clone();
        //    c.SetWorkExperience("2014-2015", "IT經理");

        //    a.Display();
        //    b.Display();
        //    c.Display();

        //    Console.ReadLine();
        //}
    }
  
    //履歷
    class Resume : ICloneable
    {
        private string name;
        private string sex;
        private string age;

        private WorkExperience work;

        public Resume(string name)
        {
            this.name = name;
            work = new WorkExperience();
        }

        private Resume(WorkExperience work)
        {
            this.work = (WorkExperience)work.Clone();
        }

        //個人資訊
        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }
        //工作經歷
        public void SetWorkExperience(string workDate, string company)
        {
            work.WorkDate = workDate;
            work.Company = company;
        }

        //顯示
        public void Display()
        {
            Console.WriteLine("{0} {1} {2}", name, sex, age);
            Console.WriteLine("工作經歷：{0} {1}", work.WorkDate, work.Company);
        }

        public Object Clone()
        {
            Resume obj = new Resume(this.work);

            obj.name = this.name;
            obj.sex = this.sex;
            obj.age = this.age;


            return obj;
        }
    }

    //第二層Clone
    class WorkExperience : ICloneable
    {
        private string workDate;
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }
        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public Object Clone()
        {
            return (Object)this.MemberwiseClone();
        }

    }
}
