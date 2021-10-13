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



### Netizine.CodeGen Analyzer rules
|Id|Category|Description|Severity|Is enabled|Code fix|
|--|--------|-----------|:------:|:--------:|:------:|
|[NCG001](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0001.md)|Usage|StringComparison is missing|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG002](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0002.md)|Usage|IEqualityComparer\<string\> or IComparer\<string\> is missing|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG003](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0003.md)|Style|Add argument name to improve readability|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG004](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0004.md)|Usage|Use Task.ConfigureAwait(false)|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG005](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0005.md)|Performance|Use Array.Empty\<T\>()|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG006](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0006.md)|Usage|Use String.Equals instead of equality operator|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG007](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0007.md)|Style|Add a comma after the last value|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG008](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0008.md)|Performance|Add StructLayoutAttribute|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG009](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0009.md)|Security|Add regex evaluation timeout|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG010](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0010.md)|Design|Mark attributes with AttributeUsageAttribute|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG011](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0011.md)|Usage|IFormatProvider is missing|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG012](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0012.md)|Design|Do not raise reserved exception type|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG013](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0013.md)|Design|Types should not extend System.ApplicationException|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG014](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0014.md)|Design|Do not raise System.ApplicationException type|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG015](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0015.md)|Usage|Specify the parameter name in ArgumentException|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG016](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0016.md)|Design|Prefer return collection abstraction instead of implementation|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG017](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0017.md)|Design|Abstract types should not have public or internal constructors|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG018](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0018.md)|Design|Do not declare static members on generic types|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG019](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0019.md)|Usage|Use EventArgs.Empty|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG020](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0020.md)|Performance|Use direct methods instead of LINQ methods|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG021](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0021.md)|Usage|Use StringComparer.GetHashCode instead of string.GetHashCode|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG022](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0022.md)|Design|Return Task.FromResult instead of returning null|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG023](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0023.md)|Performance|Add RegexOptions.ExplicitCapture|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG024](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0024.md)|Usage|Use an explicit StringComparer when possible|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG025](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0025.md)|Design|Implement the functionality instead of throwing NotImplementedException|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG026](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0026.md)|Design|Fix TODO comment|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG027](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0027.md)|Usage|Do not remove original exception|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG028](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0028.md)|Performance|Optimize StringBuilder usage|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG029](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0029.md)|Performance|Combine LINQ methods|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG030](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0030.md)|Performance|Remove useless OrderBy call|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG031](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0031.md)|Performance|Optimize Enumerable.Count() usage|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG032](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0032.md)|Usage|Use an overload with a CancellationToken argument|<span title='Info'>ℹ️</span>|❌|❌|
|[NCG033](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0033.md)|Design|Do not tag instance fields with ThreadStaticAttribute|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG035](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0035.md)|Usage|Do not use dangerous threading methods|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG036](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0036.md)|Design|Make class static|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG037](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0037.md)|Usage|Remove empty statement|<span title='Error'>❌</span>|✔️|❌|
|[NCG038](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0038.md)|Design|Make method static|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG039](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0039.md)|Security|Do not write your own certificate validation method|<span title='Error'>❌</span>|✔️|❌|
|[NCG040](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0040.md)|Usage|Flow the cancellation token|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG041](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0041.md)|Design|Make property static|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG042](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0042.md)|Design|Do not use blocking calls in an async method|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG043](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0043.md)|Usage|Use nameof operator in ArgumentException|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG044](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0044.md)|Performance|Remove useless ToString call|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG045](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0045.md)|Design|Do not use blocking call in a sync method (need to make containing method async)|<span title='Info'>ℹ️</span>|❌|❌|
|[NCG046](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0046.md)|Design|Use EventHandler\<T\> to declare events|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG047](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0047.md)|Design|Declare types in namespaces|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG048](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0048.md)|Design|File name must match type name|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG049](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0049.md)|Design|Type name should not match containing namespace|<span title='Error'>❌</span>|✔️|❌|
|[NCG050](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0050.md)|Design|Validate arguments correctly in iterator methods|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG051](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0051.md)|Design|Method is too long|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG052](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0052.md)|Performance|Replace constant Enum.ToString with nameof|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG053](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0053.md)|Design|Make class sealed|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG054](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0054.md)|Design|Embed the caught exception as innerException|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG055](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0055.md)|Design|Do not use finalizer|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG056](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0056.md)|Design|Do not call overridable members in constructor|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG057](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0057.md)|Naming|Class name should end with 'Attribute'|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG058](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0058.md)|Naming|Class name should end with 'Exception'|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG059](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0059.md)|Naming|Class name should end with 'EventArgs'|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG060](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0060.md)|Design|The value returned by Stream.Read/Stream.ReadAsync is not used|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG061](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0061.md)|Design|Method overrides should not change parameter defaults|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG062](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0062.md)|Design|Non-flags enums should not be marked with "FlagsAttribute"|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG063](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0063.md)|Performance|Use Where before OrderBy|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG064](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0064.md)|Design|Avoid locking on publicly accessible instance|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG065](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0065.md)|Performance|Default ValueType.Equals or HashCode is used for struct's equality|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG066](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0066.md)|Performance|Hash table unfriendly type is used in a hash table|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG067](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0067.md)|Design|Use Guid.Empty|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG068](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0068.md)|Design|Invalid parameter name for nullable attribute|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG069](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0069.md)|Design|Non-constant static fields should not be visible|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG070](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0070.md)|Design|Obsolete attributes should include explanations|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG071](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0071.md)|Style|Avoid using redundant else|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG072](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0072.md)|Design|Do not throw from a finally block|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG073](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0073.md)|Style|Avoid comparison with bool constant|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG074](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0074.md)|Usage|Avoid implicit culture-sensitive methods|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG075](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0075.md)|Design|Do not use implicit culture-sensitive ToString|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG076](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0076.md)|Design|Do not use implicit culture-sensitive ToString in interpolated strings|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG077](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0077.md)|Design|A class that provides Equals(T) should implement IEquatable\<T\>|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG078](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0078.md)|Performance|Use 'Cast' instead of 'Select' to cast|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG079](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0079.md)|Usage|Flow the cancellation token using .WithCancellation()|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG080](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0080.md)|Usage|Use a cancellation token using .WithCancellation()|<span title='Info'>ℹ️</span>|❌|❌|
|[NCG081](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0081.md)|Design|Method overrides should not omit params keyword|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG082](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0082.md)|Design|NaN should not be used in comparisons|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG083](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0083.md)|Design|ConstructorArgument parameters should exist in constructors|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG084](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0084.md)|Design|Local variable should not hide other symbols|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG085](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0085.md)|Usage|Anonymous delegates should not be used to unsubscribe from Events|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG086](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0086.md)|Design|Do not throw from a finalizer|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG087](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0087.md)|Design|Parameters with [DefaultParameterValue] attributes should also be marked [Optional]|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG088](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0088.md)|Design|Use [DefaultParameterValue] instead of [DefaultValue]|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG089](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0089.md)|Performance|Optimize string method usage|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG090](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0090.md)|Design|Remove empty else/finally block|<span title='Info'>ℹ️</span>|✔️|❌|
|[NCG091](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0091.md)|Usage|Sender should be 'this' for instance events|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG092](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0092.md)|Usage|Sender should be 'null' for static events|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG093](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0093.md)|Usage|EventArgs should not be null|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG094](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0094.md)|Design|A class that provides CompareTo(T) should implement IComparable\<T\>|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG095](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0095.md)|Design|A class that implements IEquatable\<T\> should override Equals(object)|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG096](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0096.md)|Design|A class that implements IComparable\<T\> should also implement IEquatable\<T\>|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG097](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0097.md)|Design|A class that implements IComparable\<T\> or IComparable should override comparison operators|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG098](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0098.md)|Performance|Use indexer instead of LINQ methods|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG099](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0099.md)|Usage|Use Explicit enum value instead of 0|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG100](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0100.md)|Usage|Await task before disposing resources|<span title='Warning'>⚠️</span>|✔️|❌|
|[NCG101](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0101.md)|Usage|String contains an implicit end of line character|<span title='Hidden'>👻</span>|✔️|✔️|
|[NCG102](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0102.md)|Design|Make member readonly|<span title='Info'>ℹ️</span>|✔️|✔️|
|[NCG103](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0103.md)|Usage|Use SequenceEqual instead of equality operator|<span title='Warning'>⚠️</span>|✔️|✔️|
|[NCG104](https://github.com/Netizine/Netizine.CodeGen/blob/master/Netizine.CodeGen.Generator/docs/MA0104.md)|Design|Do not create a type with a name from the BCL|<span title='Warning'>⚠️</span>|❌|❌|

# .editorconfig - default values

```editorconfig
dotnet_diagnostic.NCG001.severity = suggestion # NCG001: StringComparison is missing
dotnet_diagnostic.NCG002.severity = warning    # NCG002: IEqualityComparer<string> or IComparer<string> is missing
dotnet_diagnostic.NCG003.severity = suggestion # NCG003: Add argument name to improve readability
dotnet_diagnostic.NCG004.severity = warning    # NCG004: Use Task.ConfigureAwait(false)
dotnet_diagnostic.NCG005.severity = warning    # NCG005: Use Array.Empty<T>()
dotnet_diagnostic.NCG006.severity = warning    # NCG006: Use String.Equals instead of equality operator
dotnet_diagnostic.NCG007.severity = suggestion # NCG007: Add a comma after the last value
dotnet_diagnostic.NCG008.severity = warning    # NCG008: Add StructLayoutAttribute
dotnet_diagnostic.NCG009.severity = warning    # NCG009: Add regex evaluation timeout
dotnet_diagnostic.NCG010.severity = warning    # NCG010: Mark attributes with AttributeUsageAttribute
dotnet_diagnostic.NCG011.severity = warning    # NCG011: IFormatProvider is missing
dotnet_diagnostic.NCG012.severity = warning    # NCG012: Do not raise reserved exception type
dotnet_diagnostic.NCG013.severity = warning    # NCG013: Types should not extend System.ApplicationException
dotnet_diagnostic.NCG014.severity = warning    # NCG014: Do not raise System.ApplicationException type
dotnet_diagnostic.NCG015.severity = warning    # NCG015: Specify the parameter name in ArgumentException
dotnet_diagnostic.NCG016.severity = warning    # NCG016: Prefer return collection abstraction instead of implementation
dotnet_diagnostic.NCG017.severity = warning    # NCG017: Abstract types should not have public or internal constructors
dotnet_diagnostic.NCG018.severity = warning    # NCG018: Do not declare static members on generic types
dotnet_diagnostic.NCG019.severity = warning    # NCG019: Use EventArgs.Empty
dotnet_diagnostic.NCG020.severity = suggestion # NCG020: Use direct methods instead of LINQ methods
dotnet_diagnostic.NCG021.severity = warning    # NCG021: Use StringComparer.GetHashCode instead of string.GetHashCode
dotnet_diagnostic.NCG022.severity = warning    # NCG022: Return Task.FromResult instead of returning null
dotnet_diagnostic.NCG023.severity = warning    # NCG023: Add RegexOptions.ExplicitCapture
dotnet_diagnostic.NCG024.severity = warning    # NCG024: Use an explicit StringComparer when possible
dotnet_diagnostic.NCG025.severity = warning    # NCG025: Implement the functionality instead of throwing NotImplementedException
dotnet_diagnostic.NCG026.severity = warning    # NCG026: Fix TODO comment
dotnet_diagnostic.NCG027.severity = warning    # NCG027: Do not remove original exception
dotnet_diagnostic.NCG028.severity = suggestion # NCG028: Optimize StringBuilder usage
dotnet_diagnostic.NCG029.severity = suggestion # NCG029: Combine LINQ methods
dotnet_diagnostic.NCG030.severity = warning    # NCG030: Remove useless OrderBy call
dotnet_diagnostic.NCG031.severity = suggestion # NCG031: Optimize Enumerable.Count() usage
dotnet_diagnostic.NCG032.severity = none       # NCG032: Use an overload with a CancellationToken argument
dotnet_diagnostic.NCG033.severity = warning    # NCG033: Do not tag instance fields with ThreadStaticAttribute
dotnet_diagnostic.NCG035.severity = warning    # NCG035: Do not use dangerous threading methods
dotnet_diagnostic.NCG036.severity = suggestion # NCG036: Make class static
dotnet_diagnostic.NCG037.severity = error      # NCG037: Remove empty statement
dotnet_diagnostic.NCG038.severity = suggestion # NCG038: Make method static
dotnet_diagnostic.NCG039.severity = error      # NCG039: Do not write your own certificate validation method
dotnet_diagnostic.NCG040.severity = suggestion # NCG040: Flow the cancellation token
dotnet_diagnostic.NCG041.severity = suggestion # NCG041: Make property static
dotnet_diagnostic.NCG042.severity = suggestion # NCG042: Do not use blocking calls in an async method
dotnet_diagnostic.NCG043.severity = suggestion # NCG043: Use nameof operator in ArgumentException
dotnet_diagnostic.NCG044.severity = suggestion # NCG044: Remove useless ToString call
dotnet_diagnostic.NCG045.severity = none       # NCG045: Do not use blocking call in a sync method (need to make containing method async)
dotnet_diagnostic.NCG046.severity = warning    # NCG046: Use EventHandler<T> to declare events
dotnet_diagnostic.NCG047.severity = warning    # NCG047: Declare types in namespaces
dotnet_diagnostic.NCG048.severity = warning    # NCG048: File name must match type name
dotnet_diagnostic.NCG049.severity = error      # NCG049: Type name should not match containing namespace
dotnet_diagnostic.NCG050.severity = suggestion # NCG050: Validate arguments correctly in iterator methods
dotnet_diagnostic.NCG051.severity = warning    # NCG051: Method is too long
dotnet_diagnostic.NCG052.severity = suggestion # NCG052: Replace constant Enum.ToString with nameof
dotnet_diagnostic.NCG053.severity = suggestion # NCG053: Make class sealed
dotnet_diagnostic.NCG054.severity = warning    # NCG054: Embed the caught exception as innerException
dotnet_diagnostic.NCG055.severity = warning    # NCG055: Do not use finalizer
dotnet_diagnostic.NCG056.severity = warning    # NCG056: Do not call overridable members in constructor
dotnet_diagnostic.NCG057.severity = suggestion # NCG057: Class name should end with 'Attribute'
dotnet_diagnostic.NCG058.severity = suggestion # NCG058: Class name should end with 'Exception'
dotnet_diagnostic.NCG059.severity = suggestion # NCG059: Class name should end with 'EventArgs'
dotnet_diagnostic.NCG060.severity = warning    # NCG060: The value returned by Stream.Read/Stream.ReadAsync is not used
dotnet_diagnostic.NCG061.severity = warning    # NCG061: Method overrides should not change parameter defaults
dotnet_diagnostic.NCG062.severity = warning    # NCG062: Non-flags enums should not be marked with "FlagsAttribute"
dotnet_diagnostic.NCG063.severity = suggestion # NCG063: Use Where before OrderBy
dotnet_diagnostic.NCG064.severity = warning    # NCG064: Avoid locking on publicly accessible instance
dotnet_diagnostic.NCG065.severity = warning    # NCG065: Default ValueType.Equals or HashCode is used for struct's equality
dotnet_diagnostic.NCG066.severity = warning    # NCG066: Hash table unfriendly type is used in a hash table
dotnet_diagnostic.NCG067.severity = suggestion # NCG067: Use Guid.Empty
dotnet_diagnostic.NCG068.severity = warning    # NCG068: Invalid parameter name for nullable attribute
dotnet_diagnostic.NCG069.severity = warning    # NCG069: Non-constant static fields should not be visible
dotnet_diagnostic.NCG070.severity = warning    # NCG070: Obsolete attributes should include explanations
dotnet_diagnostic.NCG071.severity = suggestion # NCG071: Avoid using redundant else
dotnet_diagnostic.NCG072.severity = warning    # NCG072: Do not throw from a finally block
dotnet_diagnostic.NCG073.severity = suggestion # NCG073: Avoid comparison with bool constant
dotnet_diagnostic.NCG074.severity = warning    # NCG074: Avoid implicit culture-sensitive methods
dotnet_diagnostic.NCG075.severity = suggestion # NCG075: Do not use implicit culture-sensitive ToString
dotnet_diagnostic.NCG076.severity = suggestion # NCG076: Do not use implicit culture-sensitive ToString in interpolated strings
dotnet_diagnostic.NCG077.severity = warning    # NCG077: A class that provides Equals(T) should implement IEquatable<T>
dotnet_diagnostic.NCG078.severity = suggestion # NCG078: Use 'Cast' instead of 'Select' to cast
dotnet_diagnostic.NCG079.severity = suggestion # NCG079: Flow the cancellation token using .WithCancellation()
dotnet_diagnostic.NCG080.severity = none       # NCG080: Use a cancellation token using .WithCancellation()
dotnet_diagnostic.NCG081.severity = warning    # NCG081: Method overrides should not omit params keyword
dotnet_diagnostic.NCG082.severity = warning    # NCG082: NaN should not be used in comparisons
dotnet_diagnostic.NCG083.severity = warning    # NCG083: ConstructorArgument parameters should exist in constructors
dotnet_diagnostic.NCG084.severity = warning    # NCG084: Local variable should not hide other symbols
dotnet_diagnostic.NCG085.severity = warning    # NCG085: Anonymous delegates should not be used to unsubscribe from Events
dotnet_diagnostic.NCG086.severity = warning    # NCG086: Do not throw from a finalizer
dotnet_diagnostic.NCG087.severity = warning    # NCG087: Parameters with [DefaultParameterValue] attributes should also be marked [Optional]
dotnet_diagnostic.NCG088.severity = warning    # NCG088: Use [DefaultParameterValue] instead of [DefaultValue]
dotnet_diagnostic.NCG089.severity = suggestion # NCG089: Optimize string method usage
dotnet_diagnostic.NCG090.severity = suggestion # NCG090: Remove empty else/finally block
dotnet_diagnostic.NCG091.severity = warning    # NCG091: Sender should be 'this' for instance events
dotnet_diagnostic.NCG092.severity = warning    # NCG092: Sender should be 'null' for static events
dotnet_diagnostic.NCG093.severity = warning    # NCG093: EventArgs should not be null
dotnet_diagnostic.NCG094.severity = warning    # NCG094: A class that provides CompareTo(T) should implement IComparable<T>
dotnet_diagnostic.NCG095.severity = warning    # NCG095: A class that implements IEquatable<T> should override Equals(object)
dotnet_diagnostic.NCG096.severity = warning    # NCG096: A class that implements IComparable<T> should also implement IEquatable<T>
dotnet_diagnostic.NCG097.severity = warning    # NCG097: A class that implements IComparable<T> or IComparable should override comparison operators
dotnet_diagnostic.NCG098.severity = suggestion # NCG098: Use indexer instead of LINQ methods
dotnet_diagnostic.NCG099.severity = warning    # NCG099: Use Explicit enum value instead of 0
dotnet_diagnostic.NCG100.severity = warning    # NCG100: Await task before disposing resources
dotnet_diagnostic.NCG101.severity = silent     # NCG101: String contains an implicit end of line character
dotnet_diagnostic.NCG102.severity = suggestion # NCG102: Make member readonly
dotnet_diagnostic.NCG103.severity = warning    # NCG103: Use SequenceEqual instead of equality operator
dotnet_diagnostic.NCG104.severity = none       # NCG104: Do not create a type with a name from the BCL
```

