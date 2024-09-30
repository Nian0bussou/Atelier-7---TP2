
using System.Linq;
using System.Collections.Generic;
using System.IO;

public struct PointXZ
{
   public static PointXZ PositionInitiale = new PointXZ(-1, -1);
   public float X { get; private set; }
   public float Z { get; private set; }
   public PointXZ(float x, float z)
   {
      X = x;
      Z = z;
   }
}
public class Carte
{
   const string CheminAccèsData = "Assets/Resources/Data/";
   const char SymboleCible = 'C';
   const char SymboleDestination = 'D';
   const char SymboleSource = 'S';
   const char SymboleMine = 'M';
   const char SymboleInaccessible = '*';

   public int LargeurCarte { get; private set; }
   public int HauteurCarte { get; private set; }
   public List<PointXZ> Cibles { get; private set; }
   public List<PointXZ> Caisses { get; private set; }
   public List<PointXZ> Mines { get; private set; }
   public PointXZ PositionSource { get; private set; }
   public PointXZ PositionDestination { get; private set; }

   char[,] DataCarte;
   public char this[int y, int x]
   {
      get
      {
         return DataCarte[y, x];
      }
   }

   public Carte(string nomFichier)
   {
      PositionSource = PointXZ.PositionInitiale;
      PositionDestination = PointXZ.PositionInitiale;
      Cibles = new List<PointXZ>();
      Caisses = new List<PointXZ>();
      Mines = new List<PointXZ>();
      string[] donnéesBrutesCarte = LireDonnéesCarte(CheminAccèsData + nomFichier);
      DataCarte = CréerCarte(donnéesBrutesCarte);
   }

   static string[] LireDonnéesCarte(string nomFichier)
   {
      List<string> listeDonnéeCarte = new List<string>();
      StreamReader fEntrée = new StreamReader(nomFichier);
      while (!fEntrée.EndOfStream)
      {
         string ligneCarte = fEntrée.ReadLine();
         listeDonnéeCarte.Insert(0, ligneCarte);
      }
      fEntrée.Close();
      return listeDonnéeCarte.ToArray();
   }

   char[,] CréerCarte(string[] donnéesBrutesCarte)
   {
      LargeurCarte = donnéesBrutesCarte.Min(x => x.Length);
      HauteurCarte = donnéesBrutesCarte.Length;
      char[,] modèleCarte = new char[HauteurCarte, LargeurCarte];
      for (int y = 0; y < HauteurCarte; ++y)
      {
         for (int x = 0; x < LargeurCarte; ++x)
         {
            char symbole = donnéesBrutesCarte[y][x];
            modèleCarte[y, x] = TraiterDonnéeBrute(symbole, x, y);
         }
      }
      return modèleCarte;
   }

   private char TraiterDonnéeBrute(char symbole, int x, int y)
   {
      switch (symbole)
      {
         case SymboleSource:
            PositionSource = new PointXZ(x, y);
            break;
         case SymboleDestination:
            PositionDestination = new PointXZ(x, y);
            break;
         case SymboleCible:
            Cibles.Add(new PointXZ(x, y));
            break;
         case SymboleMine:
            Mines.Add(new PointXZ(x, y));
            break;
         case SymboleInaccessible:
            Caisses.Add(new PointXZ(x, y));
            break;
         default:
            break;
      }
      return symbole;
   }
}
