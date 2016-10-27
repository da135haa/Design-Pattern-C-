using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Exsample.StatePattern
{
        /*
        main中
            Player player = new Player();
            player.level = 11;
            player.stateWork();
            Console.Read();
        */

    //參考http://xyz.cinc.biz/2013/07/state-pattern.html
    /*
        1.將 if else 拆開，提取出來，改寫成一個分支一個 class。
        2.好處是將新增分支時，只需要新增一個class來實作就可以了
        3.要是if的true或false判斷很複雜,可以使用這個設計模式,妳將會有一整個方法可以來判斷是否進入下一個class
    */
    public class Player
    {
        /*
              這邊流程是建構時會給予初始直
              當設定參數,並啟動stateWork時,將會自己跑判斷
              也可以使用set來設置要跑哪一個判斷,接著在啟動stateWork               
        */
        public int level = 1;

        // 狀態處理，一般用 if else 的寫法
        //public void stateWork()
        //{
        //    if (level >= 1 && level < 20)
        //    {
        //        Console.WriteLine("等級 {0} ({1})", level, "新手");
        //    }
        //    else if (level >= 20 && level < 50)
        //    {
        //        Console.WriteLine("等級 {0} ({1})", level, "老手");
        //    }
        //    else if (level >= 50 && level < 90)
        //    {
        //        Console.WriteLine("等級 {0} ({1})", level, "高手");
        //    }
        //    else if (level >= 90)
        //    {
        //        Console.WriteLine("等級 {0} ({1})", level, "神");
        //    }
        //}

        private StateContext state;//這邊運用封裝來使得外部不能直接觸碰

        public Player()//建構
        {
            setStateContext(new StateTest1());//預設是使用1
        }
            
        public void setStateContext(StateContext state)
        {
            this.state = state;
        }
        public void stateWork()
        {
            state.stateWork(this);
        }
    }
    public interface StateContext//藉由interface來操作多形的用法
    {
        void stateWork(Player user);
    }

    public class StateTest1 : StateContext
    {
        public void stateWork(Player user)
        {
            if (user.level>100)
            {
                Console.WriteLine("等級高於100,神");
            }
           else
            {
                user.setStateContext(new StateTtest2());//當條件都不符合時,就轉向下一個class
                user.stateWork();
            }
        }
    }
    public class StateTtest2 : StateContext
    {
        public void stateWork(Player user)
        {
            if (user.level > 50)
            {
                Console.WriteLine("等級高於50,普通");
            }
            else
            {
                user.setStateContext(new StateTtest3());
                user.stateWork();
            }
        }
    }

    public class StateTtest3 : StateContext
    {
        public void stateWork(Player user)
        {
            if (user.level > 10)
            {
                Console.WriteLine("等級高於10,新手");
            }

        }
    }
    public class StateTtest4 : StateContext
    {
        public void stateWork(Player user)
        {
            if (user.level <= 10)
            {
                Console.WriteLine("等級低於10,新手不如");
            }

        }
    }
}
