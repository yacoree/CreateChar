using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class UnitProperty
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

        public UnitProperty() { }

        public int PhysicalProtection { get => physicalProtection; set => physicalProtection = value; }
        public int HealthPoint { get => healthPoint; set => healthPoint = value; }
        public int ManaPool { get => manaPool; set => manaPool = value; }
        public int PhysicalAttack { get => physicalAttack; set => physicalAttack = value; }
        public int MagicalAttack { get => magicalAttack; set => magicalAttack = value; }

        public UnitProperty Increase(UnitProperty unitProperty)
        {
            UnitProperty returned = new UnitProperty();
            returned.HealthPoint = this.HealthPoint + unitProperty.HealthPoint;
            returned.PhysicalProtection = this.PhysicalProtection + unitProperty.PhysicalProtection;
            returned.ManaPool = this.ManaPool + unitProperty.ManaPool;
            returned.PhysicalAttack = this.PhysicalAttack + unitProperty.PhysicalAttack;
            returned.MagicalAttack = this.MagicalAttack + unitProperty.MagicalAttack;
            return returned;
        }

        public static UnitProperty operator +(UnitProperty leftP, UnitProperty rightP)
        {
            return leftP.Increase(rightP);
        }

        public override string ToString()
        {
            var res = $"Health point - {1.0 * healthPoint / 10}\n" +
                $"Mana pool - {1.0 * manaPool / 10}\n" +
                $"Physical protection - {1.0 * PhysicalProtection / 10}\n" +
                $"Physical attack - {1.0 * PhysicalAttack / 10}\n" +
                $"Magical attack - {1.0 * magicalAttack / 10}\n";
            return res;
        }
    }
}
