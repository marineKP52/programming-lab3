using Lab3.Task1;
using Lab3.Task2;
using System.Text.Json;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task 1

            Season currentSeason = Season.Winter;

            JuiceProductFactory factory = null;

            try
            {
                factory = JuiceFactorySelector.GetJuiceFactory(currentSeason);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

            JuiceProduct fruitJuice = factory.CreateFruitJuiceProduct("Apple Juice");

            JuiceProduct berryJuice = factory.CreateBerryJuiceProduct("Strawberry Juice");

            Console.WriteLine($"Current season: {currentSeason}");
            Console.WriteLine("\nCreated products:");

            Console.WriteLine(fruitJuice.ShowProduct());
            Console.WriteLine(berryJuice.ShowProduct());


            // Task 2

            Game game = new Game();

            Console.WriteLine("\nInitial enemies:");
            game.ShowEnemies();

            game.Attack(game.Enemies[0], 6);
            game.Attack(game.Enemies[1], 25);

            Console.WriteLine("\nEnemies after attacks:");
            game.ShowEnemies();

            game.Attack(game.Enemies[0], 6);
            game.Attack(game.Enemies[1], 25);
            game.Attack(game.Enemies[2], 1);

            Console.WriteLine("\nEnemies after attacks:");
            game.ShowEnemies();
        }
    }  
}


