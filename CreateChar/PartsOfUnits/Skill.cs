using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar.PartsOfUnits
{
    public class Skill
    {
        public string SkillName { get; set; }
        [BsonIgnoreIfNull]
        public UnitProperty SkillProperty { get; set; }
        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intelligence { get; set; }
        [BsonIgnoreIfDefault]
        public int LoadCapacity { get; set; }
        [BsonIgnoreIfDefault]
        public int SkillPoints { get; set; }

        public Skill(string skillName)
        {
            SkillName = skillName;
        }

        public override string ToString()
        {
            string res = $"{SkillName}: \n";
            if (SkillProperty != null) res += $"{SkillProperty}";
            if (Strength != 0) res += $"Strenght - {Strength}\n";
            if (Dexterity != 0) res += $"Dexterity - {Dexterity}\n";
            if (Constitution != 0) res += $"Constitution - {Constitution}\n";
            if (Intelligence != 0) res += $"Intelligence - {Intelligence} \n";
            if (LoadCapacity != 0) res += $"LoadCapacity - {LoadCapacity} \n";
            if (SkillPoints != 0) res += $"SkillPoints - {SkillPoints} \n";
            return res;
        }
    }
}
