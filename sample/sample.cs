namespace sample;
public static class Sample
{
	public static List<Person> People()
	{
		return new List<Person>
		{
			new Person("John", 30),
			new Person("Jane", 25),
			new Person("Bob", 40),
			new Person("Alice", 40)
		};
	}
}