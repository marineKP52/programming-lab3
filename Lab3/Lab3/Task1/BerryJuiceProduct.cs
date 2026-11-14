using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
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
}
