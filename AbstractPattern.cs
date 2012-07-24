using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// via:
    /// - http://sourcemaking.com/design_patterns/abstract_factory
    /// - http://d.hatena.ne.jp/okazuki/20110103/1294028317
    /// </summary>
    class MainApp
    {
        static void Main(string[] args)
        {
            // Abstract Factory #1
            var factory1 = Create("A");
            var c1 = new Client(factory1);
            c1.run();

            // Abstract Factory #2
            var factory2 = Create("B");
            var c2 = new Client(factory2);
            c2.run();

            Console.Read();
        }

        private static AbstractFactory Create(string name)
        {
            if (name == "A")
            {
                return new AbstractFactory(() => new ProductA1(), () => new ProductB1());
            }

            if (name == "B")
            {
                return new AbstractFactory(() => new ProductA2(), () => new ProductB2());
            }

            throw new ArgumentException();
        }
    }

    // "AbstractFactory" 
    class AbstractFactory
    {
        public AbstractFactory(Func<AbstractProductA> CreateProductA, Func<AbstractProductB> CreateProductB)
        {
            this.CreateProductA = CreateProductA;
            this.CreateProductB = CreateProductB;
        }

        public Func<AbstractProductA> CreateProductA { get; private set; }
        public Func<AbstractProductB> CreateProductB { get; private set; }
    }

    // "AbstractProductA" 
    abstract class AbstractProductA
    {
    }

    // "AbstractProductB" 
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    // "ProductA1" 
    class ProductA1 : AbstractProductA
    {
    }

    // "ProductB1" 
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    // "ProductA2" 
    class ProductA2 : AbstractProductA
    {
    }

    // "ProductB2" 
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    // "Client" - the interaction environment of the products 
    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;

        public Client(AbstractFactory factory)
        {
            this.AbstractProductB = factory.CreateProductB();
            this.AbstractProductA = factory.CreateProductA();
        }

        public void run()
        {
            this.AbstractProductB.Interact(this.AbstractProductA);
        }
    }

    /*
// "ConcreteFactory1" 
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

// "ConcreteFactory2" 
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}
*/
}