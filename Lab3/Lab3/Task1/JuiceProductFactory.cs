using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
    public abstract class JuiceProductFactory
    {
        public abstract FruitJuiceProduct CreateFruitJuiceProduct(string name);
        public abstract BerryJuiceProduct CreateBerryJuiceProduct(string name);
    }
}
