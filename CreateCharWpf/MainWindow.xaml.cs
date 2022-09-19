using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CreateChar;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateCharWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentClass = "Rogue";
        Field StrengthCharacteristic;
        Field DexterityCharacteristic;
        Field ConstitutionCharacteristic;
        Field IntelligenceCharacteristic;

        public MainWindow()
        {
            InitializeComponent();
            SliderStrength.Maximum = Rogue.StrengthCharacteristic.Maximum;
            SliderStrength.Minimum = Rogue.StrengthCharacteristic.Minimum;

            SliderIntellingence.Maximum = Rogue.IntelligenceCharacteristic.Maximum;
            SliderIntellingence.Minimum = Rogue.IntelligenceCharacteristic.Minimum;

            SliderConstitution.Maximum = Rogue.ConstitutionCharacteristic.Maximum;
            SliderConstitution.Minimum = Rogue.ConstitutionCharacteristic.Minimum;

            SliderDexterity.Maximum = Rogue.DexterityCharacteristic.Maximum;
            SliderDexterity.Minimum = Rogue.DexterityCharacteristic.Minimum;

            TextStrength.Text = SliderStrength.Value + "";
            TextIntellingence.Text = SliderIntellingence.Value + "";
            TextConstitution.Text = SliderConstitution.Value + "";
            TextDexterity.Text = SliderDexterity.Value + "";

            ShowFinalStats();
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            currentClass  = (sender as RadioButton).Content + "";
            switch (currentClass)
            {
                case "Rogue":
                    StrengthCharacteristic = Rogue.StrengthCharacteristic;
                    IntelligenceCharacteristic = Rogue.IntelligenceCharacteristic;
                    ConstitutionCharacteristic = Rogue.ConstitutionCharacteristic;
                    DexterityCharacteristic = Rogue.DexterityCharacteristic;
                    break;
                case "Warrior":
                    StrengthCharacteristic = Warrior.StrengthCharacteristic;
                    IntelligenceCharacteristic = Warrior.IntelligenceCharacteristic;
                    ConstitutionCharacteristic = Warrior.ConstitutionCharacteristic;
                    DexterityCharacteristic = Warrior.DexterityCharacteristic;
                    break;
                case "Wizard":
                    StrengthCharacteristic = Wizard.StrengthCharacteristic;
                    IntelligenceCharacteristic = Wizard.IntelligenceCharacteristic;
                    ConstitutionCharacteristic = Wizard.ConstitutionCharacteristic;
                    DexterityCharacteristic = Wizard.DexterityCharacteristic;
                    break;
            }
            SliderStrength.Maximum = StrengthCharacteristic.Maximum;
            SliderStrength.Minimum = StrengthCharacteristic.Minimum;

            SliderIntellingence.Maximum = IntelligenceCharacteristic.Maximum;
            SliderIntellingence.Minimum = IntelligenceCharacteristic.Minimum;

            SliderConstitution.Maximum = ConstitutionCharacteristic.Maximum;
            SliderConstitution.Minimum = ConstitutionCharacteristic.Minimum;

            SliderDexterity.Maximum = DexterityCharacteristic.Maximum;
            SliderDexterity.Minimum = DexterityCharacteristic.Minimum;
        }

        private void SliderStrength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextStrength.Text = (int) SliderStrength.Value + "";
            TextIntellingence.Text = (int) SliderIntellingence.Value + "";
            TextConstitution.Text = (int) SliderConstitution.Value + "";
            TextDexterity.Text = (int) SliderDexterity.Value + "";
            ShowFinalStats();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Unit newUnit;
            if (InsertName.Text == "")
            {
                switch (currentClass)
                {
                    case "Rogue":
                        newUnit = new Rogue(InsertName.Text, 
                            (int) SliderStrength.Value, 
                            (int) SliderDexterity.Value, 
                            (int) SliderConstitution.Value, 
                            (int) SliderIntellingence.Value);
                        break;
                    case "Warrior":
                        newUnit = new Warrior(InsertName.Text,
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                        break;
                    case "Wizard":
                        newUnit = new Wizard(InsertName.Text,
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                        break;
                    default:
                        newUnit = new Rogue(InsertName.Text,
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                        break;
                }
                MessageBox.Show(newUnit.Max.ToString());

                
            }
            
        }

        private void ShowFinalStats()
        {
            UnitProperty res = new UnitProperty(); ;
            switch (currentClass)
            {
                case "Rogue":
                    res = Rogue.TakeUnitStats(
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                    break;
                case "Warrior":
                    res = Warrior.TakeUnitStats(
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                    break;
                case "Wizard":
                    res = Wizard.TakeUnitStats(
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
                    break;
            }
            FinalStatsText.Text = res.ToString();
        }
    }
}
