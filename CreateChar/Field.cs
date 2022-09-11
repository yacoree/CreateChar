using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Field
    {
        int minimum;
        int maximum;

        int physicalProtection;
        int healthPoint;
        int manaPool;
        int physicalAttack;
        int magicalAttack;

        public Field(int minimum, int maximum, int physicalProtection, int healthPoint, 
            int manaPool, int physicalAttack, int magicalAttack)
        {
            this.minimum = minimum;
            this.maximum = maximum;
            this.physicalProtection = physicalProtection;
            this.healthPoint = healthPoint;
            this.manaPool = manaPool;
            this.physicalAttack = physicalAttack;
            this.magicalAttack = magicalAttack;
        }

        public int Minimum { get => minimum; }
        public int Maximum { get => maximum; }
        public int PhysicalProtection { get => physicalProtection; }
        public int HealthPoint { get => healthPoint; }
        public int ManaPool { get => manaPool; }
        public int PhysicalAttack { get => physicalAttack; }
        public int MagicalAttack { get => magicalAttack; }

        public UnitProperty AddPoint(int points)
        {
            UnitProperty returned = new UnitProperty();
            returned.HealthPoint = this.HealthPoint * points;
            returned.PhysicalProtection = this.PhysicalProtection * points;
            returned.ManaPool = this.ManaPool * points;
            returned.PhysicalAttack = this.PhysicalAttack * points;
            returned.MagicalAttack = this.MagicalAttack * points;
            return returned;
        }
    }
}
