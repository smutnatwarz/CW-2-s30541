namespace Kontenery;

public abstract class Kontener
{
    public double Waga_ladunku { get; set; } //kg załadowany ładunek
    public double Wysokosc { get; set; }//cm
    public double Waga_kontenera { get; set; }// sam kontyner kg
    public double Glebokosc { get; set; } //cm
    public string Numer { get; set; }
    public static int Licz = 0;
    public double Maks_ladunku { get; set; }//kg ile 

    protected Kontener( double wysokosc, double wagaKontenera, double glebokosc, double maksLadunku,string etykieta)
    {
        
        Wysokosc = wysokosc;
        Waga_kontenera = wagaKontenera;
       Glebokosc = glebokosc;
        Maks_ladunku = maksLadunku;
        Licz++;
        Waga_ladunku= 0;
        Numer = $"KON-{etykieta}-{Licz}";


    }

    public virtual void oproznij_ladunek()
    {
        Waga_ladunku = 0;
    }

    public virtual void zaladuj_kontenery(double ladunek)
    {
        if ( ladunek > (Maks_ladunku-Waga_ladunku)) throw new  OverfillException($"Błąd waga przekracza {Maks_ladunku} ");
        Waga_ladunku+= ladunek;
    }

    public override string ToString()
    {
        return $"Numer = {Numer},Waga_Ładunku = {Waga_ladunku},Wysokość = {Wysokosc},Waga_Kontynera = {Waga_kontenera},Głębokość = {Glebokosc},Maks_Ładunku = {Maks_ladunku}";
    }
}