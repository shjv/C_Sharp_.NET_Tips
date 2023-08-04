/*
 Boxing and Unboxing are computationally expensive.
    these are necessary for providing an unified type system, that we can treat any variable 
    in c# as an object. for example ArrayList (it was commonly used before generics were introduced.)
 
 Boxing is the process of wrapping a value type into an instance of a type System.Object.
 
 Unboxing is the opposite - the process of converting the boxed value back to a value type.
    it requires the exact type match.
 */

namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //no boxing here, because string is not a value type
            string word = "abc";
            object obj = word;

            //boxing and unboxing
            int number = 5;
            object boxedNumber = number;
            int unboxedNumber = (int)boxedNumber;

            //this will throw exception because unboxing requires exact type match
            short shortNumber = 3;
            object boxedShortNumber = shortNumber;
            //int unboxedShortNumber = (int)boxedShortNumber; 

            //this will work fine - no boxing or unboxing here,
            //so short is converted to int without problem
            short otherShortNumber = 3;
            int otherShortNumberCastToInt = (int)otherShortNumber;

            Console.ReadKey();
        }
    }
}
