using System.Linq;
using System.Collections.Generic;

namespace BuildingBlocks
{



    internal class Person
    {
        public string ?UserName { get; set; } //nullable property
        public int age { get; set; }
        public string ?address { get; set; }

        public int Id { get; set; }


        public List<Person> LoadData()
        {
            List<Person> _persons = new List<Person>();

            _persons.Add(new Person { address = "Shankarnagar", age = 35, UserName="Genuine", Id = 1 });
            _persons.Add(new Person { address = "ManiGram", age = 15, UserName = "John Smith", Id = 2 });
            _persons.Add(new Person { address = "DriverTole", age = 21, UserName = "Jane Doe", Id = 3 });
            _persons.Add(new Person { address = "Nayamill", age = 26, UserName = "Wilson Mathew", Id = 4 });
            _persons.Add(new Person { address = "Butwal", age = 27, UserName = "The Rock", Id = 5 });

            return _persons;

        }


    }


    internal class ShoppingCart
    {

    }




    //Language integrated query -> powerful features in c# that allows you to query data in a declerative way, no matter what the data source is. LINQ provides a query
    //capabilities to work with objects, xml, sql databases etc...
    //filter, sort or pull info on the basis of given conditions    
    internal class LinQDemo
    {

        private int[] numbers = { 1, 4, 7, 8 };


     
        public void TestLinQ()
        {
            IEnumerable<int> result = from number in numbers where number > 4 select number;

            Person person = new Person();

            List<Person> persons = person.LoadData();

            //IEnumerable<Person> personResult = from selectedPerson in persons where selectedPerson.age > 25 select selectedPerson;
            IEnumerable<Person> personResult = persons.Where(_person => _person.age > 25);




            //lamda expression are way to represent a anonymous functions (without name). Often used with LINQ, event handlers etc



            foreach (Person _person in personResult)
            {
                Console.WriteLine($"Age: {_person.age}\n Name: {person.UserName}\n Address: {_person.address}");
            }
        }


    }

}

