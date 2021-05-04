using System;
using System.IO;
using System.Text;

class MainClass
{
    //imena_fajlova - imena postojecih fajlova
    //GLOBALNE PROMENLJIVE-----------------------------------------------------------------
    //public string[] imena_fajlova = new string[100];
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
    /*
    static int pocRed = 5;
      static int pocKol = 6;
    */
    static int tablaX = 0;
    static int tablaY = 0;

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
    static void PomeriDole()
    {
        //if (kurY < 8)
        //{
        kurY += 1;
        tablaY++;
        //}
    }
    static void PomeriGore()
    {
        if (kurY > 8)
        {
            kurY -= 1;
            tablaY--;
        }
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

        if (kurX == 5 && kurY == 4)
        {
            if(!DaLiJeSacuvano())
            {
              Console.SetCursorPosition(0, 7);
              
              Console.ForegroundColor = ConsoleColor.DarkRed;
              Console.WriteLine("Niste sačuvali prethodni fajl!");
              Console.ResetColor();

              Console.SetCursorPosition(kurX, kurY);
              OdaberiPolje();
            }
            else
            {
              Console.Clear();
              IspisMenija2();
              Create();
            }
        }
        else if (kurX == 16 && kurY == 4)
        {
            if(!DaLiJeSacuvano())
            {
              Console.SetCursorPosition(0, 7);
              
              Console.ForegroundColor = ConsoleColor.DarkRed;
              Console.WriteLine("Niste sačuvali prethodni fajl!");
              Console.ResetColor();

              Console.SetCursorPosition(kurX, kurY);
              OdaberiPolje();
            }
            else
            {
              Console.Clear();
              IspisMenija2();
              Edit();
            }
        }
        else if (kurX == 27 && kurY == 4)
        {
          if(!DaLiJeSacuvano())
          {
            Console.SetCursorPosition(0, 7);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Niste sačuvali prethodni fajl!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Read();
          }
        }
        else if (kurX == 38 && kurY == 4)
        {
          if(!DaLiJeSacuvano())
          {
            Console.SetCursorPosition(0, 7);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Niste sačuvali prethodni fajl!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
          else
          {
            Console.Clear();
            IspisMenija2();
            Delete();
          }
        }
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
            Console.WriteLine("Ne postoji fajl koji bi se sačuvao!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
        }
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
            Console.WriteLine("Ne postoji fajl koji bi se sačuvao!");
            Console.ResetColor();

            Console.SetCursorPosition(kurX, kurY);
            OdaberiPolje();
          }
        }
        else
        {
            Exit();
        }
    }

    /*static void KretanjeKrozTekst()
	{
		ConsoleKeyInfo taster;
		do
		{
			Console.SetCursorPosition(kurX, kurY);
			taster = Console.ReadKey(true);
			if (taster.Key == ConsoleKey.UpArrow)
      {
				PomeriGore();
      }
			else if (taster.Key == ConsoleKey.DownArrow)
      {
				PomeriDole();
      }
			else if (taster.Key == ConsoleKey.LeftArrow)
      {
        PomeriLevo();
      }
			else if (taster.Key == ConsoleKey.RightArrow)
      {
        PomeriDesno();
      }	
		} while(taster.Key != ConsoleKey.Enter);
	}*/
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

    static void UlazUMeni()
    {
        IspisMenija2();
    }

    public static void IspisNapomene()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

        Console.WriteLine("\u2551  Kako biste editovali željenu liniju, pritisnite taster F1         \u2551");
        Console.WriteLine("\u2551  Kako biste izašli iz editovanja, ponovo pritisnite taster F1      \u2551");
        Console.WriteLine("\u2551  Kako biste obrisali željeni kakater, pritisnite taster Backspace  \u2551");
        Console.WriteLine("\u2551  Kako biste dodali željeni tekst, pritisnite taster Enter          \u2551");
        Console.WriteLine("\u2551  Kako biste zamenili željeni karakter, pritisnite taster Delete    \u2551");
        Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2               \u2551");
        

        Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
        Console.WriteLine();
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
        Console.WriteLine("\u2551  Kako biste se zavrsili sa pisanjem teksta, dvaput pritisnite taster Enter  \u2551");
        Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2                        \u2551");

        Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
        Console.ResetColor();
    }

    //kod read i edit ispisati imena postojecih fajlova i uraditi selektovanje putem strelica
    //static void Meni()
    //IZLAZ U MENI------------------------------------------------------------------------------
    public static void IzlazMeni()
    {
      ConsoleKeyInfo taster;
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
        while (postoji_ime)
        {
          if(ime.Length <= 4 || (ime.Length >= 5 && ime.Substring(ime.Length-4, 4) != ".txt"))
          {
            ime += ".txt";
          }

          postoji_ime = false;

          for (int i = 0; i < imena_fajlova.Length; i++)
          {
              if (ime == imena_fajlova[i])
              {
                  Console.Write("Već postoji fajl sa upisanim imenom, pokušajte ponovo: ");
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

        StreamWriter upisi_novo_ime = new StreamWriter("imena_fajlova.txt", true);
        upisi_novo_ime.WriteLine(ime_fajla);
        upisi_novo_ime.Close();

        //StreamWriter fajl_ispisa = new StreamWriter(ime_fajla);

        bool kraj_unosa = false;
        string red;
        int br = 0;


        while(!kraj_unosa)
        {
          if(br >= celi_tekst.Length)
          {
            Array.Resize(ref celi_tekst, celi_tekst.Length*10);
          } 
          red = Console.ReadLine();
          if(red == "") kraj_unosa = true;
          celi_tekst[br] = new StringBuilder(red);
          br++;
        }

        Array.Resize(ref celi_tekst, br-1);

        IzlazMeni();
        
        IspisMenija2();
        OdaberiPolje();
    }
    /*public static void TekstualniUnos(string ime_fajla)
    {
      StreamWriter Izlaz = new StreamWriter(ime_fajla);
      string s;
      while(unosi_tekst)
      {
        if() 
        {
          unosi_tekst = false;
        }
        ////////////
        s = Console.ReadLine();
      }
      while(!Izlaz.EndOfStream)
      {
        s = Izlaz.ReadLine();
        Console.WriteLine(s);
      }

      Izlaz.Close();
    }*/

    /*//POMERANJE KURSORA--------------------------------------------------------------------------------
    public static void KursorGore()
    {
      if(Console.CursorTop > 16) Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop-1);
      
    }

    public static void KursorDole(int visina)
    {
      if(Console.CursorTop < visina-1) 
      Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop+1);
    }

    public static void KursorLevo()
    {
      if(Console.CursorLeft>0)
      {
        Console.SetCursorPosition(Console.CursorLeft-2, Console.CursorTop);
      }
    }

    public static void KursorDesno(int duzina)
    {
      if(Console.CursorLeft<duzina-1)
      {  
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
      }
    }

    //EDIT--------------------------------------------------------------------------------

    public static string[] UcitajImenaFajlova(string ime_imena_fajlova)
    {
        int i = 0;
        string[] imena_fajlova = new string[100];
        StreamReader ulaz = new StreamReader(ime_imena_fajlova);

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
    }

    public static string BiranjeImenaFajlova(string[] imena_fajlova)
    {
        bool postoji_fajl = true;

        do
        {
            if (!postoji_fajl) Console.WriteLine("Traženi fajl ne postoji, pokušajte ponovo: ");
            ime_fajla = Console.ReadLine();
            postoji_fajl = false;

            foreach (string a in imena_fajlova)
            {
                if (ime_fajla == a)
                {
                    postoji_fajl = true;
                    break;
                }
            }
        } while (!postoji_fajl);

        return ime_fajla;
    }
    

    public static void Edit()
    {
        string fajl_imena = "imena_fajlova.txt";
        string[] imena_fajlova = UcitajImenaFajlova(fajl_imena);

        IspisImenaFajlova(imena_fajlova);
        Console.WriteLine();
        Console.WriteLine("Unesite ime fajla koji želite izmeniti: ");
        ime_fajla = BiranjeImenaFajlova(imena_fajlova);
        StreamReader ulaz = new StreamReader(ime_fajla);

        Console.Clear();
        IspisMenija2();
        Console.WriteLine();
        IspisNapomene();

        int brojac=0;
        string red;
        //StringBuilder[] celi_tekst = new StringBuilder[100];

        while (!ulaz.EndOfStream)
        {
            if(brojac == celi_tekst.Length-1) Array.Resize(ref celi_tekst, celi_tekst.Length*10);
            red = ulaz.ReadLine();
            celi_tekst[brojac] = new StringBuilder(red);
            Console.WriteLine(red);
            brojac++;
        }
        Array.Resize(ref celi_tekst, brojac);

        //int tasterX1=Console.CursorLeft, tasterX2=Console.CursorLeft+21;
        //int tasterY1=Console.CursorTop-1, tasterY2=Console.CursorTop-3;

        Console.SetCursorPosition(0,16);
        ConsoleKeyInfo taster;
        bool kraj_editovanja=false;
        //while (!(((taster = Console.ReadKey(true)).Key == ConsoleKey.Enter) && (Console.CursorTop <= tasterY2 && Console.CursorTop >= tasterY1) && (Console.CursorLeft >= tasterX1 && Console.CursorLeft <= tasterX2)))

        while(!kraj_editovanja)
        {
          taster = Console.ReadKey();
          if(taster.Key == ConsoleKey.F1)
          {
              int broj_reda = Console.CursorTop-16;
              ConsoleKeyInfo taster_edit;
              
              while((taster_edit = Console.ReadKey(true)).Key != ConsoleKey.F1)
              {
                int broj_kolone = Console.CursorLeft;
                if(taster_edit.Key == ConsoleKey.Backspace)
                {
                  celi_tekst[broj_reda].Remove(broj_kolone, 1);
                  Console.SetCursorPosition(0, Console.CursorTop);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
                else if(taster_edit.Key == ConsoleKey.Enter)
                {
                  int x = Console.CursorLeft, y = Console.CursorTop; 
                  Console.SetCursorPosition(0, 14);
                  Console.Write("Unesite tekst koji želite da umetnete na datu poziciju: ");
                  celi_tekst[broj_reda].Insert(broj_kolone, Console.ReadLine());
                  Console.SetCursorPosition(x, y);
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
                else if(taster_edit.Key == ConsoleKey.Delete)
                {
                  celi_tekst[broj_reda].Remove(broj_kolone, 1);
                  
                  Console.SetCursorPosition(0, Console.CursorTop);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
              }
          }
          else if(taster.Key == ConsoleKey.UpArrow)
          {
            KursorGore();
          }
          else if(taster.Key == ConsoleKey.DownArrow)
          {
            KursorDole(celi_tekst.Length+16);
          }
          else if(taster.Key == ConsoleKey.LeftArrow)
          {
            KursorLevo();
          }
          else if(taster.Key == ConsoleKey.RightArrow)
          {
            KursorDesno(celi_tekst[Console.CursorTop-16].ToString().Length);
          }
          else if(taster.Key == ConsoleKey.F2)
          {
            IspisMenija2();
            OdaberiPolje();
          }
        }

        /*do
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
        } while (taster.Key != ConsoleKey.Enter);*/
    //}

    //POMERANJE KURSORA--------------------------------------------------------------------------------
    public static void KursorGore()
    {
      if(Console.CursorTop > 6) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-1);
      
    }

    public static void KursorDole(int visina)
    {
      if(Console.CursorTop < visina-1) 
      Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop+1);
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

    public static string[] UcitajImenaFajlova(string ime)
    {
        int i = 0;
        string[] imena_fajlova = new string[100];
        StreamReader ulaz = new StreamReader(ime);

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
    }

    public static string BiranjeImenaFajlova(string[] imena_fajlova)
    {
        bool postoji_fajl = true;

        do
        {
            if (!postoji_fajl) Console.WriteLine("Traženi fajl ne postoji, pokušajte ponovo: ");
            ime_fajla = Console.ReadLine();
            postoji_fajl = false;

            foreach (string a in imena_fajlova)
            {
                if (ime_fajla == a)
                {
                    postoji_fajl = true;
                    break;
                }
            }
        } while (!postoji_fajl);

        return ime_fajla;
    }
    

    public static void Edit()
    {
        string fajl_imena = "imena_fajlova.txt";
        string[] imena_fajlova = UcitajImenaFajlova(fajl_imena);

        IspisImenaFajlova(imena_fajlova);
        Console.WriteLine();
        Console.WriteLine("Unesite ime fajla koji želite izmeniti: ");
        ime_fajla = BiranjeImenaFajlova(imena_fajlova);
        StreamReader ulaz = new StreamReader(ime_fajla);

        Console.Clear();
        IspisMenija2();

        int brojac=0;
        string red;
        celi_tekst = new StringBuilder[100];

        while (!ulaz.EndOfStream)
        {
            if(brojac == celi_tekst.Length-1) Array.Resize(ref celi_tekst, celi_tekst.Length*10);
            red = ulaz.ReadLine();
            celi_tekst[brojac] = new StringBuilder(red);
            Console.WriteLine(red);
            brojac++;
        }
        Array.Resize(ref celi_tekst, brojac);

        IspisNapomene();

        Console.SetCursorPosition(0,6);
        ConsoleKeyInfo taster;
        bool kraj_unosa=false;
        //while (!(((taster = Console.ReadKey(true)).Key == ConsoleKey.Enter) && (Console.CursorTop <= tasterY2 && Console.CursorTop >= tasterY1) && (Console.CursorLeft >= tasterX1 && Console.CursorLeft <= tasterX2)))
        while(!kraj_unosa)
        {
          taster = Console.ReadKey(true);
          if(taster.Key == ConsoleKey.F1)
          {
              int broj_reda = Console.CursorTop-6;
              ConsoleKeyInfo taster_edit;
              
              while((taster_edit = Console.ReadKey(true)).Key != ConsoleKey.F1)
              {
                int broj_kolone = Console.CursorLeft;
                if(taster_edit.Key == ConsoleKey.Backspace)
                {
                  celi_tekst[broj_reda].Remove(broj_kolone, 1);
                  Console.SetCursorPosition(0, Console.CursorTop);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
                else if(taster_edit.Key == ConsoleKey.Enter)
                {
                  int x = Console.CursorLeft, y = Console.CursorTop; 
                  Console.SetCursorPosition(0, 14+brojac);
                  Console.Write("Unesite tekst koji želite da umetnete na datu poziciju: ");
                  celi_tekst[broj_reda].Insert(broj_kolone, Console.ReadLine());
                  Console.SetCursorPosition(0, 14+brojac);
                  ObrisiTrenutnuLiniju();
                  Console.SetCursorPosition(x, y);
                  Console.SetCursorPosition(0, Console.CursorTop);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
                else if(taster_edit.Key == ConsoleKey.Delete)
                {
                  celi_tekst[broj_reda].Remove(broj_kolone, 1);
                  
                  Console.SetCursorPosition(0, Console.CursorTop);
                  Console.Write(new string(' ', Console.WindowWidth)); 
                  Console.SetCursorPosition(0, Console.CursorTop-1);
                  Console.Write(celi_tekst[broj_reda].ToString());
                }
              }
          }
          else if(taster.Key == ConsoleKey.UpArrow)
          {
            KursorGore();
          }
          else if(taster.Key == ConsoleKey.DownArrow)
          {
            KursorDole(celi_tekst.Length+6);
          }
          else if(taster.Key == ConsoleKey.LeftArrow)
          {
            KursorLevo();
          }
          else if(taster.Key == ConsoleKey.RightArrow)
          {
            KursorDesno(celi_tekst[Console.CursorTop-6].ToString().Length);
          }
          else if(taster.Key == ConsoleKey.F2)
          {
            kraj_unosa = true;
          }
        }

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
        Console.WriteLine("Unesite ime fajla koji želite prikazati: ");

        ime_fajla = BiranjeImenaFajlova(imena_fajlova);
        StreamReader ulaz = new StreamReader(ime_fajla);

        Console.Clear();
        IspisMenija2();
        Console.WriteLine();

        Console.WriteLine();
        string red;
        while (!ulaz.EndOfStream)
        {
            red = ulaz.ReadLine();
            Console.WriteLine(red);
        }

        IspisNapomeneRead();

        IzlazMeni();
        
        IspisMenija2();
        OdaberiPolje();
    }

    //DELETE--------------------------------------------------------------------------------
    public static void Delete()
    {
        string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

        IspisImenaFajlova(imena_fajlova);
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
        IspisMenija2();
        OdaberiPolje();
        //for prolazi kroz fajl imena_fajlova, nalazi dato ime i brise ga, a zatim brise i sam fajl
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
      Console.WriteLine("L");
      InicijazlizujTekst();

      IspisMenija2();
      OdaberiPolje();
    }

    

    
    //SAVEAS--------------------------------------------------------------------------------
    public static void SaveAs()
    {
      /*string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");
      string novo_ime = ImeFajla(imena_fajlova);
      StreamWriter fajl_ispis = new StreamWriter(novo_ime);

      foreach(StringBuilder red in celi_tekst)
      {
        fajl_ispis.WriteLine(red.ToString());
      }
      fajl_ispis.Close();*/

      Console.SetCursorPosition(0, 6);
      string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");
      ime_fajla = ImeFajla(imena_fajlova);
      Save();
      
      InicijazlizujTekst();

      IspisMenija2();
      OdaberiPolje();
    }


    //EXIT----------------------------------------------------------------------------------
    public static void Exit()
    {
      Console.Clear();

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine();
      Console.WriteLine();
      
      Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");
        
      Console.WriteLine("\u2551  Hvala Vam na korišćenju Text editora!  \u2551");

      Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
      Console.ResetColor();
      Console.Beep();
      return;
    }
    //READ----------------------------------------------------------------------------------
    public static void Read1()
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine("Unesite ime fajla koji zelite da citate:");
        string ime_citanje = Console.ReadLine();


        if (File.Exists(ime_citanje))
        {
            StreamReader Ulaz = new StreamReader(ime_citanje);
            do
            {
                string red = Ulaz.ReadLine();
                Console.WriteLine(red);

            } while (!Ulaz.EndOfStream);

            Ulaz.Close();
        }
        else
        {
            Console.WriteLine("fajl ne postoji.");
        }
    }

    public static void Main(string[] args)
    {
        
        InicijazlizujTekst();

        IspisMenija2();

        OdaberiPolje();


        /*if(kraj = true)
        {
          return;
        }*/

    }
}



/*static void Iscrtaj_meni()
  {
    Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string naslov_1 = "\u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557";
        string naslov_2 = "\u2551Text Editor\u2551";
        string naslov_3 = "\u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d";
        Console.WriteLine("{0,100}", naslov_1);
        Console.WriteLine("{0,100}", naslov_2);
        Console.WriteLine("{0,100}", naslov_3);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ResetColor();
  }*/ 