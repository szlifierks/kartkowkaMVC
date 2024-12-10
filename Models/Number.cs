using Microsoft.AspNetCore.Connections.Features;

namespace kartkowkaMVC.Models;

public class Number
{
    private static int _lastId = 0;
    public static List<Number> list = new List<Number>();
    public int Id { get; set; }
    public int Value { get; set; }
    
    public Number(int value)
    {
        Id = nextId();
        Value = value;
    }

    public static int nextId()
    {
        return _lastId++;
    }
}