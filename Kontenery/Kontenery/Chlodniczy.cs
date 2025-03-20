namespace Kontenery;

public class Chlodniczy : Kontener 
{
    private string Produkt { get; set; }
    double Temperatura {get; set;}
    Dictionary<string,double> ograniczenia=new Dictionary<string, double>() ;

    public Chlodniczy( double wysokosc, double wagaKontenera, double glebokosc, double maksLadunku, string produkt, double temperatura) : base( wysokosc, wagaKontenera, glebokosc, maksLadunku, "C") 
    {
       
        ograniczenia.Add("Banany", 13.3);
        ograniczenia.Add("Czekolady", 18);
        ograniczenia.Add("Ryby", 2);
       ograniczenia.Add("Mięsa", -15);
       ograniczenia.Add("Lody", -18);
       ograniczenia.Add("Mrożone Pizze", -30);
       ograniczenia.Add("Sery", 7.2);
       ograniczenia.Add("Parówki", 5);
       ograniczenia.Add("Masła", 20.5);
       ograniczenia.Add("Jajka", 19);

       if (!ograniczenia.ContainsKey(produkt))
       {
           Licz--;
           throw new Problem_With_Produkt("Nie można przechowywać tego produktu w Kontynerze chłodniczym");
           
       }

       if (ograniczenia.GetValueOrDefault(produkt) > temperatura)
       {
           Licz--;
           throw new Problem_With_Produkt("Temperatura jest niższa niż dozwolona");
       }
       Produkt = produkt;
       Temperatura = temperatura;
    }

    public override string ToString()
    {
        return $"{base.ToString()},Produkt = {Produkt},Temperatura = {Temperatura}";
    }
}