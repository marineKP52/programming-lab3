using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
    public sealed class JuiceProductFactoryB : JuiceProductFactory
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
}
