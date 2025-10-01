namespace FactoryMethon;

interface Database
{
    public string ReadRecord();
    public string WriteRecord();
}

class MongoDB : Database
{
    public MongoDB() { }
    public string ReadRecord() { return "find()"; }
    public string WriteRecord() { return "Insert Into(...)"; }
}
class MySQL : Database
{
    public MySQL() { }
    public string ReadRecord() { return "Select * from MySQL"; }
    public string WriteRecord() { return "Insert into MySQL values (...)"; }
}
class FactoryMethod
{
    public Database Createproduct(string typ)
    {
        if (typ == "MongoDB")
        {
            return new MongoDB();
        }
        else if (typ == "MySQL")
        {
            return new MySQL();
        }
        throw new ArgumentException("Invalid type");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FactoryMethod factory = new FactoryMethod();

        Database db1 = factory.Createproduct("MongoDB");
        Console.WriteLine(db1.ReadRecord());
        Console.WriteLine(db1.WriteRecord());

        Database db2 = factory.Createproduct("MySQL");
        Console.WriteLine(db2.ReadRecord());
        Console.WriteLine(db2.WriteRecord());
    }
}