namespace BuildingBlocks
{
    internal class StringDemo
    {

        //string is an alias for String class. and works without using Sytem namespace
        //microsoft recommendation is to use string
        string name = "Genuine Panthi";


        public void DriverFunction()
        {
            //some properties of string
            Console.WriteLine($"length of string:  {name.Length}");
            Console.WriteLine(name);


            //when using static method use String class

            Console.WriteLine($"Static method {String.Concat(name, "Hehe man")}");


            //some methods provided by the string class

            Console.WriteLine($"Lower Case: {name.ToLower()}");
            Console.WriteLine($"Upper Case: {name.ToUpper()}");
            Console.WriteLine($"Contains: {name.Contains("enu")}");
            Console.WriteLine($"Lower Case");
            Console.WriteLine($"Trim all trailing white spaces {name.Trim()}");
            string[] strings = name.Split(" ");
            
            foreach(string s in strings) Console.WriteLine($"Char -> {s}");
            char[] characters = name.ToCharArray();
            foreach (char s in characters) Console.WriteLine($"Char -> {s}");


            //Compare method

            //if result is less than 0 strA is less than strB, if greater than 0 then strb is greater than str A
            //if 0 then both of them are equal

        }
    }
}
