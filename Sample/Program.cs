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
            Console.WriteLine("==== Builder Validation ====");
            try
            {
               var person = Person.Builder
                .FirstName("James")
                .LastName("Melvin")
                    .Build();
            }
            catch (BuilderException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

