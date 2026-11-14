using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
    public sealed class JuiceProductFactoryA : JuiceProductFactory
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
}
