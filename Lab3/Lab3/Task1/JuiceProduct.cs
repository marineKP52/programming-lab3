using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
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
}
