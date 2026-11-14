using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task2
{
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

            EnemyBotPrototype bot = _bots[type].Clone();
            bot.HasCloned = false;

            return bot;
        }
    }
}
