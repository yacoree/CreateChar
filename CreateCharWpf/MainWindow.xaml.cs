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
using MongoDB.Driver;
using MongoDB;
using System.Collections;
using System.Xml.Linq;

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
        List<Unit> users;

        public MainWindow()
        {
            InitializeComponent();
            ChangeClass(currentClass);

            TextStrength.Text = SliderStrength.Value + "";
            TextIntellingence.Text = SliderIntellingence.Value + "";
            TextConstitution.Text = SliderConstitution.Value + "";
            TextDexterity.Text = SliderDexterity.Value + "";

            ShowFinalStats();
            ComboBoxUpdate();
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            currentClass  = (sender as RadioButton).Content + "";
            ChangeClass(currentClass);
        }

        private void ChangeClass(string currentClass)
        {
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
            if (InsertName.Text != "")
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
                //MessageBox.Show(newUnit.GetType().ToString());
                MongoExample.AddToDB(newUnit);
                ComboBoxUpdate();
                //ChangeUnit.Items.Add(newUnit);
            }
            
        }

        private void ShowFinalStats()
        {
            UnitProperty res = new UnitProperty();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string DBName = "UnitsBase";
            string collectionName = "Units";
            var client = new MongoClient();
            var database = client.GetDatabase(DBName);
            var collection = database.GetCollection<Unit>(collectionName);
            var query = collection.AsQueryable<Unit>().OfType<Rogue>();
            MessageBox.Show(query.ToString());
            ComboBoxUpdate();
        }

        private void ComboBoxUpdate()
        {
            users = MongoExample.FindAll();
            ChangeUnit.Items.Clear();
            foreach (var i in users)
            {
                ChangeUnit.Items.Add(i.Name);
            }
        }

        private void ChangeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var i in users)
            {
                if (i.Name == ChangeUnit.SelectedValue + "")
                {
                    ChangeClass(i.GetType().Name);
                    InsertName.Text = i.Name;

                    switch (i.GetType().Name)
                    {
                        case "Rogue":
                            RogueBtn.IsChecked = true;
                            break;
                        case "Warrior":
                            WarriorBtn.IsChecked = true;   
                            break ;
                        case "Wizard":
                            WizardBtn.IsChecked = true;
                            break;
                    }
                    //(i.GetType().Name).IsChecked
                    SliderStrength.Value = i.Strength;
                    SliderIntellingence.Value = i.Intelligence;
                    SliderDexterity.Value = i.Dexterity;
                    SliderConstitution.Value = i.Constitution;
                }
            }
        }
    }
}
