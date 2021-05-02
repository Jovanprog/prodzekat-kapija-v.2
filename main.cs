using System;
using System.IO;
using System.Text;

class MainClass
{
  
    //U Editu dodaj da kada unosi novi tekst u red taj teks pise dole pa se prikaze u datom redu u samom tekstu


    //imena_fajlova - imena postojecih fajlova
    //GLOBALNE PROMENLJIVE-----------------------------------------------------------------
    //public string[] imena_fajlova = new string[100];
    public static StringBuilder[] celi_tekst = new StringBuilder[100];
    public static string ime_fajla="";

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
            Create();
        }
        else if (kurX == 16 && kurY == 4)
        {
            Edit();
        }
        else if (kurX == 27 && kurY == 4)
        {
            Read();
        }
        else if (kurX == 38 && kurY == 4)
        {
            Delete();
        }
        else if (kurX == 49 && kurY == 4)
        {
            Save(celi_tekst, ime_fajla);
        }
        else if (kurX == 60 && kurY == 4)
        {
            SaveAs(celi_tekst, ime_fajla);
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
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

        Console.WriteLine("\u2551  Kako biste editovali željenu liniju, pritisnite taster F1         \u2551");
        Console.WriteLine("\u2551  Kako biste obrisali željeni kakater, pritisnite taster Backspace  \u2551");
        Console.WriteLine("\u2551  Kako biste dodali željeni tekst, pritisnite taster Enter          \u2551");
        Console.WriteLine("\u2551  Kako biste zamenili željeni karakter, pritisnite taster Delete    \u2551");
        Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2               \u2551");
        


        Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
        Console.ResetColor();
    }

    public static void IspisNapomeneReadCreate()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine();
        
        Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

        Console.WriteLine("\u2551  Kako biste se vratili na meni, pritisnite taster F2  \u2551");

        Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
        Console.ResetColor();
    }

    //kod read i edit ispisati imena postojecih fajlova i uraditi selektovanje putem strelica
    //static void Meni()

    //UPIS TEKSTA U FAJL------------------------------------------------------------------------
    public static void UpisTekstaUFajl(StringBuilder[] celi_tekst, string ime_fajla)
    {
      StreamWriter upis = new StreamWriter(ime_fajla);

      foreach(StringBuilder red in celi_tekst)
      {
        upis.WriteLine(red.ToString());
      }

      upis.Close();
    }

    //CREATE----------------------------------------------------------------------------------------
    public static void Create()
    {
        string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Unesite ime fajla: ");
        ime_fajla = Console.ReadLine();

        bool postoji_ime = true;
        while (postoji_ime)
        {
            postoji_ime = false;
            for (int i = 0; i < imena_fajlova.Length; i++)
            {
                if (ime_fajla == imena_fajlova[i])
                {
                    Console.Write("Već postoji fajl sa upisanim imenom, pokušajte ponovo: ");
                    ime_fajla = Console.ReadLine();
                    postoji_ime = true;
                }
            }
        }
           
        if(ime_fajla.Length <= 4 || (ime_fajla.Length >= 5 && ime_fajla.Substring(ime_fajla.Length-5, 4) != ".txt"))
        {
          ime_fajla += ".txt";
        }

        StreamWriter upisi_novo_ime = new StreamWriter("imena_fajlova.txt", true);
        upisi_novo_ime.WriteLine(ime_fajla);
        upisi_novo_ime.Close();

        FileStream fs = File.Open(ime_fajla, FileMode.Create);

        StreamWriter fajl_ispisa = new StreamWriter(ime_fajla);

        bool kraj_unosa = false;
        string red;

        while(!kraj_unosa)
        {
          red = Console.ReadLine();
        }

        IspisNapomeneReadCreate();
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

    public static string[] UcitajImenaFajlova(string ime_fajla)
    {
        int i = 0;
        string[] imena_fajlova = new string[100];
        StreamReader ulaz = new StreamReader(ime_fajla);

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
        Console.WriteLine();
        Console.WriteLine();
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
        StringBuilder[] celi_tekst = new StringBuilder[100];

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

        ValueTuple<Int32, Int32> koordinate_dugmeta = (Console.CursorLeft,Console.CursorTop);

        int tasterX1=Console.CursorLeft, tasterX2=Console.CursorLeft+21;
        int tasterY1=Console.CursorTop-1, tasterY2=Console.CursorTop-3;

        Console.SetCursorPosition(0,6);
        ConsoleKeyInfo taster;
        while (!(((taster = Console.ReadKey(true)).Key == ConsoleKey.Enter) && (Console.CursorTop <= tasterY2 && Console.CursorTop >= tasterY1) && (Console.CursorLeft >= tasterX1 && Console.CursorLeft <= tasterX2)))
        {
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
                  while(false)
                  {
                    
                  }
                  celi_tekst[broj_reda].Insert(broj_kolone, Console.ReadLine());
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

        string red;
        while (!ulaz.EndOfStream)
        {
            red = ulaz.ReadLine();
            Console.WriteLine(red);
        }

        IspisNapomeneReadCreate();
    }

    //DELETE--------------------------------------------------------------------------------
    public static void Delete()
    {
        string[] imena_fajlova = UcitajImenaFajlova("imena_fajlova.txt");

        IspisImenaFajlova(imena_fajlova);
        Console.WriteLine("Unesite ime fajla koji želite obrisati: ");
        ime_fajla = BiranjeImenaFajlova(imena_fajlova);


    }
    //SAVE----------------------------------------------------------------------------------
    public static void Save(StringBuilder[] celi_tekst, string ime_fajla)
    {
      StreamWriter fajl_ispis = new StreamWriter(ime_fajla);

      foreach(StringBuilder red in celi_tekst)
      {
        fajl_ispis.WriteLine(red.ToString());
      }

      fajl_ispis.Close();
    }

    //SAVEAS--------------------------------------------------------------------------------
    public static void SaveAs(StringBuilder[] celi_tekst, string ime_fajla)
    {
      StreamWriter fajl_ispis = new StreamWriter(ime_fajla);

      foreach(StringBuilder red in celi_tekst)
      {
        fajl_ispis.WriteLine(red.ToString());
      }

      fajl_ispis.Close();
    }

    //EXIT----------------------------------------------------------------------------------
    public static void Exit()
    {
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
        Console.Clear();

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