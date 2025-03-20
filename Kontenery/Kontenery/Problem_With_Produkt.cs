namespace Kontenery;

public class Problem_With_Produkt : Exception
{
    public Problem_With_Produkt(string? message) : base(message)
    {
    }
}