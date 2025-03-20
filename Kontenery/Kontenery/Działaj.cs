namespace Kontenery;

public class Działaj
{
    Dictionary<String,Kontener> kontynery=new Dictionary<String,Kontener>();
    Dictionary<int,Kontenerowiec> statki=new Dictionary<int, Kontenerowiec>();

    public void Uruchom()
    {
        bool wyjsciegl=false;
        while (!wyjsciegl)
        {
            Console.Clear();
            Console.WriteLine("1- Dodaj Kontenerowiec");
            Console.WriteLine("2- Dodaj Kontyner");
            Console.WriteLine("3- Pokaż Listę Kontynerowców");
            Console.WriteLine("4- Pokaż Listę Kontynerów");
            Console.WriteLine("5- Wyjście");
            var a = Console.ReadLine();
            String b;

            switch (a)
            {
                case "1":

                    Console.WriteLine("Wpisz (Maksymalną_prędkość;liczbe_kontrynerów;Maksymalna_waga_przewozowa)");
                    b = Console.ReadLine();
                    String[] wpisa = b.Split(';');
                    dodajstatek(new Kontenerowiec(double.Parse(wpisa[0]), int.Parse(wpisa[1]), double.Parse(wpisa[2])));
                    break;


                case "2":
                    Console.Clear();
                    Console.WriteLine("1- Na Płyn");
                    Console.WriteLine("2- Na Gaz");
                    Console.WriteLine("3- Chłodniczy");
                    var c = Console.ReadLine();
                    switch (c)
                    {
                        case "1":

                            Console.WriteLine(
                                "Wpisz (Wysokość_Kontynera;Wage_Kontynera;Głębokość_Kontynera;Maksymalna_Wage_Ładunku;Czy_Płyn_Jest_Niebezpieczny(true/false))");
                            b = Console.ReadLine();
                            wpisa = b.Split(';');
                            dodajkontyner(new Plyny(double.Parse(wpisa[0]), int.Parse(wpisa[1]), double.Parse(wpisa[2]),
                                double.Parse(wpisa[3]), bool.Parse(wpisa[4])));
                            break;
                        case "2":
                            Console.WriteLine(
                                "Wpisz (Wysokość_Kontynera;Wage_Kontynera;Głębokość_Kontynera;Maksymalna_Wage_Ładunku;Ciśnienie)");
                            b = Console.ReadLine();
                            wpisa = b.Split(';');
                            dodajkontyner(new Gaz(double.Parse(wpisa[0]), int.Parse(wpisa[1]), double.Parse(wpisa[2]),
                                double.Parse(wpisa[3]), double.Parse(wpisa[4])));
                            break;
                        case "3":
                            Console.WriteLine(
                                "Wpisz (Wysokość_Kontynera;Wage_Kontynera;Głębokość_Kontynera;Maksymalna_Wage_Ładunku;Nazwe_Produktów,Temperature_Przechowywania)");
                            b = Console.ReadLine();
                            wpisa = b.Split(';');
                            try
                            {
                                Chlodniczy pomocniczy = new Chlodniczy(double.Parse(wpisa[0]), int.Parse(wpisa[1]),
                                    double.Parse(wpisa[2]), double.Parse(wpisa[3]), wpisa[4],
                                    double.Parse(wpisa[5]));
                                dodajkontyner(pomocniczy);
                            }
                            catch (Problem_With_Produkt e)
                            {
                                Console.WriteLine($"Tworzenie Kontynera nie powiodło się. {e.Message}");
                                Console.ReadKey();
                            }

                            break;
                    }

                    break;


                case "3":
                    Console.Clear();
                    if (statki.Count == 0) Console.WriteLine("Brak Kontenerowców Do Wyświetlenia");
                    else
                    {
                        foreach (Kontenerowiec k in statki.Values)
                        {
                            Console.WriteLine(k);
                        }
                        Console.WriteLine("1- Wyświetl Opcje Wybranego Kontynerowca");
                        Console.WriteLine("2- Wyjdz z listy");
                        var opcjatstaku = Console.ReadLine();
                                switch (opcjatstaku)
                                {
                                     case "1":
                                         Console.WriteLine("Wpisz (numer_statku)");
                                         b = Console.ReadLine();
                                         wpisa = b.Split(';');
                                         Kontenerowiec wybrany_kontynerowiec = statki.GetValueOrDefault(
                                             int.Parse(wpisa[0]));
                                         bool wyborconakontynerze = false;
                                                     while (!wyborconakontynerze)
                                                     {
                                                         Console.Clear();
                                                         Console.WriteLine("1- Wyświetl Załadowane Kontynery Na Tym Statku");
                                                         Console.WriteLine("2- Załaduj Kontyner");
                                                         Console.WriteLine("3- Usuń Kontyner");
                                                         Console.WriteLine("4- Zastąp Kontyner");
                                                         Console.WriteLine("5- Wyjdz Do Menu");
                                                         var opcjaroz = Console.ReadLine();
                                                             switch (opcjaroz)
                                                             {
                                                                  case "1":
                                                                      wyswietl_kontynery_ze_statk(wybrany_kontynerowiec);
                                                                      Console.ReadKey();
                                                                      break;
                                                                  case "2":
                                                                      Console.Clear();
                                                                      if (wyswietlkontynery())
                                                                      {
                                                                         
                                                                          Console.WriteLine("Wpisz (numer_kontynera) lub (numer_Kontynera;numer_kolejnego;...)");
                                                                          var czytam = Console.ReadLine();
                                                                          String []dziel = czytam.Split(';');
                                                                                  if (dziel.Length == 1)
                                                                                  {
                                                                                      try
                                                                                      {
                                                                                         wybrany_kontynerowiec
                                                                                              .zaladuj(kontynery.GetValueOrDefault(
                                                                                                  dziel[0]));
                                                                                          kontynery.Remove(dziel[0]);
                                                                                      }
                                                                                      catch (Kontynerowiec_Exception e)
                                                                                      {
                                                                                          Console.WriteLine($"Nie można załadować kontynera {e.Message}");
                                                                                          Console.ReadKey(); 
                                                                                      }
                                                                                  }
                                                                                  else
                                                                                  {
                                                                                      
                                                                                      foreach (var d in dziel)
                                                                                      {
                                                                                          try
                                                                                          {
                                                                                             wybrany_kontynerowiec
                                                                                                  .zaladuj(kontynery.GetValueOrDefault(
                                                                                                      d));
                                                                                              kontynery.Remove(d);
                                                                                          }
                                                                                          catch (Kontynerowiec_Exception e)
                                                                                          {
                                                                                              Console.WriteLine($"Nie można załadować kontynera {d} {e.Message}");
                                                                                              Console.ReadKey(); 
                                                                                          }
                                                                                      }
                                                                                  }
                                                                      }
                                                                      else
                                                                      {
                                                                          Console.WriteLine("Nie mamy kontynerów do załadowania");
                                                                          Console.ReadKey(); 
                                                                      }
                                                                      break;
                                                                  case "3":
                                                                      Console.Clear();
                                                                      if(wyswietl_kontynery_ze_statk(wybrany_kontynerowiec))
                                                                      {
                                                                          Console.WriteLine("Wpisz (numer_Kontynera)");
                                                                          var czytam = Console.ReadLine();
                                                                          String []dziel = czytam.Split(';');
                                                                          dodajkontyner(wybrany_kontynerowiec.kontynery_statek.GetValueOrDefault(dziel[0]));
                                                                          wybrany_kontynerowiec.usun(dziel[0]);
                                                                         
                                                                      }
                                                                      else
                                                                      {
                                                                          Console.WriteLine("Statek jest pusty");
                                                                          Console.ReadKey();
                                                                      }
                                                                      
                                                                      break;
                                                                  
                                                                      case "4":
                                                                          if (!wyswietl_kontynery_ze_statk(
                                                                                  wybrany_kontynerowiec))
                                                                          {
                                                                              Console.WriteLine("Nie mamy czego na statku zastąpić");
                                                                              Console.ReadKey();
                                                                          }
                                                                          else
                                                                          {
                                                                              Console.WriteLine("Wpisz (numer_Kontynera_do_zamiany)");
                                                                              var czytam = Console.ReadLine();
                                                                              String []dziel = czytam.Split(';');
                                                                              Console.Clear();
                                                                                  if
                                                                                      (!
                                                                                       wyswietl_wszystko_poza_kontynerami_ze_statku(
                                                                                           wybrany_kontynerowiec))
                                                                                  {
                                                                                      
                                                                                      Console.WriteLine("Nie mamy na co zastąpić");
                                                                                      Console.ReadKey();
                                                                                  }
                                                                                  else
                                                                                  {
                                                                                      Console.WriteLine("jeśli z przechowalni wpisz (numer_kontynera) , jeśli ze statku (id_statku;numer_kontynera)");
                                                                                      var wybor_uzytkownika=Console.ReadLine();
                                                                                      String []przeczytano= wybor_uzytkownika.Split(';');
                                                                                      Kontener naszkontyner=wybrany_kontynerowiec.kontynery_statek.GetValueOrDefault(dziel[0]);
                                                                                          if (przeczytano.Length == 1)
                                                                                          {
                                                                                              
                                                                                                  wybrany_kontynerowiec
                                                                                                      .zastap(
                                                                                                          naszkontyner,
                                                                                                          kontynery
                                                                                                              .GetValueOrDefault(
                                                                                                                  przeczytano
                                                                                                                      [0]));
                                                                                                  dodajkontyner(naszkontyner);
                                                                                                  kontynery.Remove(
                                                                                                      przeczytano[0]);

                                                                                          }
                                                                                          else
                                                                                          {
                                                                                              Kontenerowiec innystatek =
                                                                                                  statki
                                                                                                      .GetValueOrDefault(
                                                                                                          int.Parse(przeczytano[
                                                                                                              0]));

                                                                                              Kontener innykontyner =
                                                                                                  innystatek
                                                                                                      .kontynery_statek
                                                                                                      .GetValueOrDefault(
                                                                                                          przeczytano[
                                                                                                              1]);
                                                                                              
                                                                                              try
                                                                                              {
                                                                                                  innystatek.sprawdz(
                                                                                                      innykontyner,
                                                                                                      naszkontyner);
                                                                                                  wybrany_kontynerowiec.sprawdz(naszkontyner,innykontyner);     
                                                                                                  innystatek.zastap(innykontyner,
                                                                                                               naszkontyner);
                                                                                                  wybrany_kontynerowiec.zastap(naszkontyner,innykontyner);
                                                                                              }
                                                                                              catch
                                                                                                  (Kontynerowiec_Exception
                                                                                                   e)
                                                                                              {
                                                                                                  Console.WriteLine(e.Message);
                                                                                                  Console.ReadKey();
                                                                                              }
                                                                                          }
                                                                                      
                                                                                  }

                                                                          }
                                                                          
                                                                          break;
                                                                      
                                                                        case "5":
                                                                            wyborconakontynerze = true;
                                                                            break;
                                                                  
                                                             }
                                                         
                                                     }
                                             
                                         break;
                                     case "2":
                                         break;
                                          
                                }

                    }

                    Console.ReadKey();
                    break;



                case "4":


                    bool wyjsciekontynera = false;
                    while (!wyjsciekontynera)
                    {
                        Console.Clear();

                        if (!wyswietlkontynery())
                        {
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("1- Załaduj towar");
                        Console.WriteLine("2- Wyładuj towar");
                        Console.WriteLine("3- Usuń Kontyner");
                        Console.WriteLine("4- Wyjdz z listy");
                        var opcjakontyner = Console.ReadLine();
                            switch (opcjakontyner)
                            {
                                case "1":
                                    Console.WriteLine("Wpisz (numer_kontynera;waga_do_załadowania)");
                                    b = Console.ReadLine();
                                    wpisa = b.Split(';');
                                    try
                                    {
                                         kontynery.GetValueOrDefault(wpisa[0]).zaladuj_kontenery(double.Parse(wpisa[1]));
                                         Console.ReadKey();
                                    }
                                    catch (OverfillException e)
                                    {
                                        Console.WriteLine($"Nie Wykonano Załadunku {e.Message}");
                                        Console.ReadKey();
                                    }

                                    break;

                                case "2":
                                    Console.WriteLine("Wpisz (numer_kontynera)");
                                    b = Console.ReadLine();
                                    wpisa = b.Split(';');
                                    kontynery.GetValueOrDefault(wpisa[0]).oproznij_ladunek();
                                    break;

                                case "3":
                                    Console.WriteLine("Wpisz (numer_kontynera)");
                                    b = Console.ReadLine();
                                    wpisa = b.Split(';');
                                    kontynery.Remove(wpisa[0]);
                                    break;
                                case "4":
                                    wyjsciekontynera = true;
                                    break;
                            }
                    }

                    break;



                case "5":
                    wyjsciegl = true;
                    break;

            }
        }
    }
        
         void dodajstatek(Kontenerowiec a)
        {
            statki.Add(a.id,a);
        }
    
         void dodajkontyner(Kontener a)
        {
            kontynery.Add(a.Numer,a);
        }



        bool wyswietl_kontynery_ze_statk(Kontenerowiec a)
        {
            if (a.kontynery_statek.Count == 0)
            {
                Console.WriteLine("Brak Kontynerów Do Wyświetlenia");
                return false;
            }
            foreach (Kontener c in a.kontynery_statek.Values)
            {
                Console.WriteLine(c);
            }
           

            return true;
            
        }
         bool wyswietlkontynery()
        {
            
            if (kontynery.Count == 0 )
            {
                Console.WriteLine("Brak Kontynerów Do Wyświetlenia");
                return false;
            }
            
                foreach (Kontener c in kontynery.Values)
                {
                    Console.WriteLine(c);
                }
           

            return true;

        }

        public bool wyswietl_wszystko_poza_kontynerami_ze_statku(Kontenerowiec c)
        {
            bool a = false;
            Console.WriteLine("Kontynery w Poczekalni:");
            if (wyswietlkontynery()) a = true;
            foreach (var kontynerowiec in statki)
            {
                if (kontynerowiec.Key != c.id)
                {
                    Console.WriteLine($"ID Statku ={kontynerowiec.Key}");
                    if(wyswietl_kontynery_ze_statk(kontynerowiec.Value)) a=true;
                }
            }
            return a;
        }
         
         
}