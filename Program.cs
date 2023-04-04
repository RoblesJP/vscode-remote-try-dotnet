public class Person
{
  public string Name, Position;
}

public sealed class PersonBuilder
{
  private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

  public PersonBuilder Called(string name)
  {
    return Do(p => p.Name = name);
  }

  public PersonBuilder Do(Action<Person> action)
  {
    return AddAction(action);
  }

  private PersonBuilder AddAction(Action<Person> action)
  {
    actions.Add(p =>
    {
      action(p);
      return p;
    });

    return this;
  }

  public Person Build()
  {
    return actions.Aggregate(new Person(), (p, f) => f(p));
  }
}

public static class PersonBuilderExtensions
{
  public static PersonBuilder WorksAs(this PersonBuilder builder, string position)
  {
    return builder.Do(p => p.Position = position);
  }
}

class Program
{
  static void Main()
  {
    Person person = new PersonBuilder()
      .Called("Tav")
      .WorksAs("Dev")
      .Build();

    Console.WriteLine(person);
  }
}