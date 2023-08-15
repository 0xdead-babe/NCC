using DemoClassLibrary;


namespace BuildingBlocks
{



    class BasicDataTypes
    {
        //integer data types
        private int a = 5;
        private int b = 5;
        private short c = 75;

        //integer types 

        //int -> 32 bits
        // short -> 16 bits
        // long -> 64 bits
        // byte

        //double
        private double salary = 251500.547;
        //float -> don't forget to add the F in suffix
        private float rent = 47890.78F;

        //boolean data type
        private bool isGod = false;

        //string data type
        private string message = "This is going to be crazy man";


        const double PI = 22.7;

        public void DriverFunc()
        {
            Console.WriteLine("Integer a: " + a);
            Console.WriteLine("Integer b: " + a);

            //using string literals

            Console.WriteLine($"salary: {salary}\n rent: {rent}\n isGod: {isGod}\n message: {message}\n PI: {PI}");

        }


    }


    class BasicControlFlow
    {
        private int _number = 127;
        private int? _isNullable  = null; // nullable type data
        private string[] _names = { "Genuine", "Panthi", "is", "don" };


        //if else condition

        public void ControlFlow()
        {
            if (_number % 2 == 0)
            {
                Console.WriteLine("Number is even man");
            }
            else
            {
                Console.WriteLine("Number is odd man");
            }



            //basic looping

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Looping value hehe {i}");
            }


            //for each loop
            //only works with iterables
            foreach(string name in _names)
            {
                Console.WriteLine(name);
                goto RANDOM_LABEL;

                //jump statement goto, break and continue
            }

        RANDOM_LABEL: Console.WriteLine("New LABEL MAN");

        }
    }   



   class BasicFunc
    {
        public void SomeFuncWithRef(ref string name)
        {
            name = "This is crazy ref man";
        }
    }



    class ArrayDemos
    {


        public void ArrayDemo()
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //string _name = "This is for test";
            //BasicDataTypes basic = new BasicDataTypes();
            //BasicControlFlow basicControlFlow = new BasicControlFlow();
            //BasicFunc basicFunc = new BasicFunc();
            //Class1 test = new Class1();
            //test.Test();
            //StringDemo testDemo = new StringDemo();
            //testDemo.DriverFunction();




            //basic.DriverFunc();
            //basicControlFlow.ControlFlow();
            //basicFunc.SomeFuncWithRef(ref _name);



            //Console.WriteLine(_name);



            LinQDemo demo = new LinQDemo();

            demo.TestLinQ();
        }
    }
}