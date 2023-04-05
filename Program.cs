public class Person
{
  // address
  public string StreetAddress, Postcode, City;

  // employment
  public string CompanyName, Position;
  public int AnnualIncome;

  public override string ToString()
  {
    return $"{StreetAddress}";
  }
}

public class PersonBuilder // facade
{
  // reference!
  protected Person person = new Person();

  public PersonJobBuilder Works => new PersonJobBuilder(person);
  public PersonAddressBuilder Lives => new PersonAddressBuilder(person);


  public static implicit operator Person(PersonBuilder pb)
  {
    return pb.person;
  }
}

public class PersonJobBuilder : PersonBuilder
{

  public PersonJobBuilder(Person person)
  {
    this.person = person;
  }

  public PersonJobBuilder At(string companyName)
  {
    person.CompanyName = companyName;
    return this;
  }

  public PersonJobBuilder AsA(string position)
  {
    person.Position = position;
    return this;
  }

  public PersonJobBuilder Earning(int amount)
  {
    person.AnnualIncome = amount;
    return this;
  }
}

public class PersonAddressBuilder : PersonBuilder
{
  public PersonAddressBuilder(Person person)
  {
    this.person = person;
  }

  public PersonAddressBuilder At(string streetAddress)
  {
    person.StreetAddress = streetAddress;
    return this;
  }

  public PersonAddressBuilder WithPostcode(string postcode)
  {
    person.Postcode = postcode;
    return this;
  }

  public PersonAddressBuilder In(string city)
  {
    person.City = city;
    return this;
  }
}

class Program
{
  static void Main()
  {
    Person person = new PersonBuilder()
      .Lives.At("Tucuman")
            .In("Argentina")
            .WithPostcode("4103")
      .Works.At("Noanet")
            .AsA("Developer")
            .Earning(30000);

    Console.WriteLine(person);
  }
}