using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab3.Task2
{
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

            return bot;
        }
    }
}
