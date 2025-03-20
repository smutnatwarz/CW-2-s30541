namespace Kontenery;

public class Gaz :Kontener ,IHazardNotifier
{
    double Cisnienie { get; set; }

    public Gaz( double wysokosc, double wagaKontenera, double glebokosc, double maksLadunku, double cisnienie) : base( wysokosc, wagaKontenera, glebokosc, maksLadunku, "G")
    {
        Cisnienie = cisnienie;
    }
    
    public void Powiadomienie()
    { 
        Console.WriteLine($"Niebezpieczeństwo kontyner {Numer}");
    }

    public override void oproznij_ladunek()
    {
      Waga_ladunku = Waga_ladunku * 0.05;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Ciśnienie = {Cisnienie}";
    }
}