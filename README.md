This project demonstrates the use of .NET 5 Source generators to automatically generate patterns for classes and analyse code for rule compliance. 

### What does it do

Turns this

```c#
[GenerateBuilder]
public partial class Person
{
    [Required]
    public string FirstName { get; private set; }
    [Required]
    public string LastName { get; private set; }
    public DateTime? BirthDate { get; private set; }
}
```

into this

```c#
partial class Person
{
  private Person(){}
  public static PersonBuilder Builder => new PersonBuilder();
  public class PersonBuilder
  {

    private string _firstName;
    public PersonBuilder FirstName(string FirstName)
    {
      _firstName = FirstName;
      return this;
    }


    private string _lastName;
    public PersonBuilder LastName(string LastName)
    {
      _lastName = LastName;
      return this;
    }


    private DateTime? _birthDate;
    public PersonBuilder BirthDate(DateTime? BirthDate)
    {
      _birthDate = BirthDate;
      return this;
    }


    public Person Build()
    {
      Validate();
      return new Person
      {
        FirstName = _firstName,
        LastName = _lastName,
        BirthDate = _birthDate,

      };
    }
    public void Validate()
    {
      void AddError(Dictionary<string, string> items, string property, string message)
      {
        if (items.TryGetValue(property, out var errors))
          items[property] = $"{errors}\n{message}";
        else
          items[property] = message;
      }
      Dictionary<string,string> errors = new Dictionary<string, string>();
      if(_firstName == default)  AddError(errors, "FirstName", "Value is required");
      if(_lastName == default)  AddError(errors, "LastName", "Value is required");

      if(errors.Count > 0)
        throw new BuilderCommon.BuilderException(errors);
    }
  }
}

```



### Requirements

- Visual Studio 2019
- .NET 5.0

