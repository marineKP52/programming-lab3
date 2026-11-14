using System.Text.Json;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("Initial enemies:");
            game.ShowEnemies();

            game.Attack(game.Enemies[0], 6);
            game.Attack(game.Enemies[1], 25);

            game.ShowEnemies();
        }
    }

    public abstract class JuiceProduct
    {
        public string Name { get; set; }
        public string RawMaterialVariety { get; }
        public string PackageColor { get; }
        public decimal Price { get; }

        protected JuiceProduct(string name, string materialVariety, string packageColor, decimal price)
        {
            Name = name;
            RawMaterialVariety = materialVariety;
            PackageColor = packageColor;
            Price = price;
        }

        public abstract string ShowProduct();
    }

    public class FruitJuiceProduct : JuiceProduct
    {
        private static readonly decimal _priceCoeff = 1.1m;
        
        public float PulpConcentration { get; }

        public FruitJuiceProduct(string name, string materialVariety, string packageColor, 
            decimal price, float pulpConcentration) : base (name, materialVariety, packageColor, price * _priceCoeff)
        {
            PulpConcentration = pulpConcentration;
        }

        public override string ShowProduct()
        {
            return $"Name: {Name} | Raw Material Variety: {RawMaterialVariety} | Pulp Concentration: {PulpConcentration} " +
                $"Package Color: {PackageColor} | PRICE: {Price} UAH";
        }
    }

    public class BerryJuiceProduct : JuiceProduct
    {
        private static readonly decimal _priceCoeff = 1.3m;
        public int BerryConcentrationPercentage { get; }

        public BerryJuiceProduct(string name, string materialVariety, string packageColor,
            decimal price, int berryPercantage) : base(name, materialVariety, packageColor, price * _priceCoeff)
        {
            BerryConcentrationPercentage = berryPercantage;
        }

        public override string ShowProduct()
        {
            return $"Name: {Name} | Raw Material Variety: {RawMaterialVariety} | Berry Concentration: {BerryConcentrationPercentage}% " +
                $"Package Color: {PackageColor} | PRICE: {Price} UAH";
        }
    }

    public abstract class JuiceProductFactory
    {
        public abstract FruitJuiceProduct CreateFruitJuiceProduct(string name);
        public abstract BerryJuiceProduct CreateBerryJuiceProduct(string name);
    }

    public class JuiceProductFactoryA : JuiceProductFactory
    {
        private static readonly JuiceProductFactoryA _instance = new JuiceProductFactoryA();

        private JuiceProductFactoryA()
        {

        }

        public static JuiceProductFactoryA Instance => _instance;

        public override FruitJuiceProduct CreateFruitJuiceProduct(string name)
        {
            return new FruitJuiceProduct(name, "Golden Apples", "Green", 80, 0.1f);
        }

        public override BerryJuiceProduct CreateBerryJuiceProduct(string name)
        {
            return new BerryJuiceProduct(name, "Honey Strawberry", "Red", 100, 40);
        }
    }

    public class JuiceProductFactoryB : JuiceProductFactory
    {
        private static readonly JuiceProductFactoryB _instance = new JuiceProductFactoryB();

        private JuiceProductFactoryB()
        {

        }

        public static JuiceProductFactoryB Instance => _instance;

        public override FruitJuiceProduct CreateFruitJuiceProduct(string name)
        {
            return new FruitJuiceProduct(name, "Symyrenko Apples", "Yellow", 90, 0.15f);
        }

        public override BerryJuiceProduct CreateBerryJuiceProduct(string name)
        {
            return new BerryJuiceProduct(name, "Asia Strawberry", "Purple", 120, 45);
        }
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public static class JuiceFactorySelector
    {
        public static JuiceProductFactory GetJuiceFactory(Season season)
        {
            switch (season)
            {
                case Season.Winter: return JuiceProductFactoryA.Instance;
                case Season.Spring: return JuiceProductFactoryB.Instance;
                case Season.Summer: return JuiceProductFactoryB.Instance;
                case Season.Autumn: return JuiceProductFactoryA.Instance;
                default:
                    {
                        throw new ArgumentException("Error: Unlnown season.");
                    }
            }
        }
    }



    public abstract class EnemyBotPrototype
    {
        protected static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public int HealthLevel { get; set; }
        public bool HasCloned { get; set; }
        public int Limit { get; protected set; }
        public List<string> Abilities { get; set; }

        protected EnemyBotPrototype(string name)
        {
            Name = name;
            HasCloned = false;
        }

        protected void SetNewId()
        {
            Id = _nextId;
            _nextId++;
        }

        public bool IsClonable()
        {
            return HealthLevel > 0 && HealthLevel <= Limit && !HasCloned;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || HealthLevel <= 0)
            {
                return;
            }

            HealthLevel -= damage;

            if (HealthLevel < 0)
            {
                HealthLevel = 0;
            }
        }

        public string Show()
        {
            return $"ID: {Id} | Name: {Name} | HP: {HealthLevel} | Abilities: {string.Join(", ", Abilities)}";
        }

        public abstract EnemyBotPrototype Clone();
    }

    public class EnemyBot : EnemyBotPrototype
    {
        public EnemyBot(string name, int healthLevel, int limit, List<string> abilities) : base(name)
        {
            HealthLevel = healthLevel;
            Limit = limit;
            Abilities = abilities;
        }

        public override EnemyBotPrototype Clone()
        {
            string json = JsonSerializer.Serialize(this);

            EnemyBot bot = JsonSerializer.Deserialize<EnemyBot>(json);

            bot.SetNewId();
            return bot;
        }
    }

    public class EnemyBotManager
    {
        private readonly Dictionary<string, EnemyBotPrototype> _bots;


        public EnemyBotManager()
        {
            _bots = new Dictionary<string, EnemyBotPrototype>();

            AddBots();
        }

        private void AddBots()
        {
            EnemyBot regularBot = new EnemyBot("Goblin", 10, 5, new List<string> { "Regular attack", "Fast attack" });
            EnemyBot strongBot = new EnemyBot("Orc", 40, 25, new List<string> { "Regular attack", "Fast attack", "Dodge" });

            _bots.Add("Regular", regularBot);
            _bots.Add("Strong", strongBot);
        }


        public EnemyBotPrototype GetBotClone(string type)
        {
            if (!_bots.ContainsKey(type))
                return null;

            return _bots[type].Clone();
        }
    }

    public class Game
    {
        private EnemyBotManager _manager;
        private List<EnemyBotPrototype> _enemies;
        public IReadOnlyList<EnemyBotPrototype> Enemies => _enemies;

        public Game()
        {
            _manager = new EnemyBotManager();
            _enemies = new List<EnemyBotPrototype>();

            _enemies.Add(_manager.GetBotClone("Regular"));
            _enemies.Add(_manager.GetBotClone("Strong"));
        }

        public void Attack(EnemyBotPrototype enemy, int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine("Damage must be positive.");
                return;
            }

            enemy.TakeDamage(damage);

            Console.WriteLine($"Enemy after attack: {enemy.Show()}");

            if (enemy.IsClonable())
            {
                enemy.HasCloned = true;

                EnemyBotPrototype clone = enemy.Clone();

                _enemies.Add(clone);

                Console.WriteLine($"Enemy cloned: {clone.Show()}");
            }
        }

        public void ShowEnemies()
        {
            Console.WriteLine("\nAll enemies:");

            foreach (EnemyBotPrototype enemy in _enemies)
            {
                Console.WriteLine(enemy.Show()); 
            }

            Console.WriteLine();
        }
    }
}


