namespace Kontenery;

public class OverfillException : Exception
{
    private string nazwa;

    public OverfillException(string? message) : base(message)
    {
    }
    
}