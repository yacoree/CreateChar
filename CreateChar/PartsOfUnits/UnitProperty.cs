using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar.PartsOfUnits
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

        public UnitProperty()
        {
            physicalProtection = 0;
            healthPoint = 0;
            manaPool = 0;
            physicalAttack = 0;
            magicalAttack = 0;
        }

        public int PhysicalProtection { get => physicalProtection; set => physicalProtection = value; }
        public int HealthPoint { get => healthPoint; set => healthPoint = value; }
        public int ManaPool { get => manaPool; set => manaPool = value; }
        public int PhysicalAttack { get => physicalAttack; set => physicalAttack = value; }
        public int MagicalAttack { get => magicalAttack; set => magicalAttack = value; }

        public UnitProperty Increase(UnitProperty unitProperty)
        {
            UnitProperty returned = new UnitProperty();
            returned.HealthPoint = HealthPoint + unitProperty.HealthPoint;
            returned.PhysicalProtection = PhysicalProtection + unitProperty.PhysicalProtection;
            returned.ManaPool = ManaPool + unitProperty.ManaPool;
            returned.PhysicalAttack = PhysicalAttack + unitProperty.PhysicalAttack;
            returned.MagicalAttack = MagicalAttack + unitProperty.MagicalAttack;
            return returned;
        }


        public static UnitProperty operator +(UnitProperty leftP, UnitProperty rightP)
        {
            return leftP.Increase(rightP);
        }

        public UnitProperty Subtraction(UnitProperty unitProperty)
        {
            UnitProperty returned = new UnitProperty();
            returned.HealthPoint = HealthPoint - unitProperty.HealthPoint;
            returned.PhysicalProtection = PhysicalProtection - unitProperty.PhysicalProtection;
            returned.ManaPool = ManaPool - unitProperty.ManaPool;
            returned.PhysicalAttack = PhysicalAttack - unitProperty.PhysicalAttack;
            returned.MagicalAttack = MagicalAttack - unitProperty.MagicalAttack;
            return returned;
        }

        public static UnitProperty operator -(UnitProperty leftP, UnitProperty rightP)
        {
            return leftP != null ? leftP.Subtraction(rightP) : new UnitProperty();
        }

        public UnitProperty Multiply(int num)
        {
            UnitProperty returned = new UnitProperty();
            returned.HealthPoint = HealthPoint * num;
            returned.PhysicalProtection = PhysicalProtection * num;
            returned.ManaPool = ManaPool * num;
            returned.PhysicalAttack = PhysicalAttack * num;
            returned.MagicalAttack = MagicalAttack * num;
            return returned;
        }

        public static UnitProperty operator *(UnitProperty leftP, int rightI)
        {
            return leftP.Multiply(rightI);
        }

        public static UnitProperty operator *(int leftI, UnitProperty rightP)
        {
            return rightP.Multiply(leftI);
        }

        public override string ToString()
        {
            var res = $"Health point - {healthPoint / 10.0}\n" +
                $"Mana pool - {manaPool / 10.0}\n" +
                $"Physical protection - {PhysicalProtection / 10.0}\n" +
                $"Physical attack - {PhysicalAttack / 10.0}\n" +
                $"Magical attack - {magicalAttack / 10.0}\n";
            return res;
        }
    }
}
