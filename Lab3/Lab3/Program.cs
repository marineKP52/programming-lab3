namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public abstract class JuiceProduct
    {
        public string Name { get; set; }
        public string RawMaterialVariety { get; protected set; }
        public string PackageColor { get; protected set; }
        public decimal Price { get; protected set; }
    }

    public class FruitJuiceProduct : JuiceProduct
    {
        private decimal _priceCoeff = 1.1m;

        public FruitJuiceProduct(string name, string materialVariety, string packageColor, decimal price)
        {
            Name = name;
            RawMaterialVariety = materialVariety;
            PackageColor = packageColor;
            Price = price * _priceCoeff;
        }
    }

    public class BerryJuiceProduct : JuiceProduct
    {
        private decimal _priceCoeff = 1.3m;

        public BerryJuiceProduct(string name, string materialVariety, string packageColor, decimal price)
        {
            Name = name;
            RawMaterialVariety = materialVariety;
            PackageColor = packageColor;
            Price = price * _priceCoeff;
        }
    }

    public abstract class JuiceProductFactory
    {
        public abstract FruitJuiceProduct CreateFruitJuiceProduct(string name);
        public abstract BerryJuiceProduct CreateBerryJuiceProduct(string name);
    }

    public class JuiceProductFactoryA : JuiceProductFactory
    {
        public override FruitJuiceProduct CreateFruitJuiceProduct(string name)
        {
            return new FruitJuiceProduct(name, "Golden", "Green", 80);
        }

        public override BerryJuiceProduct CreateBerryJuiceProduct(string name)
        {
            return new BerryJuiceProduct(name, "777", "Red", 100);
        }
    }

    public class JuiceProductFactoryB : JuiceProductFactory
    {
        public override FruitJuiceProduct CreateFruitJuiceProduct(string name)
        {
            return new FruitJuiceProduct(name, "Symyrenko", "Yellow", 90);
        }

        public override BerryJuiceProduct CreateBerryJuiceProduct(string name)
        {
            return new BerryJuiceProduct(name, "888", "Purple", 120);
        }
    }

}
