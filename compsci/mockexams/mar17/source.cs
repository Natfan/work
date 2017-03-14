// Skeleton Program code for the AQA A Level Paper 1 2017 examination
// this code whould be used in conjunction with the Preliminary Material
// written by the AQA Programmer Team
// developed in the Visual Studio 2008 programming environment


using System;

namespace PredatorPrey
{
  class Program
  {
    static void Main(string[] args)
    {
      Simulation Sim;
      int MenuOption;
      int LandscapeSize;
      int InitialWarrenCount;
      int InitialFoxCount;
      int Variability;
      bool FixedInitialLocations;
      do
      {
        Console.WriteLine("Predator Prey Simulation Main Menu");
        Console.WriteLine();
        Console.WriteLine("1. Run simulation with default settings");
        Console.WriteLine("2. Run simulation with custom settings");
        Console.WriteLine("3. Exit");
        Console.WriteLine();
        Console.Write("Select option: ");
        MenuOption = Convert.ToInt32(Console.ReadLine());
        if ((MenuOption == 1) || (MenuOption == 2))
        {
          if (MenuOption == 1)
          {
            LandscapeSize = 15;
            InitialWarrenCount = 5;
            InitialFoxCount = 5;
            Variability = 0;
            FixedInitialLocations = true;
          }
          else
          {
            Console.Write("Landscape Size: ");
            LandscapeSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Initial number of warrens: ");
            InitialWarrenCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Initial number of foxes: ");
            InitialFoxCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Randomness variability (percent): ");
            Variability = Convert.ToInt32(Console.ReadLine());
            FixedInitialLocations = false;
          }
          Sim = new Simulation(LandscapeSize, InitialWarrenCount, InitialFoxCount, Variability, FixedInitialLocations);
        }
      } while (MenuOption != 3);
      Console.ReadKey();
    }
  }

  class Location
  {
    public Fox Fox;
    public Warren Warren;

    public Location()
    {
      Fox = null;
      Warren = null;
    }
  }

  class Simulation
  {
    private Location[,] Landscape;
    private int TimePeriod = 0;
    private int WarrenCount = 0;
    private int FoxCount = 0;
    private bool ShowDetail = false;
    private int LandscapeSize;
    private int Variability;
    private static Random Rnd = new Random();

    public Simulation(int LandscapeSize, int InitialWarrenCount, int InitialFoxCount, int Variability, bool FixedInitialLocations)
    {
      int menuOption;
      int x;
      int y;
      string viewRabbits;
      this.LandscapeSize = LandscapeSize;
      this.Variability = Variability;
      Landscape = new Location[LandscapeSize, LandscapeSize];
      CreateLandscapeAndAnimals(InitialWarrenCount, InitialFoxCount, FixedInitialLocations);
      DrawLandscape();
      do
      {
        Console.WriteLine();
        Console.WriteLine("1. Advance to next time period showing detail");
        Console.WriteLine("2. Advance to next time period hiding detail");
        Console.WriteLine("3. Inspect fox");
        Console.WriteLine("4. Inspect warren");
        Console.WriteLine("5. Exit");
        Console.WriteLine();
        Console.Write("Select option: ");
        menuOption = Convert.ToInt32(Console.ReadLine());
        if (menuOption == 1)
        {
          TimePeriod++;
          ShowDetail = true;
          AdvanceTimePeriod();
        }
        if (menuOption == 2)
        {
          TimePeriod++;
          ShowDetail = false;
          AdvanceTimePeriod();
        }
        if (menuOption == 3)
        {
          x = InputCoordinate('x');
          y = InputCoordinate('y');
          if (Landscape[x, y].Fox != null)
          {
            Landscape[x, y].Fox.Inspect();
          }
        }
        if (menuOption == 4)
        {
          x = InputCoordinate('x');
          y = InputCoordinate('y');
          if (Landscape[x, y].Warren != null)
          {
            Landscape[x, y].Warren.Inspect();
            Console.Write("View individual rabbits (y/n)?");
            viewRabbits = Console.ReadLine();
            if (viewRabbits == "y") {
              Landscape[x, y].Warren.ListRabbits();
            }
          }
        }
      } while (((WarrenCount > 0) || (FoxCount > 0)) && (menuOption != 5));
      Console.ReadKey();
    }

    private int InputCoordinate(char Coordinatename)
    {
      int Coordinate;
      Console.Write("  Input " + Coordinatename + " coordinate: ");
      Coordinate = Convert.ToInt32(Console.ReadLine());
      return Coordinate;
    }

    private void AdvanceTimePeriod()
    {
      int NewFoxCount = 0;
      if (ShowDetail)
      {
        Console.WriteLine();
      }
      for (int x = 0; x < LandscapeSize; x++)
      {
        for (int y = 0; y < LandscapeSize; y++)
        {
          if (Landscape[x, y].Warren != null)
          {
            if (ShowDetail)
            {
              Console.WriteLine("Warren at (" + x + "," + y + "):");
              Console.Write("  Period Start: ");
              Landscape[x, y].Warren.Inspect();
            }
            if (FoxCount > 0)
            {
              FoxesEatRabbitsInWarren(x, y);
            }
            if (Landscape[x, y].Warren.NeedToCreateNewWarren())
            {
              CreateNewWarren();
            }
            Landscape[x, y].Warren.AdvanceGeneration(ShowDetail);
            if (ShowDetail)
            {
              Console.Write("  Period End: ");
              Landscape[x, y].Warren.Inspect();
              Console.ReadKey();
            }
            if (Landscape[x, y].Warren.WarrenHasDiedOut())
            {
              Landscape[x, y].Warren = null;
              WarrenCount--;
            }
          }
        }
      }
      for (int x = 0; x < LandscapeSize; x++)
      {
        for (int y = 0; y < LandscapeSize; y++)
        {
          if (Landscape[x, y].Fox != null)
          {
            if (ShowDetail)
            {
              Console.WriteLine("Fox at (" + x + "," + y + "): ");
            }
            Landscape[x, y].Fox.AdvanceGeneration(ShowDetail);
            if (Landscape[x, y].Fox.CheckIfDead())
            {
              Landscape[x, y].Fox = null;
              FoxCount--;
            }
            else
            {
              if (Landscape[x, y].Fox.ReproduceThisPeriod())
              {
                if (ShowDetail) {
                  Console.WriteLine("  Fox has reproduced. ");
                }
                NewFoxCount++;
              }
              if (ShowDetail) {
                Landscape[x, y].Fox.Inspect();
              }
              Landscape[x, y].Fox.ResetFoodConsumed();
            }
          }
        }
      }
      if (NewFoxCount > 0)
      {
        if (ShowDetail)
        { 
          Console.WriteLine("New foxes born: ");
        }
        for (int f = 0; f < NewFoxCount; f++) {
          CreateNewFox();
        }
      }
      if (ShowDetail) {
        Console.ReadKey();
      }
      DrawLandscape();
      Console.WriteLine();
    }

    private void CreateLandscapeAndAnimals(int InitialWarrenCount, int InitialFoxCount, bool FixedInitialLocations)
    {
      for (int x = 0; x < LandscapeSize; x++)
      {
        for (int y = 0; y < LandscapeSize; y++)
        {
          Landscape[x, y] = new Location();
        }
      }
      if (FixedInitialLocations)
      { 
        Landscape[1, 1].Warren = new Warren(Variability, 38);
        Landscape[2, 8].Warren = new Warren(Variability, 80);
        Landscape[9, 7].Warren = new Warren(Variability, 20);
        Landscape[10, 3].Warren = new Warren(Variability, 52);
        Landscape[13, 4].Warren = new Warren(Variability, 67);
        WarrenCount = 5;
        Landscape[2, 10].Fox = new Fox(Variability);
        Landscape[6, 1].Fox = new Fox(Variability);
        Landscape[8, 6].Fox = new Fox(Variability);
        Landscape[11, 13].Fox = new Fox(Variability);
        Landscape[12, 4].Fox = new Fox(Variability);
        FoxCount = 5;
      }
      else
      {
        for (int w = 0; w < InitialWarrenCount; w++)
        {
          CreateNewWarren();
        }
        for (int f = 0; f < InitialFoxCount; f++)
        {
          CreateNewFox();
        }
      }
    }

    private void CreateNewWarren()
    {
      int x, y;
      do
      {
        x = Rnd.Next(0, LandscapeSize);
        y = Rnd.Next(0, LandscapeSize);
      } while (Landscape[x, y].Warren != null);
      if (ShowDetail)
      {
        Console.WriteLine("New Warren at (" + x + "," + y + ")");
      }
      Landscape[x, y].Warren = new Warren(Variability);
      WarrenCount++;
    }

    private void CreateNewFox()
    {
      int x, y;
      do
      {
        x = Rnd.Next(0, LandscapeSize);
        y = Rnd.Next(0, LandscapeSize);
      } while (Landscape[x, y].Fox != null);
      if (ShowDetail) {
        Console.WriteLine("  New Fox at (" + x + "," + y + ")");
      }
      Landscape[x, y].Fox = new Fox(Variability);
      FoxCount++;
    }
    
    private void FoxesEatRabbitsInWarren(int WarrenX, int WarrenY)
    {
      int FoodConsumed;
      int PercentToEat;
      double Dist;
      int RabbitsToEat;
      int RabbitCountAtStartOfPeriod = Landscape[WarrenX, WarrenY].Warren.GetRabbitCount();
      for (int FoxX = 0; FoxX < LandscapeSize; FoxX++)
      {
        for (int FoxY = 0; FoxY < LandscapeSize; FoxY++)
        {
          if (Landscape[FoxX, FoxY].Fox != null)
          {
            Dist = DistanceBetween(FoxX, FoxY, WarrenX, WarrenY);
            if (Dist <= 3.5)
            {
              PercentToEat = 20;
            }
            else if (Dist <= 7)
            {
              PercentToEat = 10;
            }
            else
            {
              PercentToEat = 0;
            }
            RabbitsToEat = (int)Math.Round((double)(PercentToEat * RabbitCountAtStartOfPeriod / 100.0));
            FoodConsumed = Landscape[WarrenX, WarrenY].Warren.EatRabbits(RabbitsToEat);
            Landscape[FoxX, FoxY].Fox.GiveFood(FoodConsumed);
            if (ShowDetail)
            {
              Console.WriteLine("  " + FoodConsumed + " rabbits eaten by fox at (" + FoxX + "," + FoxY + ").");
            }
          }
        }
      }
    }

    private double DistanceBetween(int x1, int y1, int x2, int y2)
    {
      return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
    }

    private void DrawLandscape()
    {
      Console.WriteLine();
      Console.WriteLine("TIME PERIOD: " + TimePeriod);
      Console.WriteLine();
      Console.Write("    ");
      for (int x = 0; x < LandscapeSize; x++)
      {
        if (x < 10)
        {
          Console.Write(" ");
        }
        Console.Write(x + " |");
      }
      Console.WriteLine();
      for (int x = 0; x <= LandscapeSize * 4 + 3; x++)
      {
        Console.Write("-");
      }
      Console.WriteLine();
      for (int y = 0; y < LandscapeSize; y++)
      {
        if (y < 10) {
          Console.Write(" ");
        }
        Console.Write(" " + y + "|");
        for (int x = 0; x < LandscapeSize; x++)
        {
          if (Landscape[x, y].Warren != null)
          {
            if (Landscape[x, y].Warren.GetRabbitCount() < 10)
            {
              Console.Write(" ");
            }
            Console.Write(Landscape[x, y].Warren.GetRabbitCount());
          }
          else
          {
            Console.Write("  ");
          }
          if (Landscape[x, y].Fox != null)
          {
            Console.Write("F");
          }
          else
          {
            Console.Write(" ");
          }
          Console.Write("|");
        }
        Console.WriteLine();
      }
    }
  }

  class Warren
  {
    private const int MaxRabbitsInWarren = 99;
    private Rabbit[] Rabbits;
    private int RabbitCount = 0;
    private int PeriodsRun = 0;
    private bool AlreadySpread = false;
    private int Variability;
    private static Random Rnd = new Random();

    public Warren(int Variability)
    {
      this.Variability = Variability;
      Rabbits = new Rabbit[MaxRabbitsInWarren];
      RabbitCount = (int)(CalculateRandomValue((int)(MaxRabbitsInWarren / 4), this.Variability));
      for (int r = 0; r < RabbitCount; r++)
      {
        Rabbits[r] = new Rabbit(Variability);
      }
    }

    public Warren(int Variability, int rabbitCount)
    {
      this.Variability = Variability;
      this.RabbitCount = rabbitCount;
      Rabbits = new Rabbit[MaxRabbitsInWarren];
      for (int r = 0; r < RabbitCount; r++)
      {
        Rabbits[r] = new Rabbit(Variability);
      }
    }

    private double CalculateRandomValue(int BaseValue, int Variability)
    {
      return BaseValue - (BaseValue * Variability / 100) + (BaseValue * Rnd.Next(0, (Variability * 2) + 1) / 100);
    }

    public int GetRabbitCount()
    {
      return RabbitCount;
    }

    public bool NeedToCreateNewWarren()
    {
      if ((RabbitCount == MaxRabbitsInWarren) && (!AlreadySpread))
      {
        AlreadySpread = true;
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool WarrenHasDiedOut()
    {
      if (RabbitCount == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void AdvanceGeneration(bool ShowDetail)
    {
      PeriodsRun++;
      if (RabbitCount > 0)
      {
        KillByOtherFactors(ShowDetail);
      }
      if (RabbitCount > 0)
      {
        AgeRabbits(ShowDetail);
      }
      if ((RabbitCount > 0) && (RabbitCount <= MaxRabbitsInWarren))
      {
        if (ContainsMales())
        {
          MateRabbits(ShowDetail);
        }
      }
      if ((RabbitCount == 0) && (ShowDetail))
      {
        Console.WriteLine("  All rabbits in warren are dead");
      }
    }

    public int EatRabbits(int RabbitsToEat)
    {
      int DeathCount = 0;
      int RabbitNumber;
      if (RabbitsToEat > RabbitCount)
      {
        RabbitsToEat = RabbitCount;
      }
      while (DeathCount < RabbitsToEat)
      {
        RabbitNumber = Rnd.Next(0, RabbitCount);
        if (Rabbits[RabbitNumber] != null)
        {
          Rabbits[RabbitNumber] = null;
          DeathCount++;
        }
      }
      CompressRabbitList(DeathCount);
      return RabbitsToEat;
    }

    private void KillByOtherFactors(bool ShowDetail)
    {
      int DeathCount = 0;
      for (int r = 0; r < RabbitCount; r++)
      {
        if (Rabbits[r].CheckIfKilledByOtherFactor())
        {
          Rabbits[r] = null;
          DeathCount++;
        }
      }
      CompressRabbitList(DeathCount);
      if (ShowDetail)
      {
        Console.WriteLine("  " + DeathCount + " rabbits killed by other factors.");
      }
    }

    private void AgeRabbits(bool ShowDetail)
    {
      int DeathCount = 0;
      for (int r = 0; r < RabbitCount; r++)
      {
        Rabbits[r].CalculateNewAge();
        if (Rabbits[r].CheckIfDead())
        {
          Rabbits[r] = null;
          DeathCount++;
        }
      }
      CompressRabbitList(DeathCount);
      if (ShowDetail)
      {
        Console.WriteLine("  " + DeathCount + " rabbits die of old age.");
      }
    }

    private void MateRabbits(bool ShowDetail)
    {
      int Mate = 0;
      int Babies = 0;
      double CombinedReproductionRate;
      for (int r = 0; r < RabbitCount; r++)
      {
        if ((Rabbits[r].IsFemale()) && (RabbitCount + Babies < MaxRabbitsInWarren))
        {
          do
          {
            Mate = Rnd.Next(0, RabbitCount);
          } while ((Mate == r) || (Rabbits[Mate].IsFemale()));
          CombinedReproductionRate = (Rabbits[r].GetReproductionRate() + Rabbits[Mate].GetReproductionRate()) / 2;
          if (CombinedReproductionRate >= 1)
          {
            Rabbits[RabbitCount + Babies] = new Rabbit(Variability, CombinedReproductionRate);
            Babies++;
          }
        }
      }
      RabbitCount = RabbitCount + Babies;
      if (ShowDetail)
      {
        Console.WriteLine("  " + Babies + " baby rabbits born.");
      }
    }

    private void CompressRabbitList(int DeathCount)
    {
      if (DeathCount > 0)
      {
        int ShiftTo = 0;
        int ShiftFrom = 0;
        while (ShiftTo < RabbitCount - DeathCount)
        {
          while (Rabbits[ShiftFrom] == null)
          {
            ShiftFrom++;
          }
          if (ShiftTo != ShiftFrom)
          {
            Rabbits[ShiftTo] = Rabbits[ShiftFrom];
          }
          ShiftTo++;
          ShiftFrom++;
        }
        RabbitCount = RabbitCount - DeathCount;
      }
    }

    private bool ContainsMales()
    {
      bool Males = false;
      for (int r = 0; r < RabbitCount; r++)
      {
        if (!Rabbits[r].IsFemale())
        {
          Males = true;
        }
      }
      return Males;
    }

    public void Inspect()
    {
      Console.WriteLine("Periods Run " + PeriodsRun + " Size " + RabbitCount);
    }

    public void ListRabbits()
    {
      if (RabbitCount > 0)
      {
        for (int r = 0; r < RabbitCount; r++)
        {
          Rabbits[r].Inspect();
        }
      }
    }
  }

  class Animal
  {
    protected double NaturalLifespan;
    protected int ID;
    protected static int NextID = 1;
    protected int Age = 0;
    protected double ProbabilityOfDeathOtherCauses;
    protected bool IsAlive;
    protected static Random Rnd = new Random();

    public Animal(int AvgLifespan, double AvgProbabilityOfDeathOtherCauses, int Variability)
    {
      NaturalLifespan = AvgLifespan * CalculateRandomValue(100, Variability) / 100;
      ProbabilityOfDeathOtherCauses = AvgProbabilityOfDeathOtherCauses * CalculateRandomValue(100, Variability) / 100;
      IsAlive = true;
      ID = NextID;
      NextID++;
    }

    public virtual void CalculateNewAge()
    {
      Age++;
      if (Age >= NaturalLifespan)
      {
        IsAlive = false;
      }
    }

    public virtual bool CheckIfDead()
    {
      return !IsAlive;
    }

    public virtual void Inspect()
    {
      Console.Write("  ID " + ID + " ");
      Console.Write("Age " + Age + " ");
      Console.Write("LS " + NaturalLifespan + " ");
      Console.Write("Pr dth " + Math.Round(ProbabilityOfDeathOtherCauses, 2) + " ");
    }

    public virtual bool CheckIfKilledByOtherFactor()
    {
      if (Rnd.Next(0, 100) < ProbabilityOfDeathOtherCauses * 100)
      {
        IsAlive = false;
        return true;
      }
      else
      {
        return false;
      }
    }

    protected virtual double CalculateRandomValue(int BaseValue, int Variability)
    {
      return BaseValue - (BaseValue * Variability / 100) + (BaseValue * Rnd.Next(0, (Variability * 2) + 1) / 100);
    }
  }

  class Fox : Animal
  {
    private int FoodUnitsNeeded = 10;
    private int FoodUnitsConsumedThisPeriod = 0;
    private const int DefaultLifespan = 7;
    private const double DefaultProbabilityDeathOtherCauses = 0.1;

    public Fox(int Variability)
        : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
    {
      FoodUnitsNeeded = (int)(10 * base.CalculateRandomValue(100, Variability) / 100);
    }

    public void AdvanceGeneration(bool ShowDetail)
    {
      if (FoodUnitsConsumedThisPeriod == 0)
      {
        IsAlive = false;
        if (ShowDetail)
        {
          Console.WriteLine("  Fox dies as has eaten no food this period.");
        }
      }
      else
      {
        if (CheckIfKilledByOtherFactor())
        {
          IsAlive = false;
          if (ShowDetail)
          {
            Console.WriteLine("  Fox killed by other factor.");
          }
        }
        else
        {
          if (FoodUnitsConsumedThisPeriod < FoodUnitsNeeded)
          {
            CalculateNewAge();
            if (ShowDetail)
            {
              Console.WriteLine("  Fox ages further due to lack of food.");
            }
          }
          CalculateNewAge();
          if (!IsAlive)
          {
            if (ShowDetail)
            {
              Console.WriteLine("  Fox has died of old age.");
            }
          }
        }
      }
    }

    public void ResetFoodConsumed()
    {
      FoodUnitsConsumedThisPeriod = 0;
    }

    public bool ReproduceThisPeriod()
    {
      const double ReproductionProbability = 0.25;
      if (Rnd.Next(0, 100) < ReproductionProbability * 100)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void GiveFood(int FoodUnits)
    {
      FoodUnitsConsumedThisPeriod = FoodUnitsConsumedThisPeriod + FoodUnits;
    }

    public override void Inspect()
    {
      base.Inspect();
      Console.Write("Food needed " + FoodUnitsNeeded + " ");
      Console.Write("Food eaten " + FoodUnitsConsumedThisPeriod + " ");
      Console.WriteLine();
    }
  }

  class Rabbit : Animal
  {
    enum Genders
    {
      Male,
      Female
    }
    private double ReproductionRate;
    private const double DefaultReproductionRate = 1.2;
    private const int DefaultLifespan = 4;
    private const double DefaultProbabilityDeathOtherCauses = 0.05;
    private Genders Gender;

    public Rabbit(int Variability)
        : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
    {
      ReproductionRate = DefaultReproductionRate * CalculateRandomValue(100, Variability) / 100;
      if (Rnd.Next(0, 100) < 50)
      {
        Gender = Genders.Male;
      }
      else
      {
        Gender = Genders.Female;
      }
    }

    public Rabbit(int Variability, double ParentsReproductionRate)
        : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
    {
      ReproductionRate = ParentsReproductionRate * CalculateRandomValue(100, Variability) / 100;
      if (Rnd.Next(0, 100) < 50)
      {
        Gender = Genders.Male;
      }
      else
      {
        Gender = Genders.Female;
      }
    }

    public override void Inspect()
    {
      base.Inspect();
      Console.Write("Rep rate " + Math.Round(ReproductionRate, 1) + " ");
      Console.WriteLine("Gender " + Gender + " ");
    }

    public bool IsFemale()
    {
      if (Gender == Genders.Female)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public double GetReproductionRate()
    {
      return ReproductionRate;
    }
  }
}