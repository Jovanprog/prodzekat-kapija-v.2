using System;
using System.IO;
using System.Text;

class MainClass {
  /*
  static bool meni = true;
  static bool kraj = false;
  */
  static int kurX = 5;
	static int kurY = 4;
  /*
  static int pocRed = 5;
	static int pocKol = 6;
  */
  static int tablaX = 0;
	static int tablaY = 0;

  static void PomeriDesno()
	{
		if (kurX < 55) 
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
		} while(taster.Key != ConsoleKey.Enter);
    if(kurX == 5 && kurY == 4)
    {
      Create();  
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

  public static string Center(string unos)
  {
      return new String(' ', (Console.WindowWidth - unos.Length) / 2) + unos;
  }

  public static void IspisMenija()
  {
        string naslov_1 = "\u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557";
        string naslov_2 = "\u2551Text Editor\u2551";
        string naslov_3 = "\u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d";
        
        Console.WriteLine("{0,40}", naslov_1);
        Console.WriteLine("{0,40}", naslov_2);
        Console.WriteLine("{0,40}", naslov_3);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ResetColor();



        Console.WriteLine("\u2553\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2565\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2556");

        Console.Write("\u2551  Create  \u2551   Edit   \u2551   Read   \u2551");
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
        Console.WriteLine("\u2559\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2568\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u255C");
  }

  static void UlazUMeni()
  {
    
    IspisMenija();
  }
  
  /*
  //kod read i edit ispisati imena postojecih fajlova i uraditi selektovanje putem strelica
  static void Meni()
  {
    IspisMenija();
    if()
    {
      Create();
    }
    else if()
    {
      Edit();
    }
    else if()
    {
      Read();
    }
    else if()
    {
      Save();
    }
    else if()
    {
      SaveAs();
    }
    else if()
    {
      Exit();
    }
  }*/
  public static string [] imena_fajlova = {"asd.txt", "oaisfb","astolfo.txt"};
  
  public static void Create()
  {
    Console.Clear();
    Console.Write("Unesite ime fajla: ");
    string ime_fajla = Console.ReadLine();

    bool postoji_ime = true;
    while(postoji_ime)
    {
      postoji_ime = false;
      for(int i = 0; i < imena_fajlova.Length;i++)
      {
        if(ime_fajla == imena_fajlova[i])
        {
          Console.Write("Već postoji fajl sa upisanim imenom, pokušajte ponovo: ");
          ime_fajla = Console.ReadLine();
          postoji_ime = true;
        }
      }  
    }
        
    Console.Write("Unesite ekstenziju fajla: ");
    string ime_ekstenzije = Console.ReadLine();   
    bool los_format_ekstenzije = true;
    while(los_format_ekstenzije)
    {
      los_format_ekstenzije = false;
      if(ime_ekstenzije[0] != '.') 
      {
        Console.WriteLine("Nepostojeca ekstenzija, upisite ponovo");
        ime_ekstenzije = Console.ReadLine();
        
        los_format_ekstenzije = true;
      }
    }

    ime_fajla += ime_ekstenzije;
    FileStream fs = File.Open(ime_fajla, FileMode.Create);
    /*if(ime_ekstenzije == ".bin")
    {
      TekstualniUnos();
      //BinarniUnos();
    }
    else
    {
      TekstualniUnos(ime_fajla);
    }
    */
    

    Edit(fs);
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

  
  //imena_fajlova - imena postojecih fajlova


  public static void Edit(FileStream ime_fajla)
  {
    StreamReader ulaz = new StreamReader(ime_fajla);
    StreamWriter izlaz = new StreamWriter(ime_fajla);
    Console.WriteLine("niggaas");
    while(!ulaz.EndOfStream)
    {
      red = ulaz.ReadLine();
      Console.WriteLine(red);
    }
  }
  

  public static void Read()
  {
    /*
    for(int i = 0; i < imena_fajlova.Length;i++)
    {
      Console.WriteLine(imena_fajlova[i]);
    }
    */
    
    Console.WriteLine("Unesite ime fajla koji zelite da citate");
    string ime_citanje = Console.ReadLine();
    
    if(File.Exists(ime_citanje))
    {
      StreamReader Ulaz = new StreamReader(ime_citanje);
      do{
        string red = Ulaz.ReadLine();
        Console.WriteLine(red);

      }while(!Ulaz.EndOfStream);
       
      Ulaz.Close();    
    }
  }

  /*public static void Save()
  {

  }

  public static void SaveAs()
  {

  }

  public static void Exit()
  {
    kraj = true;
  }*/

  public static void Main (string[] args) {
    Console.Clear();
    IspisMenija();

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