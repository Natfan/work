using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace StoryTellerTextBasedAdventureGame {
    public class Config {
        public static bool debug = true;

        public static FileStream Q = new FileStream("config.txt", FileMode.OpenOrCreate, FileAccess.Write);
        public static char gamePlay_next_upper = ConfigurationSettings.AppSettings.Get(
            #region URL
            "C://Users/natha_000/Documents/Visual Studio 2015/Projects/StoryTellerTextBasedAdventureGame/StoryTellerTextBasedAdventureGame/" +
            #endregion
            "App.config/config/gamePlay/next_upper").ToCharArray()[1];
        //public static char gamePlay_next_upper = 'C';
        public static ConsoleKey gamePlay_back = ConsoleKey.Backspace;
        public static ConsoleKey gamePlay_exit = ConsoleKey.Escape;
        public static bool text_textType = true;
        public static int text_textFreq(int value) {
            //int text_textFreq = 0; // DEBUG, COMMENT OUT IF NEEDED.
            int text_textFreq = 45000; //LIVE, COMMENT OUT IF NEEDED.

            value = text_textFreq;

            return value;
        }
        public static ConsoleColor foregroundColor = ConsoleColor.Gray;
        public static ConsoleColor backgroundColor = ConsoleColor.Black;
    }

    class Program {
        static bool noType = false;
        static bool gameRunning = false;

        #region Constants
        const int ms = 1000;
        #endregion

        #region Settings
        bool settings_text_textType = Config.text_textType;
        static int settings_text_textFreq = Config.text_textFreq / ms; // In Seconds

        static char settings_gamePlay_next_upper = Config.gamePlay_next_upper;
        char settings_gamePlay_next_lower = char.ToLower(settings_gamePlay_next_upper);

        static ConsoleKey settings_gamePlay_back = Config.gamePlay_back;

        static ConsoleKey settings_gamePlay_exit = Config.gamePlay_exit;
        #endregion

        #region Strings
        #region GameText
        string gameText_next = "\n\nPress " + settings_gamePlay_next_upper + " to continue. ";
        string gameText_back = "\nPress " + settings_gamePlay_back + " to go back. ";
        string gameText_exit = "\nPress " + settings_gamePlay_exit + " to quit.";
        #region ImportantWords
        static string gameText_importantWords_game = "StoryTeller";
        static string gameText_importantWords_gameTitle = gameText_importantWords_game + " - The Virtual Gamebook";
        #endregion

        #region Welcome
        string gameText_welcomeText_Welcome = "Hello, and welcome to " + gameText_importantWords_game + "\nIn this game, you make the decisions and the story builds around your actions. \nWhen prompted, type where you want to go or what you want to do. \nYou shall be prompted with what options you can do. \n\nThe following is an example: \nYou enter a room. You can go 'F'(ORWARDS), 'B'(ACKWARDS), 'L'(EFT), 'R'(IGHT). \nYour choice must match the options given, but does not have to be case sensitive. \nDo not attempt to complete the example; nothing will happen.";
        #endregion

        #region Menu
        string gameText_menuText_Main = "Main Menu \n1) Play \n2) Statistics \n3) Achievements \n4) Credits ";
        string gameText_menuText_Play = "Play \nOh, hi there " + Environment.UserName + ". Pick an option, please.\n1) Start A New Game ";
        string gameText_menuText_Stats = "Statistics \nTHINGS GO HERE LATER FIGURE IT OUT LATER.";
        string gameText_menuText_Achievements = "Achievements \nTHINGS GO HERE LATER FIGURE IT OUT LATER.";
        string gameText_menuText_Credits = "Credits \n" + credits_title_leadDeveloper + ": " + credits_name_nathanWindisch + "\n" + credits_title_writer + ": " + credits_name_oliEastGreenCox + "\n" + credits_title_writer + ": " + credits_name_nathanWindisch + "\n" + credits_title_tester + ": " + credits_name_jamesCox + " " + credits_notes_norelation;
        string gameText_menuText_PressNumberToSelectItem = "FIX THIS LATER";
        #region Play Menu
        string gameMenu_menuText_playMenu_resumeGame = "\n2) Resume Previous Game";
        #endregion
        #endregion

        #region StoryText
        #endregion

        #region Credits
        #region Titles
        static string credits_title_leadDeveloper = "Lead Developer";
        static string credits_title_writer = "Writer";
        static string credits_title_tester = "Tester";
        #endregion

        #region People
        static string credits_name_nathanWindisch = "Nathan Windisch";
        static string credits_name_oliEastGreenCox = "Oli Eastgreen Cox";
        static string credits_name_jamesCox = "James Cox";
        #endregion

        #region Notes
        static string credits_notes_norelation = "(No relation)";
        #endregion

        #endregion

        #endregion

        #endregion


        static void Main(string[] args) {
            Console.Clear();
            new Program().run();

        }

        void run() {
            Console.Title = gameText_importantWords_gameTitle;
            Console.SetWindowSize(100, Console.WindowHeight);
            Console.ForegroundColor = Config.foregroundColor;
            Console.BackgroundColor = Config.backgroundColor;

            while (!Console.KeyAvailable) {
                Console.Clear();
                //Console.WriteLine(random(0, 5));
                type(gameText_welcomeText_Welcome);
                type(gameText_next);
                noType = true;

                ConsoleKeyInfo next = Console.ReadKey();
                if (next.KeyChar == settings_gamePlay_next_lower || next.KeyChar == settings_gamePlay_next_upper) {
                    Console.Clear();
                    MainMenu();
                } if (next.Key == ConsoleKey.Escape) {
                    Environment.Exit(0);
                } else {
                    Console.Clear();
                    run();
                }
                Console.ReadLine();
            }
            Console.ReadKey();
        }

        void MainMenu() {
            //prepend();
            type(gameText_menuText_Main);
            append();
            ConsoleKeyInfo next = Console.ReadKey();
            if (next.KeyChar == '1') {
                prepend();
                PlayMenu();
            }
            if (next.KeyChar == '2') {
                prepend();
                StatisticsMenu();
            }
            if (next.KeyChar == '3') {
                prepend();
                AchievementsMenu();
            }
            if (next.KeyChar == '4') {
                prepend();
                CreditsMenu();
            }
            if (next.Key == settings_gamePlay_back) {
                prepend();
                MainMenu();
            } if (next.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            } else {
                //prepend();
                MainMenu();
            }
        }

        void PlayMenu() {
            type(gameText_menuText_Play);
            if (gameRunning) {
                type(gameMenu_menuText_playMenu_resumeGame);
            }

            ConsoleKeyInfo next = Console.ReadKey();
            if (next.KeyChar == '1') {
                prepend();
                game();
            }
            if (gameRunning) {
                if (next.KeyChar == '2') {
                    prepend();
                    resume();
                }
            }
            if (next.Key == ConsoleKey.Backspace) {
                prepend();
                MainMenu();
            }  if (next.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            } else {
                prepend();
                PlayMenu();
            }
        }

        void StatisticsMenu() {
            //type(gameText_menuText_Stats);
            type(gameText_next);
            wip();
            MainMenu();
            append();

            ConsoleKeyInfo next = Console.ReadKey();
            if (next.Key == ConsoleKey.Backspace) {
                prepend();
                MainMenu();
            } if (next.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            } else {
                prepend();
                StatisticsMenu();
            }
        }

        void AchievementsMenu() {
            //type(gameText_menuText_Achievements);
            wip();
            MainMenu();
            append();

            ConsoleKeyInfo next = Console.ReadKey();
            if (next.Key == ConsoleKey.Backspace) {
                prepend();
                MainMenu();
            } if (next.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            } else {
                prepend();
                StatisticsMenu();
            }
        }

        void CreditsMenu() {
            type(gameText_menuText_Credits);
            append();

            ConsoleKeyInfo next = Console.ReadKey();
            if (next.Key == ConsoleKey.Backspace) {
                prepend();
                MainMenu();
            } if (next.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            } else {
                prepend();
                StatisticsMenu();
            }
        }

        void game() {
            wip();
            MainMenu();
        }

        void resume() {
            wip();
            MainMenu();
        }

        void random(int i, int j, int x) {
            Random random = new Random();
            x = random.Next(i, j);
        }

        void type(string value) {
            for (int i = 0; i < value.Length; ++i) {
                Console.Write(value.ToCharArray()[i]);
                wait(settings_text_textFreq);
            }
        }

        void wip() {
            warning("This is a Work In Progress, sending you to the Main Menu instead.\n\n");
        }

        void warning(string value) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            type(value);
            Console.ForegroundColor = Config.foregroundColor;
        }

        void error(string value) {
            Console.ForegroundColor = ConsoleColor.Red;
            type(value);
            Console.ForegroundColor = Config.foregroundColor;
        }

        void wait(int i) {
            System.Threading.Thread.Sleep(i);
        }

        void prepend() {
            Console.Clear();
        }

        void append() {
            type("\n");
            type(gameText_back);
            type(gameText_exit);
        }
    }
}
