using System;

namespace ClassVsStruct
{
    struct Point
    {
        private int? x;
        public int y;
        public int w { get; init; }
        public int z { get; set; }

        public Point(int _x, int _y, int _w, int _z)
        {
            x = _x; y= _y; w = _w; z = _z;
        }

        public override string ToString()
        {
            return string.Format("x={0}, y={1}, w={2}, z={3}", x, y, w, z);
        }

        // structs are value types and classes are reference types

        //does not compile - struct can't have
        //explicit parameterless constuctor
        //public Point()
        //{

        //}

        //does not compile - all fields must be
        //assigned in the constructor
        //public Point(int x)
        //{

        //}

        //does not compile - structs can't have destructors
        //public ~Point() 
        //{

        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point() { y = 2, w = 3, z = 4 };
            Console.WriteLine(point.ToString());
            point.y = 3;
            // has compile error, init only property
            //point.w = 4;
            point.z = 5;
            Console.WriteLine(point.ToString());

            var point2 = new Point(1, 2, 3, 4);
            Console.WriteLine(point2.ToString());

            Console.ReadKey();
        }
    }
}
