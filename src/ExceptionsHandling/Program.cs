/*
 The three main types of errors are:
    1. Compilation Errors
        syntax errors, reported by the compiler
    2. Runtime Errors
        throw during program execution
    3. Logical Errors
        accuring when the program works without crashing but it doesn't produce the correct result

    Unit tests protect us from both Runtime and Logical errors.
 */

namespace ExceptionsHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"6/3 is {DivideNumbers(6, 3)}\n\n");
            Console.WriteLine($"6/0 is {DivideNumbers(6, 0)}\n\n");

            // why this code doesn't go to the catch block?
            //Console.WriteLine($"ElementAtIndex[0] is {ElementAtIndex(null, 0)}\n\n");
            Console.WriteLine($"ElementAtIndex[1] is {ElementAtIndex(new int[] {}, 1)}\n\n");
            Console.WriteLine($"ElementAtIndex[4] is {ElementAtIndex(new int[] {1,2}, 4)}\n\n");

            //global try-catch block
            // Try > contains code that may throw exception
            try
            {
                Application.Run();
            }
            // Catch > defines what should be done if an exception of a given type is thrown
            catch (Exception ex)
            {
                Console.WriteLine($"Exception was thrown by the application," +
                    $" error message is: {ex.Message}");
            }
            // Finally > is executed no matter if the exception was thrown or not
            finally
            {
                Console.WriteLine(
                    "Application will close. " +
                    "No exception have been caught by the global try-catch block.");
            }

            Console.ReadKey();
        }

        private static int? DivideNumbers(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Attempt to divide by zero." +
                    $" Exception message: {ex.Message}");
                return null;
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }
        }

        private static int? ElementAtIndex(int[] numbers, int index)
        {
            try
            {
                return numbers[index];
            }
            // an exception will be cought by the first catch block that handles the matching exception type
            //catch clauses in order from the most specific to the most generic
            catch (NullReferenceException)
            {
                Console.WriteLine($"Input array is null");
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index {index} does not exist in input array");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error, see message: {ex.Message}");
                return null;
            }
        }
    }

    internal class Application
    {
        internal static void Run()
        {
            //imagine some application logic here...
        }
    }
}
