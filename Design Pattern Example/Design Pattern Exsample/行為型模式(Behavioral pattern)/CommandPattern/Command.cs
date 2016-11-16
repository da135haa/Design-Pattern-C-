

//Command Pattern [命令模式]
using System;
using System.Collections.Generic;

namespace Design_Pattern_Example.CommandPattern
{
    /*
        好處:低耦合度,將請求給封裝起來,使用的時候會簡單方便
        壞處:類別會越來越多

        一共會有三個部分,集合命令並啟動的物件(Invoker)、各種命令的物件(Command)、要執行這些命令的物件(Receiver)
        Invoker:
        有一個List來儲存物件,接著在執行時會執行物件的方法
        Command:
        會有一個origin class來當作命令物件的class,再繼承出多個不同的class來當分支,會有一個共同的方法來讓Invoker執行,而方法的實作會因為傳入的Receiver而有所不同
        Receiver:
        裡面會有各種方法給Command來使用

        簡單來說分成兩階段理解
        1.一個搜集器(Invoker)蒐集了很多個共同父類別的物件,Run時依序執行牠們的共同的方法
        2.每個命令(Command)都可以放入物件(Receiver),再從放入的物件中來選擇要用哪個內容

        ps:這邊也提醒了我們,要是使用insterface是不行使用struct的
    */

    class Command
    {
        //static void Main(string[] args)
        //{
        //    CommandInvoker commandInvoker = new CommandInvoker();//建立集合
        //    CommandRecever commandRecever = new CommandRecever();

        //    commandInvoker.AddCommand(new Command_A(commandRecever));
        //    commandInvoker.AddCommand(new Command_A(commandRecever));
        //    commandInvoker.AddCommand(new Command_A(commandRecever));
        //    commandInvoker.AddCommand(new Command_B(commandRecever));
        //    commandInvoker.AddCommand(new Command_C(commandRecever));

        //    commandInvoker.RunCommand();
        //    Console.ReadLine();
        //}
    }

    class CommandInvoker
    {
        List<CommandOrigin> commandList = new List<CommandOrigin>();

        public void AddCommand(CommandOrigin command)
        {
            commandList.Add(command);
        }

        public void RunCommand()
        {
            foreach(var data in commandList)
            {
                data.Excuter();
            }
        }
    }

     abstract class CommandOrigin
    {
        protected CommandRecever commandRecever;

        public CommandOrigin(CommandRecever commandRecever) {
            this.commandRecever = commandRecever;
        }
        public abstract void Excuter();
    }

    class Command_A : CommandOrigin
    {
        public Command_A(CommandRecever commandRecever)
            :base(commandRecever)
        {
            
        }

        public override void Excuter()
        {
            commandRecever.A();
        }


    
    }
    class Command_B : CommandOrigin
    {
        public Command_B(CommandRecever commandRecever)
            :base(commandRecever)
        {

        }

        public override void Excuter()
        {
            commandRecever.B();
        }
    }
    class Command_C : CommandOrigin
    {
        public Command_C(CommandRecever commandRecever)
            :base(commandRecever)
        {

        }

        public override void Excuter()
        {
            commandRecever.C();
        }
    }

    class CommandRecever
    {
        public void A()
        {
            Console.WriteLine("跑跑");
        }
        public void B()
        {
            Console.WriteLine("飛");
        }
        public void C()
        {
            Console.WriteLine("游泳");
        }
    }





}
