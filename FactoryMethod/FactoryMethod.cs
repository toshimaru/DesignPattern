using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication
{
    /// <summary>
    /// via: http://d.hatena.ne.jp/okazuki/20110103/1294028317
    /// </summary>
    class MainApp
    {
        static void Main(string[] args)
        {
            var creator1 = Create("A");
            var creator2 = Create("B");

            var product1 = creator1();
            var product2 = creator2();

            product1.Operation();
            product2.Operation();

            Console.Read();
        }

        private static Func<Product> Create(string name)
        {
            if (name == "A")
            {
                return () => new ConcreteProductA();
            }

            if (name == "B")
            {
                return () => new ConcreteProductB();
            }

            throw new ArgumentException();
        }
    }

    abstract class Product
    {
        public abstract void Operation();
    }

    class ConcreteProductA : Product
    {
        public override void Operation()
        {
            Console.WriteLine(this.GetType());
        }
    }

    class ConcreteProductB : Product
    {
        public override void Operation()
        {
            Console.WriteLine(this.GetType());
        }
    }

    /*
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }

    }
    */

}

