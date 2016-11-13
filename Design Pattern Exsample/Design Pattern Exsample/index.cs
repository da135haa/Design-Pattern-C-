/*
物件導向程式設計的基本原則(1~5又稱 SOLID)
1.單一職責原則 (SRP：Single Responsibility Principle)
一個類別，應該只有一個引起它變化的原因
2.開放、封閉原則 (OCP：Open Closed Principle)
對於擴展是開放的 (open for extension)
對於修改是封閉的 (closed for modification)
3.里氏(Liskov)代換原則 (LSP：Liskov Substitution Principle)
子類別必須能替換父類別。
4.介面隔離原則 (ISP：Interface Segregation Principle)
5.依賴倒轉原則 (DIP：Dependency Inversion Principle)
抽象不應該依賴細節，細節應該依賴抽像。因為抽像相對較穩定。
高層模組不應該依賴低層模組，兩個都應該依賴抽像。
針對接口編寫程式，不要對具體實現的東西編寫程式。
6.迪米特法則 (LoD：Law of Demeter)
7.最少知識原則 Principle of Least Knowledge
只和自己眼前的朋友交談 Only talk to your immediate friends
低耦合

[例如]
郵差送來掛號信，須要蓋收件人印章。
一般人不會叫郵差自己進屋找印章，既浪費時間也不安全。
正常都是自己進屋拿，或是請其他家人幫忙拿。
因為不應該給郵差進屋找東西的權限、郵差也不須要知道印章放在屋內何處。
合成/聚合重覆使用原則 (CARP)(Composite/Aggregate Reuse Principle)
多用合成/聚合，少用繼承。
在兩個物件有 has-a (has-parts、is-part-of)關係時 => 合成/聚合 (A has a B)
當兩個物件有 is-a (is-a-kind-of)關係時 => 繼承 (Superman is a kind of Person)
合成 (Composite)：A、B兩物件有合成關係時，表示其中一個物件消失(ex:書本)，另一個物件也會消失(ex:章節)。
聚合 (Aggregate)：A、B兩物件有聚合關係時，表示其中一個物件消失(ex:球隊)，另一個物件不會消失(ex:球員)。


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
