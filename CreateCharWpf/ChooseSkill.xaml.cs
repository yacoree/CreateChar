using CreateChar;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CreateCharWpf
{
    /// <summary>
    /// Логика взаимодействия для ChooseSkil.xaml
    /// </summary>
    public partial class ChooseSkill : Window
    {
        List<Skill> skills;
        Skill chooseSkill;
        public ChooseSkill()
        {
            InitializeComponent();
            skills = new List<Skill>();
            var skill = new Skill("Vilgefortz");
            skill.SkillProperty = new UnitProperty();
            skill.SkillProperty.ManaPool = 50;
            skill.SkillProperty.MagicalAttack = 20;
            skills.Add(skill);

            skill = new Skill("Whirrun of Bligh");
            skill.SkillProperty = new UnitProperty();
            skill.SkillProperty.PhysicalAttack = 20;
            skill.SkillProperty.HealthPoint = 20;
            skill.SkillProperty.PhysicalProtection = 20;
            skills.Add(skill);

            skill = new Skill("Legeng");
            skill.Strength = 5;
            skill.Dexterity = 5;
            skill.Constitution = 5;
            skill.Intelligence = 5;
            skills.Add(skill);

            skill = new Skill("No longer a man");
            skill.SkillPoints = 10;
            skills.Add(skill);

            Skill1_0.Content = skills[0];
            Skill1_1.Content = skills[1];
            Skill1_2.Content = skills[2];
            Skill1_3.Content = skills[3];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chooseSkill = skills[Convert.ToInt32($"{(sender as Button).Name}".Split("_")[1])];
            this.DialogResult = true;
        }
    }
}
