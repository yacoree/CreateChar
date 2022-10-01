using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
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
    }
}
