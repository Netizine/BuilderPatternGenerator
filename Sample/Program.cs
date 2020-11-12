using System;
using BuilderCommon;
using Newtonsoft.Json;
using Sample.Models;

namespace Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            var myDataClass = Person.Builder
                .FirstName("Jim")
                .LastName("Walker")
                .Build();

            Console.WriteLine(JsonConvert.SerializeObject(myDataClass, Formatting.Indented));

            Console.WriteLine("==== Builder Validation ====");
            try
            {
                Person.Builder
                .FirstName("Jim")
                .LastName("Walker")
                    .Build();
            }
            catch (BuilderException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

