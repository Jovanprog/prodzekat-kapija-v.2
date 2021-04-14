using System;

class MainClass {

  static bool meni = true;
  static bool kraj = false;
  static int kurX = 3;
	static int kurY = 6;
  static int pocRed = 3;
	static int pocKol = 6;
  static int tablaX = 0;
	static int tablaY = 0;

  static void PomeriDesno()
	{
		if (kurX < 35) 
		{
			kurX+=4;
			tablaX++;
		}
	}
	static void PomeriDole()
	{
		if (kurY < 20)
		{
			kurY+=2;
			tablaY++;
		}
	}
	static void PomeriGore()
	{
		if (kurY > 6)
		{
			kurY-=2;
			tablaY--;
		}
	}
	static void PomeriLevo()
	{
		if (kurX > 7)
		{
			kurX-=4;
			tablaX--;
		}
	}


	/*static void OdaberiPolje()
	{
		ConsoleKeyInfo cki;
		do
		{
			Console.SetCursorPosition(kurX, kurY);
			cki = Console.ReadKey(true);
			if (cki.Key == ConsoleKey.UpArrow)
				PomeriGore();
			else if (cki.Key == ConsoleKey.DownArrow)
				PomeriDole();
			else if (cki.Key == ConsoleKey.LeftArrow)
				PomeriLevo();
			else if (cki.Key == ConsoleKey.RightArrow)
				PomeriDesno();
			else if (cki.Key == ConsoleKey.Escape)
				meni = true;
		} while (meni != true  && cki.Key != ConsoleKey.F1);
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

  public static void Exit()
  {
    kraj = true;
  }

  public static void Main (string[] args) {
    IspisMenija();        

    
    if(kraj = true)
    {
      return;
    }

  }
}