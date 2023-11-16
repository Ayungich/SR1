using System.Globalization;

namespace C_Test
{
    public class AdditionallyFunctions
    {
        public static void DrawRotatingHeart()
        {
            var defaultColor = Console.ForegroundColor;

            string[] heartFrames = new string[]
            {
            "  ♥   \n ♥ ♥ \n♥   ♥\n ♥ ♥ \n  ♥  ",
            "   ♥  \n  ♥ ♥\n ♥   ♥ \n♥ ♥  \n ♥   ",
            "    ♥ \n   ♥ ♥ \n  ♥   ♥\n ♥ ♥ \n♥    ",
            "     ♥\n    ♥ ♥\n   ♥   ♥ \n  ♥ ♥\n ♥   "
            };

            Console.ForegroundColor = ConsoleColor.Red;

            do
            {
                foreach (var frame in heartFrames)
                {
                    Console.Clear();
                    Console.WriteLine(frame);
                    Thread.Sleep(50); 
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

            Console.ForegroundColor = defaultColor;
        }
        public static void SlowColorWriteLine(string? inputText, ConsoleColor color)
        {
            if (string.IsNullOrEmpty(inputText))
                    throw new ArgumentNullException("Input text is null or empty.");

            var defaulColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            
            foreach (var c in inputText)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }

            Console.ForegroundColor = defaulColor;
        }
        public static double DoubleCheck(string outputText, ConsoleColor color)
        {
            SlowColorWriteLine(outputText, color);

            bool isCorrect;
            double data;
            CultureInfo culture = CultureInfo.InvariantCulture;

            do
            {
                isCorrect = double.TryParse(Console.ReadLine(), NumberStyles.Any, culture, out data);

                if (!isCorrect || data <= 0)
                {
                    SlowColorWriteLine("\nIncorrect data, please try again:\n-> ", ConsoleColor.DarkCyan);
                }
            } while (!isCorrect || data <= 0);

            return data;
        }
    }
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                AdditionallyFunctions.SlowColorWriteLine("Нажмите Enter для продолжения или Escape для выхода...\n", ConsoleColor.DarkCyan);
                ConsoleKey exitKey = Console.ReadKey(true).Key;

                if (exitKey == ConsoleKey.Escape)
                {
                    AdditionallyFunctions.SlowColorWriteLine("Exiting...", ConsoleColor.DarkCyan);
                    Thread.Sleep(300);
                    Environment.Exit(0);    
                }

                else if (exitKey == ConsoleKey.Enter)
                {
                    Console.Clear();
                    double D = AdditionallyFunctions.DoubleCheck("Введите значения диаметра:\n-> ", ConsoleColor.DarkCyan);

                    try
                    {
                        Circle newCircle = new(D);
                        AdditionallyFunctions.SlowColorWriteLine("\n->Создан объект ««Окружность»»\n", ConsoleColor.DarkCyan);

                        AdditionallyFunctions.SlowColorWriteLine("\nХотите округлить результаты?(Y|N)\n", ConsoleColor.DarkCyan);
                        ConsoleKey choiceKey = Console.ReadKey(true).Key;

                        switch (choiceKey)
                        {
                            case ConsoleKey.Y:
                                Console.Clear();
                                AdditionallyFunctions.SlowColorWriteLine("Результаты:\n", ConsoleColor.DarkCyan);
                                Console.WriteLine(Circle.ToStringWithRound());
                                break;

                            case ConsoleKey.N:
                                Console.Clear();
                                AdditionallyFunctions.SlowColorWriteLine("Результаты:\n", ConsoleColor.DarkCyan);
                                Console.WriteLine(newCircle.ToString());
                                break;

                            case ConsoleKey.F:
                                AdditionallyFunctions.DrawRotatingHeart();
                                break;

                            default:
                                Console.Clear();
                                AdditionallyFunctions.SlowColorWriteLine("\nВы ничего не выбрали.\n", ConsoleColor.Red);
                                break;
                        }                
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        AdditionallyFunctions.SlowColorWriteLine(ex.Message, ConsoleColor.Red);
                    }

                    AdditionallyFunctions.SlowColorWriteLine("\nНажмите Enter для продолжения или \'Escape\' для выхода...", ConsoleColor.DarkCyan);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}