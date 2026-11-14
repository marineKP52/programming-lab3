using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task2
{
    public class Game
    {
        private EnemyBotManager _manager;
        private List<EnemyBotPrototype> _enemies;
        public IReadOnlyList<EnemyBotPrototype> Enemies => _enemies;

        public Game()
        {
            _manager = new EnemyBotManager();
            _enemies = new List<EnemyBotPrototype>();

            _enemies.Add(_manager.GetBotClone("Regular"));
            _enemies.Add(_manager.GetBotClone("Strong"));
        }

        public void Attack(EnemyBotPrototype enemy, int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine("Damage must be positive.");
                return;
            }

            enemy.TakeDamage(damage);

            Console.WriteLine($"Enemy after attack: {enemy.Show()}");

            if (enemy.IsClonable())
            {
                enemy.HasCloned = true;

                EnemyBotPrototype clone = enemy.Clone();

                _enemies.Add(clone);

                Console.WriteLine($"Enemy cloned: {clone.Show()}");
            }
        }

        public void ShowEnemies()
        {
            foreach (EnemyBotPrototype enemy in _enemies)
            {
                Console.WriteLine(enemy.Show());
            }

            Console.WriteLine();
        }
    }
}
