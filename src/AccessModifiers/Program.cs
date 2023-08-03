
/*
 An assembly is the  compiled output of your code, in most cases a *.dll.
 A single project in Visual Studio defines a single assembly.
 */

namespace AccessModifiers
{
    public class AllModifiersTestClass
    {
        public string PublicField = "I'm a Public Field! Accessible in any Class in any Assembly!";
        internal string InternalField = "I'm an Internal Field! Accessible in any Class in this Assembly";
        protected string ProtectedField = "I'm a Protected Field! Accessible in Classes derived from this Class";
        protected internal string ProtectedInternalField = "I'm a Protected Internal Field! Accessible from any Class in this Assembly, or from derived Classes in other Assemblies";
        private protected string PrivateProtectedField = "I'm a Private Protected Field! In this Assembly can only be accessed from Classes derived from this Class. Not accessible in another assemblies at all";
        private string PrivateField = "I'm a Private Field! Not accessible in any other Class";
    }

    public class ChildOfAllModifiersTestClassInTheSameAssembly : AllModifiersTestClass
    {
        public ChildOfAllModifiersTestClassInTheSameAssembly()
        {
            Console.WriteLine(base.PublicField);
            Console.WriteLine(base.InternalField);
            Console.WriteLine(base.ProtectedField);
            Console.WriteLine(base.ProtectedInternalField);
            Console.WriteLine(base.PrivateProtectedField);
            //Console.WriteLine(base.PrivateField); //only accessible in the TestClass
        }
    }

    /*
     The default access modifiers are the ones that are  the most restrictive access modifiers that 
     are valid in the given context.
     In C# there are two levels at which we can declare types or members:
        1. The namespace level
            Here we can declare classes, structs, records, enums, delegates and interfaces.
        2. The class level
            Here at the Class/Struct/Record level we can declare fields, properties, methods and events. 
            As well as nested classes, structs, records, enums, delegates, and interfaces.
     */


    // Declared at the namespace level, "internal" is the default access modifier here
    class Program
    {
        // Declared at the class level, "private" is the default access modifier here
        static void Main(string[] args)
        {
            var allModifiersTestClassInstance = new AllModifiersTestClass();

            Console.WriteLine(allModifiersTestClassInstance.PublicField);
            Console.WriteLine(allModifiersTestClassInstance.InternalField);
            //Console.WriteLine(allModifiersTestClassInstance.ProtectedField); // not accessible 
            Console.WriteLine(allModifiersTestClassInstance.ProtectedInternalField);
            //Console.WriteLine(allModifiersTestClassInstance.PrivateProtectedField); // not accessible
            //Console.WriteLine(allModifiersTestClassInstance.PrivateField); // not accessible

            var childClassInstance = new ChildOfAllModifiersTestClassInTheSameAssembly();

            Console.ReadKey();
        }

        // "private" is the default access modifier here
        class InnerClass { }
    }
}