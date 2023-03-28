// See https://aka.ms/new-console-template for more information

using blockchain;

var app = new PopulationCensusApp();
app.RegisterPerson(new Person("max", "awe"));
app.RegisterPerson(new Person("asd", "lolol"));
app.RegisterPerson(new Person("asd", "lolol"));
app.PrintAll();

class PopulationCensusApp
{
    private readonly TypedBlockchain<Person> _blockchain;
    public PopulationCensusApp()
    {
        _blockchain = new TypedBlockchain<Person>(
            new Blockchain(new CRC32Hash()),
            new DuplicateRules());
    }

    public void RegisterPerson(Person person)
    {
        _blockchain.AddBlock(person);
    }

    public void PrintAll()
    {
        foreach (var person in _blockchain)
        {
            Console.WriteLine(person);
        }
    }
}