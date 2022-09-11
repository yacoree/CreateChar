using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class UnitProperty
    {
        int physicalProtection;
        int healthPoint;
        int manaPool;
        int physicalAttack;
        int magicalAttack;

        public UnitProperty(int physicalProtection, int HP, int MP, int physicalAttack, int magicalAttack)
        {
            PhysicalProtection = physicalProtection;
            HealthPoint = HP;
            ManaPool = MP;
            PhysicalAttack = physicalAttack;
            MagicalAttack = magicalAttack;
        }

        public int PhysicalProtection { get => physicalProtection; set => physicalProtection = value; }
        public int HealthPoint { get => healthPoint; set => healthPoint = value; }
        public int ManaPool { get => manaPool; set => manaPool = value; }
        public int PhysicalAttack { get => physicalAttack; set => physicalAttack = value; }
        public int MagicalAttack { get => magicalAttack; set => magicalAttack = value; }
    }
}
