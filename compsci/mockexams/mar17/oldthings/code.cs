// Skeleton program code for the AQA COMP1 Summer 2015 examination
// this code should be used in conjunction with the Preliminary Material
// written by the AQA COMP1 Programmer Team
// developed in the Visual C# 2008 Express programming environment

// Version 2 31/03/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaptureTheSarrum
{
  class Program
  {
    public const int BoardDimension = 8;
    static void Main(string[] args)
    {
      string[,] Board = new string[BoardDimension + 1, BoardDimension + 1];
      Boolean GameOver;
      int StartSquare = 0;
      int FinishSquare = 0;
      int StartRank = 0;
      int StartFile = 0;
      int FinishRank = 0;
      int FinishFile = 0;
      Boolean MoveIsLegal;
      char PlayAgain;
      char SampleGame;
      char WhoseTurn;
      PlayAgain = 'Y';
      do
      {
        WhoseTurn = 'W';
        GameOver = false;
        Console.Write("Do you want to play the sample game (enter Y for Yes)? ");
        SampleGame = char.Parse(Console.ReadLine());
        if ((int)SampleGame >= 97 && (int)SampleGame <= 122)
          SampleGame = (char)((int)SampleGame - 32);
        InitialiseBoard(ref Board, SampleGame);
        do 
        {
          DisplayBoard(Board);
          DisplayWhoseTurnItIs(WhoseTurn);
          MoveIsLegal = false;
          do 
          {
            GetMove(ref StartSquare, ref FinishSquare);
            StartRank = StartSquare % 10;
            StartFile = StartSquare / 10;
            FinishRank = FinishSquare % 10;
            FinishFile = FinishSquare / 10;
            MoveIsLegal = CheckMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile, WhoseTurn);
            if (!MoveIsLegal)
              Console.WriteLine("That is not a legal move - please try again");
          } while (!MoveIsLegal);
          GameOver = CheckIfGameWillBeWon(Board, FinishRank, FinishFile);
          MakeMove(ref Board, StartRank, StartFile, FinishRank, FinishFile, WhoseTurn);
          if (GameOver)
            DisplayWinner(WhoseTurn);
          if (WhoseTurn == 'W')
            WhoseTurn = 'B';
          else
            WhoseTurn = 'W';
        } while (!GameOver);
        Console.Write("Do you want to play again (enter Y for Yes)? ");
        PlayAgain = char.Parse(Console.ReadLine());
        if ((int)PlayAgain >= 97 && (int)PlayAgain <= 122)
          PlayAgain = (char)((int)PlayAgain - 32);
      } while (PlayAgain == 'Y');
    }

    public static void DisplayWhoseTurnItIs(char WhoseTurn)
    {
      if (WhoseTurn == 'W')
        Console.WriteLine("It is White's turn");
      else
        Console.WriteLine("It is Black's turn");
    }

    public static char GetTypeOfGame()
    {
      char TypeOfGame;
      Console.Write("Do you want to play the sample game (enter Y for Yes)? ");
      TypeOfGame = char.Parse(Console.ReadLine());
      return TypeOfGame;
    }

    public static void DisplayWinner(char WhoseTurn)
    {
      if (WhoseTurn == 'W')
        Console.WriteLine("Black's Sarrum has been captured.  White wins!");
      else
        Console.WriteLine("White's Sarrum has been captured.  Black wins!");
      Console.WriteLine();
    }

    public static Boolean CheckIfGameWillBeWon(string[,] Board, int FinishRank, int FinishFile)   
    {
      Boolean GameWon;
      if (Board[FinishRank, FinishFile][1] == 'S')
        GameWon = true;
      else
        GameWon = false;
      return GameWon;     
    }

    public static void DisplayBoard(string[,] Board)
    {
      int RankNo;
      int FileNo;
      Console.WriteLine();
      for (RankNo = 1; RankNo <= BoardDimension; RankNo++)
      {
        Console.WriteLine("    _________________________");
        Console.Write(RankNo + "   ");
        for (FileNo = 1; FileNo <= BoardDimension; FileNo++)
          Console.Write("|" + Board[RankNo, FileNo]);
        Console.WriteLine("|");
      }
      Console.WriteLine("    _________________________");
      Console.WriteLine("     1  2  3  4  5  6  7  8");
      Console.WriteLine();
      Console.WriteLine();
    }

    public static Boolean CheckRedumMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile, char ColourOfPiece)
    {
      Boolean RedumMoveIsLegal = false;
      if (ColourOfPiece == 'W')
      {
        if (FinishRank == StartRank - 1)
          if ((FinishFile == StartFile) && (Board[FinishRank, FinishFile] == "  "))
            RedumMoveIsLegal = true;
          else
            if ((Math.Abs(FinishFile - StartFile) == 1) && (Board[FinishRank, FinishFile][0] == 'B'))
              RedumMoveIsLegal = true;
      }
      else
      {
         if (FinishRank == StartRank + 1)
           if ((FinishFile == StartFile) && (Board[FinishRank, FinishFile] == "  "))
             RedumMoveIsLegal = true;
           else
             if ((Math.Abs(FinishFile - StartFile) == 1) && (Board[FinishRank, FinishFile][0] == 'W'))
               RedumMoveIsLegal = true;
      }
      return RedumMoveIsLegal;
    }

    public static Boolean CheckSarrumMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile)   
    {
      Boolean SarrumMoveIsLegal = false;
      if ((Math.Abs(FinishFile - StartFile) <= 1) && (Math.Abs(FinishRank - StartRank) <= 1))
        SarrumMoveIsLegal = true;
      return SarrumMoveIsLegal;
    }

    public static Boolean CheckGisgigirMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile)
    {
      Boolean GisgigirMoveIsLegal;
      int Count;
      int RankDifference;
      int FileDifference;
      GisgigirMoveIsLegal = false;
      RankDifference = FinishRank - StartRank;
      FileDifference = FinishFile - StartFile;
      if (RankDifference == 0)
      {
        if (FileDifference >= 1)
        {
          GisgigirMoveIsLegal = true;
          for (Count = 1; Count <= FileDifference - 1; Count++)
            if (Board[StartRank, StartFile + Count] != "  ")
              GisgigirMoveIsLegal = false;
        }
        else
          if (FileDifference <= -1)
          {
            GisgigirMoveIsLegal = true;
            for (Count = -1; Count >= FileDifference + 1; Count--)
              if (Board[StartRank, StartFile + Count] != "  ")
                GisgigirMoveIsLegal = false;
          }
      }
      else if (FileDifference == 0)
        if (RankDifference >= 1)
        {
          GisgigirMoveIsLegal = true;
          for (Count = 1; Count <= RankDifference - 1; Count++)
          {
            if (Board[StartRank + Count, StartFile] != "  ")
              GisgigirMoveIsLegal = false;
          }
        }
        else
          if (RankDifference <= -1)
          {
            GisgigirMoveIsLegal = true;
            for (Count = -1; Count >= RankDifference + 1; Count--)
              if (Board[StartRank + Count, StartFile] != "  ")
                GisgigirMoveIsLegal = false;
          }
      return GisgigirMoveIsLegal;
    }

    public static Boolean CheckNabuMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile)     
    {
      Boolean NabuMoveIsLegal = false;
      if ((Math.Abs(FinishFile - StartFile) == 1) && (Math.Abs(FinishRank - StartRank)) == 1)
        NabuMoveIsLegal = true;
      return NabuMoveIsLegal;
    }

    public static Boolean CheckMarzazPaniMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile)     
    {
      Boolean MarzazPaniMoveIsLegal = false;
      if (((Math.Abs(FinishFile - StartFile) == 1) && (Math.Abs(FinishRank - StartRank) == 0) ||
      ((Math.Abs(FinishFile - StartFile) == 0) && (Math.Abs(FinishRank - StartRank) == 1))))
        MarzazPaniMoveIsLegal = true;
      return MarzazPaniMoveIsLegal;
    }

    public static Boolean CheckEtluMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile)     
    {
      Boolean EtluMoveIsLegal = false;
      if ((Math.Abs(FinishFile - StartFile) == 2) && (Math.Abs(FinishRank - StartRank) == 0)
      || (Math.Abs(FinishFile - StartFile) == 0) && (Math.Abs(FinishRank - StartRank) == 2))
        EtluMoveIsLegal = true;
      return EtluMoveIsLegal;   
    }

    public static Boolean CheckMoveIsLegal(string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile, char WhoseTurn)     
    {
      char PieceType;
      char PieceColour;
      Boolean MoveIsLegal = true;
      if ((FinishFile == StartFile) && (FinishRank == StartRank))
        MoveIsLegal = false;
      PieceType = Board[StartRank, StartFile][1];   
      PieceColour = Board[StartRank, StartFile][0];
      if (WhoseTurn == 'W')
      {
        if (PieceColour != 'W')
          MoveIsLegal = false;
        if (Board[FinishRank, FinishFile][0] == 'W')
          MoveIsLegal = false;
      }
      else
      {
        if (PieceColour != 'B')
          MoveIsLegal = false;
        if (Board[FinishRank, FinishFile][0] == 'B')
          MoveIsLegal = false;
      }
      if (MoveIsLegal)
        switch (PieceType)
        {
          case 'R':
            MoveIsLegal = CheckRedumMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile, PieceColour);
            break;
          case 'S':
            MoveIsLegal = CheckSarrumMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile);
            break;
          case 'M':
            MoveIsLegal = CheckMarzazPaniMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile);
            break;
          case 'G':
            MoveIsLegal = CheckGisgigirMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile);
            break;
          case 'N':
            MoveIsLegal = CheckNabuMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile);
            break;
          case 'E':
            MoveIsLegal = CheckEtluMoveIsLegal(Board, StartRank, StartFile, FinishRank, FinishFile);
            break;
          default:
            MoveIsLegal = false;
            break;
        }
      return MoveIsLegal; 
    }

    public static void InitialiseBoard(ref string[,] Board, char SampleGame) 
    {
      int RankNo;
      int FileNo;
      if (SampleGame == 'Y')
      {
        for (RankNo = 1; RankNo <= BoardDimension; RankNo++)
          for (FileNo = 1; FileNo <= BoardDimension; FileNo++)
            Board[RankNo, FileNo] = "  ";
        Board[1, 2] = "BG";
        Board[1, 4] = "BS";
        Board[1, 8] = "WG";
        Board[2, 1] = "WR";
        Board[3, 1] = "WS";
        Board[3, 2] = "BE";
        Board[3, 8] = "BE";
        Board[6, 8] = "BR";
      }
      else
        for (RankNo = 1; RankNo <= BoardDimension; RankNo++)
          for (FileNo = 1; FileNo <= BoardDimension; FileNo++)
            if (RankNo == 2)
              Board[RankNo, FileNo] = "BR";
            else
              if (RankNo == 7)
                Board[RankNo, FileNo] = "WR";
              else
                if ((RankNo == 1) || (RankNo == 8))
                {
                  if (RankNo == 1)
                    Board[RankNo, FileNo] = "B";
                  if (RankNo == 8)
                    Board[RankNo, FileNo] = "W";
                  switch (FileNo)
                  {
                    case 1:
                    case 8:
                      Board[RankNo, FileNo] = Board[RankNo, FileNo] + "G";
                      break;
                    case 2:
                    case 7:
                      Board[RankNo, FileNo] = Board[RankNo, FileNo] + "E";
                      break;
                    case 3:
                    case 6:
                      Board[RankNo, FileNo] = Board[RankNo, FileNo] + "N";
                      break;
                    case 4:
                      Board[RankNo, FileNo] = Board[RankNo, FileNo] + "M";
                      break;
                    case 5:
                      Board[RankNo, FileNo] = Board[RankNo, FileNo] + "S";
                      break;
                  }
                }
                else
                  Board[RankNo, FileNo] = "  ";
    }

    public static void GetMove(ref int StartSquare, ref int FinishSquare)
    {
      Console.Write("Enter cooordinates of square containing piece to move (file first): ");
      StartSquare = int.Parse(Console.ReadLine());
      Console.Write("Enter cooordinates of square to move piece to (file first): ");
      FinishSquare = int.Parse(Console.ReadLine());
    }

    public static void MakeMove(ref string[,] Board, int StartRank, int StartFile, int FinishRank, int FinishFile, char WhoseTurn)
    {
      if ((WhoseTurn == 'W') && (FinishRank == 1) && (Board[StartRank, StartFile][1] == 'R'))
      {
        Board[FinishRank, FinishFile] = "WM";
        Board[StartRank, StartFile] = "  ";
      }
      else
        if ((WhoseTurn == 'B') && (FinishRank == 8) && (Board[StartRank, StartFile][1] == 'R'))
        {
          Board[FinishRank, FinishFile] = "BM";
          Board[StartRank, StartFile] = "  ";
        }
        else
        {
          Board[FinishRank, FinishFile] = Board[StartRank, StartFile];
          Board[StartRank, StartFile] = "  ";
        }
    }
  }
}