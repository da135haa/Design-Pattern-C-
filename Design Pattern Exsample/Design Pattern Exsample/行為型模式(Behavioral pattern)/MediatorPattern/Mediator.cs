using System;

//Mediator Pattern [中介者模式]
namespace Design_Pattern_Exsample.MediatorPattern
{
    /*
        參考:https://wizardforcel.gitbooks.io/w3school-design-patterns/content/19.html
        用來降低多個類之間溝通的複雜度,這種模式提供了一個中間層類,"處理不同類之間的通信"
        
        簡單說就是大家都只要將訊息傳入這個中介類中就好,它會負責資訊的處理和轉發

        好處:降低了類別的複雜度、各類別之間解耦、符合最少知識原則
        壞處:中介者過於龐大時,會複雜難以維護
    */
    class Mediator
    {
        //static void Main(string[] args)
        //{
        //    User play1 = new User("Steven");
        //    User play2 = new User("Charry");

        //    play1.sendMessage("安安你好");
        //    play2.sendMessage("今天天氣晴");

        //    Console.ReadLine();
        //}
    }

    //中介類
    public class MediatorRoom
    {
        public static void showMessage(User user, string message)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay + " [" + user.name + "] : " + message);
        }
    }

    //使用者類
    public class User
    {
        public string name {private set;get; }

        public User(string name)
        {
            this.name = name;
        }

        public void sendMessage(string message)
        {
            MediatorRoom.showMessage(this, message);
        }
    }

}
