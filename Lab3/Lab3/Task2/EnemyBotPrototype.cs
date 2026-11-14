using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Task2
{
    public abstract class EnemyBotPrototype
    {
        protected static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public int HealthLevel { get; set; }
        public bool HasCloned { get; set; }
        public int Limit { get; protected set; }
        public List<string> Abilities { get; set; }

        protected EnemyBotPrototype(string name)
        {
            Name = name;
            HasCloned = false;
            SetNewId();
        }

        protected void SetNewId()
        {
            Id = _nextId;
            _nextId++;
        }

        public bool IsClonable()
        {
            return HealthLevel > 0 && HealthLevel <= Limit && !HasCloned;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || HealthLevel <= 0)
                return;

            HealthLevel -= damage;

            if (HealthLevel < 0)
                HealthLevel = 0;
        }

        public string Show()
        {
            return $"ID: {Id} | Name: {Name} | HP: {HealthLevel} | Abilities: {string.Join(", ", Abilities)}";
        }

        public abstract EnemyBotPrototype Clone();
    }
}
