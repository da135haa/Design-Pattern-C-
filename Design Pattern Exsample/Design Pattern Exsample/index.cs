/*
物件導向程式設計的基本原則(1~5又稱 SOLID)

1.單一職責原則 (SRP：Single Responsibility Principle)
在物件導向的觀念裡，一個良好的程式設計應該俱備「低耦合、高内聚」的關係，而這個原則可以幫助我們完成這些。
當一個物件他俱備了過多的功能(職責)的時候，意味著他有可能因為各種需求變動進而影響到整個類別的變動，在物件導向觀念裡這個應該是被避免的。
http://programmerrueinotes.blogspot.tw/2014/09/srpsingle-responsibility-principle.html

2.開放、封閉原則 (OCP：Open Closed Principle)
對於擴展是開放的 (open for extension)
對於修改是封閉的 (closed for modification)
簡單說就是當有一個新功能要加入時,盡量不要修改原始的功能,而是使用套件的方式來加入
http://programmerrueinotes.blogspot.tw/2015/10/ocpopen-closed-principle.html

3.里氏(Liskov)代換原則 (LSP：Liskov Substitution Principle)
里氏代換原則是對實現 抽象化的具體步驟的規範。
里氏代換原則是對「開放、封閉原則」的補充,一般而言，違反里氏代換原則的，也違背「開放、封閉原則」，反過來不一定成立。
子類應該可以替換任何基類能夠出現的地方，並且經過替換以後，代碼還能正常工作。
簡單來說就是父類有的東西子類一定要都有(子類功能 > 父類功能)

4.介面隔離原則 (ISP：Interface Segregation Principle)
介面隔離原則之中心思想:使用一個小的專門介面,而不是使用大的總體介面。
介面應該要是內聚的避免出現胖介面,客戶端應該只依賴於它所需之介面,介面中方法應該盡量少。
一個類別對於另一個類別之依賴應該建立在最小之介面上。
簡單來說就是繼承的類可以用多重繼承的方式同時繼承多種介面來達到實做需求,而不是將內容全部寫在同一個介面來繼承
http://melomelo1988.pixnet.net/blog/post/293831938-interface-segregation-principle(isp)-%E4%BB%8B%E9%9D%A2%E9%9A%94%E9%9B%A2%E5%8E%9F%E5%89%87

5.依賴倒轉原則 (DIP：Dependency Inversion Principle)
高層模組不應該依賴低層模組，兩個都應該依賴抽像。
針對接口編寫程式，不要對具體實現的東西編寫程式。
有點像[介面隔離原則]的延伸,將抽象類中的方法(功能)一個個依照[介面隔離原則]拆成一個個介面來套用
對於龐大而且複雜的設計才可能會需要用到,缺點是會有類爆炸的問題
依賴倒轉原則雖然強大，但是也很難實現。另外，依賴倒轉原則是假定所有的具體類都會變化,要是具體類都確定不變化還這樣做會有畫蛇添足的感覺

6.迪米特法則 (LoD：Law of Demeter) or 最少知識原則 (Principle of Least Knowledge)
重點原則: 細節知道的越少越好。
[例如]
會員系統來比喻好了，登入流程是
1.檢查帳號密碼，2.檢查是否認證，3.檢查登入IP，4.最後判斷是否為VIP
是必須要按照先後順序檢查
A.我們可以提供四個方法然後跟要用的人說請依序呼叫不能顛倒喔
B.我們應該提供一個登入方法就好，然後把登入事情都封裝在這流程裡
是不是B比較好用呢，因為B遵守了最少知識原則 
這樣別人在使用也方便對吧
就算以後登入要多加功能，就知道在加入登入的方法裡面
https://dotblogs.com.tw/initials/2016/07/03/141433

7.合成/聚合重覆使用原則 (CARP)(Composite/Aggregate Reuse Principle)
簡單來說就是要盡量使用合成和聚合，盡量不要使用繼承。
這個原則是給不允許多重繼承的程式語言使用的，因為物件只允許單一繼承，所以最多只擁有一個父物件的功能，但這不利於軟體的重覆使用性，所以就有合成和聚合兩種作法
合成是一個 is-a 關係，多個物件被合成後，就是一個全新的物件，物件間的關係會很緊密
聚合則是一個 has-a 關係，表示物件擁有某些物件的功能，但有可能是各自獨立運作，只是包裝在一個相同的物件
http://blog.csdn.net/zlts000/article/details/26749723

8.高內聚，低耦合 (high cohesion、low coupling)
物件的程式碼應該要有很高的比率只和物件內其他有關的程式碼有關聯，而對外部的程式碼，物件或元件等的關聯度要愈低愈好 (最佳的狀態是零耦合)。
最終目標是不要寫出那種 "牽一髮動全身" 的物件，要將各元件的職責明確切開，將耦合性降到最低，用戶端只需要透過介面去存取它即可。
 


設計模式導覽
------------------------------------------------------------------------------------------------------------------------------------------
創建型模式 (Creational Pattern)
創建型模式旨在將系統與它的物件建立、結合、表示的方式分離。這些設計模式在物件建立的類型、主體、方式、時間等方面提高了系統的靈活性。

    1.簡單工廠模式 (Simple Factory pattern)
    2.工廠方法模式 (Factory Method Pattern)   
    3.抽象工廠模式 (Abstract Factory Pattern)
    4.建造者模式(生成器模式) (Builder Pattern)    
    5.原型模式 (Prototype Pattern)  
    6.單例模式 (Singleton Pattern)
   
結構型模式 (Structural Pattern)
描述如何將類或者對象結合在一起形成更大的結構，就像搭積木，可以通過 簡單積木的組合形成複雜的、功能更為強大的結構。

    1.適配器模式 (Adapter Pattern) 
    2.橋接模式 (Bridge Pattern)
    3.組合模式 (Composite Pattern)   
    4.裝飾模式 (Decorator Pattern)   
    5.外觀模式 (Facade Pattern)  
    6.享元模式 (Flyweight Pattern)   
    7.代理模式 (Proxy Pattern)   

行為型模式 (Behavioral pattern)
對在不同的對象之間劃分責任和算法的抽象化,行為型模式不僅僅關注類和對象的結構，而且重點關注它們之間的相互作用。

    1.責任鏈模式 (Chain-of-responsibility Pattern)
    2.命令模式 (Command Pattern)   
    3.解釋器模式 (Interpreter Pattern)  
    4.迭代器模式 (Iterator Pattern)
    5.中介者模式 (Mediator Pattern) 
    6.備忘錄模式 (Memento Pattern)
    7.觀察者模式 (Observer Pattern)    
    8.狀態模式 (State Pattern)
    9.策略模式 (Strategy Pattern)  
    10.模板方法模式 (Template Method Pattern)  
    11.訪問者模式 (Visitor Pattern) 
*/
