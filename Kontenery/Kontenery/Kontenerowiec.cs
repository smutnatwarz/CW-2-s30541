namespace Kontenery;

public class Kontenerowiec 
{
    public Dictionary<String,Kontener> kontynery_statek=new Dictionary<String,Kontener>();
    public double max_predkosc { get; set; }
    public int liczba_kontynerow { get; set; }
    public double max_wagakontynerow {get; set;} //tonach
    private static int licz=0;
    public int id {get; set;}
    
    public double sumawag {get; set;}

    public Kontenerowiec(double maxPredkosc, int liczbaKontynerowie, double maxWagakontynerow) 
    {
        max_predkosc = maxPredkosc;
        liczba_kontynerow = liczbaKontynerowie;
        max_wagakontynerow = maxWagakontynerow;
        licz++;
        id = licz;
    }

    public void zaladuj(Kontener a)
    {
        if (kontynery_statek.Count + 1 > liczba_kontynerow)
            throw new Kontynerowiec_Exception("Przekroczono liczbe kontynerów na statku");
        if (sumawag + (a.Waga_ladunku+a.Waga_kontenera)*0.001 > max_wagakontynerow)
            throw new Kontynerowiec_Exception("Przekroczono Maksymalną wagę kontynerów");
        
        sumawag += (a.Waga_ladunku+a.Waga_kontenera)*0.001;
       // Console.WriteLine($"WAGAZ = {sumawag}");
       // Console.ReadKey();
        kontynery_statek.Add(a.Numer,a);
    }

    

    public void usun(String a)
    {
        sumawag = sumawag - (kontynery_statek[a].Waga_ladunku+kontynery_statek[a].Waga_kontenera)*0.001;
        //Console.WriteLine($"WAGAU = {sumawag}");
       // Console.ReadKey();
        kontynery_statek.Remove(a);
    }

    public void sprawdz(Kontener moj, Kontener dany)
    {
        double pomocnicza = sumawag;
        pomocnicza-= (moj.Waga_kontenera + moj.Waga_ladunku) * 0.001;
        pomocnicza+=(dany.Waga_kontenera+dany.Waga_ladunku)*0.001;
        if (pomocnicza > max_wagakontynerow)
            throw new Kontynerowiec_Exception($"Nie można zastąpić Kontynerów bo przekroczymy wagę dopuszczalną na statku  {id}");
    }
    public void zastap(Kontener moj, Kontener dany)
    {
        try
        {
            sprawdz(moj, dany);
        }
        catch (Kontynerowiec_Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
            return;
        }
        usun(moj.Numer);
        zaladuj(dany);
    }

    public  override string ToString()
    {
        return $"id = {id},Max_Prędkość = {max_predkosc},Liczba Kontynerów = {liczba_kontynerow}, Max_Wagakontynerow = {max_wagakontynerow}";
    }
}