using System;

//Proxy Pattern [代理模式]
namespace Design_Pattern_Exsample.ProxyPattern
{
    /*
        http://design-patterns.readthedocs.io/zh_CN/latest/structural_patterns/proxy.html
        http://www.runoob.com/design-pattern/proxy-pattern.html
    */

    class Proxy
    {
        static void Main(string[] args)
        {
            Image image = new ProxyImage("test.jpg");
            image.display();
            Console.WriteLine();
            image.display();

            Console.ReadLine();
        }
    }
    public interface Image
    {
        void display();
    }

    public class RealImage : Image
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }


        public void display()
        {
            Console.WriteLine("Displaying " + fileName);

        }

        private void loadFromDisk(string fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }


    public class ProxyImage : Image
    {

        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }


        public void display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.display();
        }
    }
}


