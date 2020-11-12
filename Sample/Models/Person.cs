using System;
using System.ComponentModel.DataAnnotations;
using BuilderCommon;

namespace Sample.Models
{
    [GenerateBuilder]
    public partial class Person
    {
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
    }
}

