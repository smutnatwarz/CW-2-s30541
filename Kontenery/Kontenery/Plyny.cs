namespace Kontenery;

public class Plyny : Kontener , IHazardNotifier
{
    public bool jaki; //
    public Plyny( double wysokosc, double wagaKontenera, double glebokosc, double maksLadunku,bool b) : base( wysokosc, wagaKontenera, glebokosc, maksLadunku,"L")
    {
        jaki = b;
    }

    public void Powiadomienie()
    { 
        Console.WriteLine($"Niebezpieczeństwo kontyner {Numer} nie spełnia warunków");
    }

    public override void zaladuj_kontenery(double ladunek)
    {
        var ilewlewam = jaki ? 0.5 : 0.9;
        if(ladunek+Waga_ladunku>Maks_ladunku*ilewlewam)  Powiadomienie();
        else Waga_ladunku += ladunek;
       
    }

    public override string ToString()
    {
        return $"{base.ToString()},Ładunek_Niebezpieczny = {jaki}";
    }
}