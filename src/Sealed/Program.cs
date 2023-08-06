using System;

/*
The sealed modifier prevents a class from being inherited, or an overriden method from furthur overriding.
it can not being added to an abstract class because abstract classes by definition, exist only to be inherited from.

 
it's not possible to override a sealed method.
Use cases:
1.it can be applied when a developer expects that overriding some functionality might break it.
2.it can be applied when overriding a class would not be reasonable.
3.it can be applied to a class implementing security features, to prevent "hacking" them by overriding.
4.it can be applied to improve performance, tells the CLR that it doesn't need to look for an overriden method furthur down in the hierarchy.

Disadvantages:
1.other developers may want to provide their own implementation of a class, and the sealed modifier will prevent them from doing so.
2.the sealed modifier prevents a class from being mocked, which makes it harder to create unit tests.

 */

namespace SealedModifier
{
    public class Base
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("Base class");
        }
    }

    public class Derived : Base
    {
        public override sealed void DoSomething() //we are sealing this method
        {
            Console.WriteLine("Derived class");
        }
    }

    public class DerivedFromDerived : Derived
    {
        //does not compile - this method was sealed in Derived class
        //public override void DoSomething() 
        //{
        //}
    }

    public sealed class SealedBase
    {

    }

    //does not compile - can't derive from sealed class
    //public class DerivedFromSealed : SealedBase
    //{
    //}


    class Program
    {
        static void Main(string[] args)
        {
            (new Derived()).DoSomething();

            Console.ReadKey();
        }
    }
}
