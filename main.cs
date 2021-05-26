using System;
using System.IO;
using System.Text;
class MainClass
{
    //imena_fajlova - imena postojecih fajlova
    //GLOBALNE PROMENLJIVE-----------------------------------------------------------------
    public static string ime_fajla = "";
    public static StringBuilder[] celi_tekst = new StringBuilder[100];

    //INICIJALIZACIJA TEKSTA---------------------------------------------------------------
    public static void InicijazlizujTekst()
    {
      Array.Resize(ref celi_tekst, 100);
      for(int i=0; i < celi_tekst.Length; i++)
      {
        celi_tekst[i] = new StringBuilder("");
      }
    }

    //PRAZAN TEKST-------------------------------------------------------------------------
    public static bool PrazanTekst()
    {
      for(int i=0; i < celi_tekst.Length; i++)
      {
        if(celi_tekst[i].ToString() != "") return false;
      }
      return true;
    }
    
    //KRETANJE-----------------------------------------------------------------------------
    public static int kurX = 5;
    public static int kurY = 4;

    static int tablaX = 0;

    static void PomeriDesno()
    {
        if (kurX < 70)
        {
            kurX += 11;
            tablaX++;
        }
    }
    static void PomeriLevo()
    {
        if (kurX > 11)
        {
            kurX -= 11;
            tablaX--;
        }
    }

    //PROVERA SAČUVANJA-----------------------------------------------------------------------
    public static void ProveraSacuvanja()
    {
      Console.SetCursorPosition(0, 7);
      
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Error.WriteLine("Niste sačuvali prethodni fajl!");
      Console.ResetColor();

      Console.SetCursorPosition(kurX, kurY);
      OdaberiPolje();
    }

    //BIRANJE POLJA---------------------------------------------------------------------------
    static void OdaberiPolje()
    {
        ConsoleKeyInfo taster;
        do
        {
          Console.SetCursorPosition(kurX, kurY);
          taster = Console.ReadKey(true);

          if (taster.Key == ConsoleKey.LeftArrow)
          {
              PomeriLevo();
          }
          else if (taster.Key == ConsoleKey.RightArrow)
          {
              PomeriDesno();
          }
        } while (taster.Key != ConsoleKey.Enter);

        //Create
        if (kurX == 5 && kurY == 4)
        {
          //Provera da li je sacuvano
          if(!DaLiJeSacuvano())
          {
            ProveraSacuvanja();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Create();
          }
        }
        //Edit
        else if (kurX == 16 && kurY == 4)
        {
          //Provera da li je sacuvano
          if(!DaLiJeSacuvano())
          {
            ProveraSacuvanja();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Edit();
          }
        }
        //Read
        else if (kurX == 27 && kurY == 4)
        {
          //Provera da li je sacuvano
          if(!DaLiJeSacuvano())
          {
            ProveraSacuvanja();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Read();
          }
        }
        //Delete
        else if (kurX == 38 && kurY == 4)
        {
          //Provera da li je sacuvano
          if(!DaLiJeSacuvano())
          {
            ProveraSacuvanja();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Delete();
          }
        }
        //Save
        else if (kurX == 49 && kurY == 4)
        {
          if(!PrazanTekst())
          {
            Console.Clear();
            IspisMenija2();
            Save();
          }
          else
          {
            Console.SetCursorPosition(0, 7);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Error.WriteLine("Ne postoji fajl koji bi se sačuvao!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
        }
        //SaveAs
        else if (kurX == 60 && kurY == 4)
        {
          if(!PrazanTekst())
          {
            Console.Clear();
            IspisMenija2();
            SaveAs();
          }
          else
          {
            Console.SetCursorPosition(0, 7);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Error.WriteLine("Ne postoji fajl koji bi se sačuvao!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
        }
        //Exit
        else
        {
          //Provera da li je sacuvano
          if(!DaLiJeSacuvano())
          {
            ProveraSacuvanja();
          }
          else
          {
            Exit();
          }
        }
    }

    //DA LI JE SACUVANO------------------------------------------------------------------
    public static bool DaLiJeSacuvano()
    {
      if(celi_tekst.Length != 100) return false;

      foreach(StringBuilder a in celi_tekst)
      {
        if(a.ToString() != "") return false;
      }

      return true;
    }
    
    //ISPISI-----------------------------------------------------------------------------
    public static string Center(string unos)
    {
      return new String(' ', (Console.WindowWidth - unos.Length) / 2) + unos;
    }

    public static void IspisMenija2()
    {
      string naslov_1 = "\u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557";
      string naslov_2 = "\u2551Text Editor\u2551";
      string naslov_3 = "\u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d";
      Console.Clear();
      Console.WriteLine("{0,46}", naslov_1);
      Console.WriteLine("{0,46}", naslov_2);
      Console.WriteLine("{0,46}", naslov_3);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ResetColor();

      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

      Console.Write("\u2551  Create  \u2551   Edit   \u2551   Read   \u2551");

      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Write("  Delete  ");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\u2551");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("   Save   ");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\u2551");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.Write("  Save As ");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\u2551");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("   Exit   ");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\u2551");
      Console.ResetColor();
      Console.WriteLine();

      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
    }

    public static void IspisNapomene()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;

      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

      Console.WriteLine("\u2551  Ako red ima dužinu veću od 80 karaktera, neće biti forirmiran     \u2551");
      Console.WriteLine("\u2551  Kako biste obrisali željeni kakater, pritisnite taster Backspace  \u2551");
      Console.WriteLine("\u2551  Kako biste dodali red tekstu, pritisnite taster Space             \u2551");
      Console.WriteLine("\u2551  Kako biste dodali željeni tekst, pritisnite taster Enter          \u2551");
      Console.WriteLine("\u2551  Kako biste zamenili željeni karakter, pritisnite taster Delete    \u2551");
      Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2               \u2551");
      
      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
      Console.WriteLine();
      Console.ResetColor();
    }

    public static void IspisNapomeneRead()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine();
      Console.WriteLine();
      
      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

      Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2  \u2551");

      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
      Console.ResetColor();
    }

    public static void IspisNapomeneCreate()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine();
      
      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");
      Console.WriteLine("\u2551  Red mora sadržati manje od 81 karaktera, inače se red deli                 \u2551");
      Console.WriteLine("\u2551  Kako biste se zavrsili sa pisanjem teksta, dvaput pritisnite taster Enter  \u2551");
      Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2                        \u2551");

      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
      Console.ResetColor();
    }

    //IZLAZ U MENI------------------------------------------------------------------------------
    public static void IzlazMeni()
    {
      ConsoleKeyInfo taster;

      //Zavrsetak koriscenja opicije koju su izabrali
      while((taster = Console.ReadKey()).Key != ConsoleKey.F2)
      {
        Console.SetCursorPosition(0, Console.CursorTop);
        ObrisiTrenutnuLiniju();
      }
    }

    //OBRISI TRENUTNU LINIJU------------------------------------------------------------------------
    public static void ObrisiTrenutnuLiniju()
    {
      int currentLineCursor = Console.CursorTop;
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth)); 
      Console.SetCursorPosition(0, currentLineCursor);
    }

    //IME FAJLA-------------------------------------------------------------------------------------
    public static string ImeFajla(string[] imena_fajlova)
    {
      string ime = Console.ReadLine();

      bool postoji_ime = true;

      //Formatiranje imena teksta
      while (postoji_ime)
      {
        if(ime.Length <= 4 || (ime.Length >= 5 && ime.Substring(ime.Length-4, 4) != ".txt"))
        {
          ime += ".txt";
        }

        postoji_ime = false;

        //Provera validnosti imena teksta
        for (int i = 0; i < imena_fajlova.Length; i++)
        {
          if(ime == "imena_fajlova.txt")
          {
            Console.Error.Write("Nevalidno ime fajla, pokušajte ponovo: ");
            ime = Console.ReadLine();
            postoji_ime = true;
          }
          if (ime == imena_fajlova[i])
          {
            Console.Error.Write("Već postoji fajl sa upisanim imenom, pokušajte ponovo: ");
            ime = Console.ReadLine();
            postoji_ime = true;
          }
        }
      }

      return ime;
    }
    //CREATE----------------------------------------------------------------------------------------
    public static void Create()
    {
      string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

      Console.WriteLine();
      Console.Write("Unesite ime fajla: ");
      ime_fajla = ImeFajla(imena_fajlova);

      IspisNapomeneCreate();

      //Upis imena fajla u imena_fajlova
      StreamWriter upisi_novo_ime = new StreamWriter("imena_fajlova.txt", true);
      upisi_novo_ime.WriteLine(ime_fajla);
      upisi_novo_ime.Close();

      string red;
      int br = 0;

      celi_tekst[0] = new StringBuilder(" ");

      //Upis lokalno
      while(true)
      {
        if(br >= celi_tekst.Length)
        {
          Array.Resize(ref celi_tekst, celi_tekst.Length*10);
        } 
        red = Console.ReadLine();


        //kraj unosa
        if(red == "") break;

        int maksimalna_duzina_trenutnog_reda=80;

        if(red.Length > maksimalna_duzina_trenutnog_reda)
        {
          for(int i=0; i < red.Length; i+=80)
          {
            if(red.Length - i < 80) celi_tekst[br] = new StringBuilder(red.Substring(i, red.Length-i));
            else celi_tekst[br] = new StringBuilder(red.Substring(i, 80));
            
            br++;
          }
        }
        else
        {
          celi_tekst[br] = new StringBuilder(red);
          br++;
        }
      }

      if(br != 0) Array.Resize(ref celi_tekst, br);
      else Array.Resize(ref celi_tekst, 1);
      
      IzlazMeni();
      
      IspisMenija2();
      OdaberiPolje();
    }

    //POMERANJE KURSORA--------------------------------------------------------------------------------
    public static void KursorGore(int broj_reda)
    {
      if(Console.CursorTop > 6) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-1);

      if(broj_reda > 0 && Console.CursorLeft >= celi_tekst[broj_reda-1].ToString().Length)
      {
        Console.SetCursorPosition(celi_tekst[broj_reda-1].ToString().Length-1, Console.CursorTop);
      }
    }

    public static void KursorDole(int visina, int broj_reda)
    {
      if(Console.CursorTop < visina-1) 
      Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop+1);

      if(broj_reda < celi_tekst.Length-1 && Console.CursorLeft >= celi_tekst[broj_reda+1].ToString().Length)
      {
        Console.SetCursorPosition(celi_tekst[broj_reda+1].ToString().Length-1, Console.CursorTop);
      }
    }

    public static void KursorLevo()
    {
      if(Console.CursorLeft>0)
      {
        Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
      }
    }

    public static void KursorDesno(int duzina)
    {
      if(Console.CursorLeft<duzina-1)
      {  
        Console.SetCursorPosition(Console.CursorLeft+1, Console.CursorTop);
      }
    }

    //EDIT--------------------------------------------------------------------------------

    //UCITAVANJE IMENA--------------------------------------------------------------------
    public static string[] UcitajImenaFajlova(string ime)
    {
      int i = 0;
      string[] imena_fajlova = new string[100];
      StreamReader ulaz = new StreamReader(ime);

      //Ucitavanje iz fajla imena
      while (!ulaz.EndOfStream)
      {
          imena_fajlova[i] = ulaz.ReadLine();
          i++;
      }
      ulaz.Close();
      Array.Resize(ref imena_fajlova, i);

      return imena_fajlova;
    }

    public static void IspisImenaFajlova(string[] imena_fajlova)
    {
      bool prvi = true;

      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("Dostupni fajlovi: ");
      Console.ResetColor();

      foreach (string a in imena_fajlova)
      {
          if (prvi)
          {
              prvi = false;
              Console.WriteLine("{0}", a);
          }
          else
          {
              Console.WriteLine("                  {0}", a);
          }
      }
      Console.WriteLine();
    }

    public static string BiranjeImenaFajlova(string[] imena_fajlova)
    {
        bool postoji_fajl = true;
        string ime;

        do
        {
            if (!postoji_fajl) Console.Error.WriteLine("Traženi fajl ne postoji, pokušajte ponovo: ");
            ime = Console.ReadLine();
            if(ime == "")
            {
              IspisMenija2();
              OdaberiPolje();
            }
            
            postoji_fajl = false;
            
            foreach (string a in imena_fajlova)
            {
                if (ime == a)
                {
                    postoji_fajl = true;
                    break;
                }
            }
        } while (!postoji_fajl);

        return ime;
    }
    
    //NOVI ISPIS EDITA--------------------------------------------------------------------
    public static void NoviIspisEdita()
    {
      Console.Clear();
      IspisMenija2();

      for(int i=0; i < celi_tekst.Length; i++)
      {
        Console.WriteLine(celi_tekst[i].ToString());
      }
    }

    //DODAJ ISPIS TEKSTA------------------------------------------------------------------
    public static void DodajIspisTeksta(int broj_reda, int cuvanje)
    {
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth)); 
      Console.SetCursorPosition(0, Console.CursorTop-1);
      Console.Write(celi_tekst[broj_reda].ToString());
      Console.SetCursorPosition(cuvanje, Console.CursorTop);
    }

    //EDIT--------------------------------------------------------------------------------
    public static void Edit()
    {
        string fajl_imena = "imena_fajlova.txt";
        string[] imena_fajlova = UcitajImenaFajlova(fajl_imena);

        //Ispisi pre rada programa
        IspisImenaFajlova(imena_fajlova);
        Console.WriteLine();
        Console.WriteLine("Ukoliko želite da se vratite na meni pritisnite Enter.");
        Console.WriteLine("Unesite ime fajla koji želite izmeniti: ");
        
        ime_fajla = BiranjeImenaFajlova(imena_fajlova);
        StreamReader ulaz = new StreamReader(ime_fajla);

        Console.Clear();
        IspisMenija2();

        int brojac = 0, red_za_unosenje_teksta=15;
        string red;
        celi_tekst = new StringBuilder[100];

        //Ucitavanje teksta iz fajla trazenog teksta
        while (!ulaz.EndOfStream)
        {
            if(brojac == celi_tekst.Length-1) Array.Resize(ref celi_tekst, celi_tekst.Length*10);
            red = ulaz.ReadLine();
            celi_tekst[brojac] = new StringBuilder(red);
            Console.WriteLine(red);
            brojac++;
        }
        
        ulaz.Close();
        Array.Resize(ref celi_tekst, brojac);

        IspisNapomene();

        //Inicijalizacija edita
        Console.SetCursorPosition(0,6);
        ConsoleKeyInfo taster;
        bool kraj_unosa=false;

        //Glavna petlja za editovanje
        while(!kraj_unosa)
        {
          if(celi_tekst.Length == 0 && celi_tekst[0].ToString().Length == 0)
          {
            IzlazMeni();
          }
          taster = Console.ReadKey(true);
          int broj_reda = Console.CursorTop-6;
          int broj_kolone = Console.CursorLeft;

          //Opcije editovanja

          //Obrisi karakter
          if(taster.Key == ConsoleKey.Backspace && celi_tekst[broj_reda].ToString().Length != 1)
          {
            if(celi_tekst.Length == 1 && celi_tekst[0].ToString().Length == 0) continue;

            celi_tekst[broj_reda].Remove(broj_kolone, 1);
            int cuvanje = Console.CursorLeft;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.Write(celi_tekst[broj_reda].ToString());

            if(cuvanje == celi_tekst[broj_reda].ToString().Length)
            {
              Console.SetCursorPosition(cuvanje-1, Console.CursorTop);
            }
            else
            {
              Console.SetCursorPosition(cuvanje, Console.CursorTop);
            }
          }
          //Brisanje reda kada u trenutnom redu više nema karkatera
          else if(taster.Key == ConsoleKey.Backspace && celi_tekst[broj_reda].ToString().Length == 1)
          {
            if(celi_tekst.Length == 1 && celi_tekst[0].ToString().Length == 1) continue;

            for(int i=broj_reda; i < celi_tekst.Length-1; i++)
            {
              celi_tekst[i] = celi_tekst[i+1];
            }
            int y = Console.CursorTop;

            Array.Resize(ref celi_tekst, celi_tekst.Length-1);
            red_za_unosenje_teksta--;
            
            Console.Clear();
            IspisMenija2();

            for(int i=0; i < celi_tekst.Length; i++)
            {
              Console.WriteLine(celi_tekst[i].ToString());
            }

            IspisNapomene();
            if(broj_reda == 0) Console.SetCursorPosition(0, y);
            else Console.SetCursorPosition(0, y-1);

          }
          //Dodaj tekst
          else if(taster.Key == ConsoleKey.Enter)
          {
            int cuvanje = Console.CursorLeft;
            int x = Console.CursorLeft, y = Console.CursorTop; 
            Console.SetCursorPosition(0, red_za_unosenje_teksta + brojac);

            Console.WriteLine("Unesite tekst koji želite da umetnete na datu poziciju: ");
            string novi_tekst = Console.ReadLine();

            if(celi_tekst[broj_reda].ToString().Length + novi_tekst.Length > 80)
            {
              for(int i=0; i < 100; i++)
              {
                Console.Beep();
              }
              Console.Clear();
              IspisMenija2();

              string red_tr = celi_tekst[broj_reda].ToString().Substring(0, x) + novi_tekst + celi_tekst[broj_reda].ToString().Substring(x, celi_tekst[broj_reda].ToString().Length - x);
              int duzina_reda = red_tr.Length;

              int brojac_novih_redova = duzina_reda / 80;
              if(duzina_reda % 80 > 0) brojac_novih_redova++;
              brojac_novih_redova--;

              //Pomeraj redova ispod dodatnog reda
              Array.Resize(ref celi_tekst, celi_tekst.Length + brojac_novih_redova);

              for(int i=celi_tekst.Length-1; i > broj_reda + brojac_novih_redova; i--)
              {
                celi_tekst[i] = celi_tekst[i-brojac_novih_redova];
              }

              int brojac2=0;
              for(int i=0; i < red_tr.Length; i+=80)
              {
                if(red_tr.Length - i < 80) celi_tekst[broj_reda+brojac2] = new StringBuilder(red_tr.Substring(i, duzina_reda-i));
                else celi_tekst[broj_reda+brojac2] = new StringBuilder(red_tr.Substring(i, 80));
                
                brojac2++;
              }

              red_za_unosenje_teksta += brojac_novih_redova;
              
              //Ispis azuriranog teksta
              for(int i=0; i < celi_tekst.Length; i++)
              {
                Console.WriteLine(celi_tekst[i].ToString());
              }

              IspisNapomene();
              Console.SetCursorPosition(0, y);
            }
            else
            {
              celi_tekst[broj_reda].Insert(broj_kolone, novi_tekst);
              Console.SetCursorPosition(0, red_za_unosenje_teksta + brojac);
              ObrisiTrenutnuLiniju();
              Console.SetCursorPosition(0, red_za_unosenje_teksta + brojac+1);
              ObrisiTrenutnuLiniju();
              Console.SetCursorPosition(x, y);

              DodajIspisTeksta(broj_reda, cuvanje);
            }
          }
          //Zameni karakter
          else if(taster.Key == ConsoleKey.Delete)
          {
            int cuvanje = Console.CursorLeft;
            celi_tekst[broj_reda].Remove(broj_kolone, 1);
            int x = Console.CursorLeft, y = Console.CursorTop; 
            Console.SetCursorPosition(0, red_za_unosenje_teksta + brojac);

            //Unos ispod napomena
            Console.Write("Unesite karakter koji želite da umetnete na datu poziciju: ");
            string karakter = Console.ReadLine();

            while(karakter.Length != 1)
            {
              Console.Error.Write("Pogrešan unos karaktera, pokušajte ponovo: ");
              karakter = Console.ReadLine();
            }
          
            celi_tekst[broj_reda].Insert(broj_kolone, karakter);

            for(int i=Console.CursorTop; i >= red_za_unosenje_teksta + brojac; i--)
            {
              Console.SetCursorPosition(0, i);
              ObrisiTrenutnuLiniju();
            }
            Console.SetCursorPosition(x, y);
            
            DodajIspisTeksta(broj_reda, cuvanje);
          }
          //Novi red teksta
          else if(taster.Key == ConsoleKey.Spacebar)
          {
            int cuvanje = Console.CursorLeft;

            int x = Console.CursorLeft, y = Console.CursorTop; 
            Console.SetCursorPosition(0, red_za_unosenje_teksta + brojac);

            //Unos ispod napomena
            Console.Write("Unesite tekst koji želite da bude upisan u novi red (ispod trenutnog reda) tekstualnog fajla: ");
            string novi_red = Console.ReadLine();

            //Provera validnosti unosa reda, da li je duzi od 80 karaktera
            if(novi_red.Length > 80)
            {
              NoviIspisEdita();
              IspisNapomene();
              Console.SetCursorPosition(x, y);
            }
            else
            {
              Array.Resize(ref celi_tekst, celi_tekst.Length+1);

              for(int i=celi_tekst.Length-1; i > broj_reda+1; i--)
              {
                celi_tekst[i] = celi_tekst[i-1];
              }
              if(novi_red == "") novi_red = " ";

              celi_tekst[broj_reda+1] = new StringBuilder(novi_red);
              red_za_unosenje_teksta++;

              NoviIspisEdita();
              IspisNapomene();
              Console.SetCursorPosition(0, y+1);
            }
          }
          //Kretanje gore
          else if(taster.Key == ConsoleKey.UpArrow)
          {
            KursorGore(broj_reda);
          }
          //Kretanje dole
          else if(taster.Key == ConsoleKey.DownArrow)
          {
            KursorDole(celi_tekst.Length+6, broj_reda);
          }
          //Kretanje levo
          else if(taster.Key == ConsoleKey.LeftArrow)
          {
            KursorLevo();
          }
          //Kretanje desno
          else if(taster.Key == ConsoleKey.RightArrow)
          {
            KursorDesno(celi_tekst[Console.CursorTop-6].ToString().Length);
          }
          else if(taster.Key == ConsoleKey.F2)
          {
            kraj_unosa = true;
          }
        }

        //Izlaz u glavni meni
        IspisMenija2();
        OdaberiPolje();
    }

    //READ----------------------------------------------------------------------------------

    public static void Read()
    {
      string fajl_imena = "imena_fajlova.txt";
      string[] imena_fajlova = UcitajImenaFajlova(fajl_imena);

      //Ispis imena Fajlova
      IspisImenaFajlova(imena_fajlova);
      Console.WriteLine();
      Console.WriteLine("Ukoliko želite da se vratite na meni pritisnite Enter.");
      Console.WriteLine("Unesite ime fajla koji želite prikazati: ");

      ime_fajla = BiranjeImenaFajlova(imena_fajlova);
      StreamReader ulaz = new StreamReader(ime_fajla);

      Console.Clear();
      IspisMenija2();
      Console.WriteLine();

      Console.WriteLine();
      string red;

      //Ucitavanje
      while (!ulaz.EndOfStream)
      {    
        red = ulaz.ReadLine();
        Console.WriteLine(red);
      }

      ulaz.Close();

      IspisNapomeneRead();


      //Izlaz u glavni meni
      IzlazMeni();
      
      IspisMenija2();
      OdaberiPolje();
    }

    //DELETE--------------------------------------------------------------------------------
    public static void Delete()
    {
      string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

      IspisImenaFajlova(imena_fajlova);

      Console.WriteLine("Ukoliko želite da se vratite na meni pritisnite Enter.");
      Console.WriteLine("Unesite ime fajla koji želite obrisati: ");
      
      ime_fajla = BiranjeImenaFajlova(imena_fajlova);

      string kofa;
      for(int i = 0; i < imena_fajlova.Length; i++)
      {
        if(ime_fajla == imena_fajlova[i])
        {
          kofa = imena_fajlova[i]; 
          imena_fajlova[i] = imena_fajlova[imena_fajlova.Length-1];
          imena_fajlova[imena_fajlova.Length-1] = kofa;
        }
      }
      Array.Resize(ref imena_fajlova, imena_fajlova.Length-1);
      StreamWriter brisac = new StreamWriter("imena_fajlova.txt");
      for(int i = 0; i < imena_fajlova.Length; i++)
      {
        brisac.WriteLine(imena_fajlova[i]);
      }
      
      brisac.Close();

      File.Delete(ime_fajla);

      //Izlaz u glavni meni
      IspisMenija2();
      OdaberiPolje();
    }

    //SAVE----------------------------------------------------------------------------------
    public static void Save()
    {
      StreamWriter fajl_ispis = new StreamWriter(ime_fajla);
      
      for(int i = 0; i < celi_tekst.Length; i++)
      {
        fajl_ispis.WriteLine(celi_tekst[i].ToString());
      }
      fajl_ispis.Close();
      InicijazlizujTekst();

      //Izlaz u glavni meni
      IspisMenija2();
      OdaberiPolje();
    }

    //SAVEAS--------------------------------------------------------------------------------
    public static void SaveAs()
    {
      Console.SetCursorPosition(0, 6);
      string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

      if(!File.Exists(ime_fajla))
      {
        string kofa;
        for(int i = 0; i < imena_fajlova.Length; i++)
        {
          if(ime_fajla == imena_fajlova[i])
          {
            kofa = imena_fajlova[i]; 
            imena_fajlova[i] = imena_fajlova[imena_fajlova.Length-1];
            imena_fajlova[imena_fajlova.Length-1] = kofa;
          }
        }
        Array.Resize(ref imena_fajlova, imena_fajlova.Length-1);
        StreamWriter brisac = new StreamWriter("imena_fajlova.txt");
        for(int i = 0; i < imena_fajlova.Length; i++)
        {
          brisac.WriteLine(imena_fajlova[i]);
        }

        brisac.Close();
      }

      Console.Write("Unesite ime novog fajla: ");
      ime_fajla = ImeFajla(imena_fajlova);
      StreamWriter dodaj = new StreamWriter("imena_fajlova.txt", true);
      dodaj.WriteLine(ime_fajla);
      dodaj.Close();

      Save();
      
      InicijazlizujTekst();

      StreamWriter upisi_novo_ime = new StreamWriter("imena_fajlova.txt", true);
      upisi_novo_ime.WriteLine(ime_fajla);
      upisi_novo_ime.Close();

      //Izlaz u glavni meni
      IspisMenija2();
      OdaberiPolje();
    }

    //EXIT----------------------------------------------------------------------------------
    public static void Exit()
    {
      
      StreamReader ulaz = new StreamReader("imena_fajlova.txt");

      int i = 0;
      string[] baci = new string[100];

      //Provera validnosti imena fajlova teksta
      while(!ulaz.EndOfStream)
      {
        if(i >= baci.Length) Array.Resize(ref baci, baci.Length*10);
        baci[i] = ulaz.ReadLine();
        i++;
      }
      ulaz.Close();
      Array.Resize(ref baci, i);
      
      for(int k=0; k < baci.Length-1; k++)
      {
        if(baci[k] == baci[baci.Length-1])
        {
          StreamWriter izlaz = new StreamWriter("imena_fajlova.txt");
          for(int j=0; j < baci.Length-1; j++)
          {
            izlaz.WriteLine(baci[j]);
          }
          izlaz.Close();
          break;
        }
      }
      Console.Clear();

      Console.WriteLine();
      Console.WriteLine();
      
      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");
        
      Console.WriteLine("\u2551  Hvala Vam na korišćenju Text editora!  \u2551");

      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
      
      Environment.Exit(0);
    }
    public static void Main(string[] args)
    {
      Console.Clear();
      InicijazlizujTekst();

      IspisMenija2();
      OdaberiPolje();
    }
}