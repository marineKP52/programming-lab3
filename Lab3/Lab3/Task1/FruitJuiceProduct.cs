using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
    public class FruitJuiceProduct : JuiceProduct
    {
        private static readonly decimal _priceCoeff = 1.1m;

        public float PulpConcentration { get; }

        public FruitJuiceProduct(string name, string materialVariety, string packageColor,
            decimal price, float pulpConcentration) : base(name, materialVariety, packageColor, price * _priceCoeff)
        {
            PulpConcentration = pulpConcentration;
        }

        public override string ShowProduct()
        {
            return $"Name: {Name} | Raw Material Variety: {RawMaterialVariety} | Pulp Concentration: {PulpConcentration} " +
                $"Package Color: {PackageColor} | PRICE: {Price} UAH";
        }
    }
}
