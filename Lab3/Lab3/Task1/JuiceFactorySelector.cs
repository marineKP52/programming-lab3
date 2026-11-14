using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task1
{
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
}
