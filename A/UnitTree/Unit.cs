namespace A.UnitTree
{
    public class Unit
    {
        string Name { get; }
        int Id { get; }
        string Status { get; set; }
        Unit Main { get; }
        Unit(string name, int id, Unit main, string status)
        {
            Name = name;
            Id = id;
            Main = main;
            Status = status;
        }

    }
}
