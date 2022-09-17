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

namespace CreateCharWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SliderStrength.Maximum = Rogue.strengthCharacteristic.Maximum;
            SliderStrength.Minimum = Rogue.strengthCharacteristic.Minimum;

            SliderIntellingence.Maximum = Rogue.intelligenceCharacteristic.Maximum;
            SliderIntellingence.Minimum = Rogue.intelligenceCharacteristic.Minimum;

            SliderConstitution.Maximum = Rogue.constitutionCharacteristic.Maximum;
            SliderConstitution.Minimum = Rogue.constitutionCharacteristic.Minimum;

            SliderDexterity.Maximum = Rogue.dexterityCharacteristic.Maximum;
            SliderDexterity.Minimum = Rogue.dexterityCharacteristic.Minimum;

            TextStrength.Text = SliderStrength.Value + "";
            TextIntellingence.Text = SliderIntellingence.Value + "";
            TextConstitution.Text = SliderConstitution.Value + "";
            TextDexterity.Text = SliderDexterity.Value + "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string currentClass = (sender as RadioButton).Content + "";
            switch (currentClass)
            {
                case "Rogue":
                    SliderStrength.Maximum = Rogue.strengthCharacteristic.Maximum;
                    SliderStrength.Minimum = Rogue.strengthCharacteristic.Minimum;

                    SliderIntellingence.Maximum = Rogue.intelligenceCharacteristic.Maximum;
                    SliderIntellingence.Minimum = Rogue.intelligenceCharacteristic.Minimum;

                    SliderConstitution.Maximum = Rogue.constitutionCharacteristic.Maximum;
                    SliderConstitution.Minimum = Rogue.constitutionCharacteristic.Minimum;

                    SliderDexterity.Maximum = Rogue.dexterityCharacteristic.Maximum;
                    SliderDexterity.Minimum = Rogue.dexterityCharacteristic.Minimum;
                    break;
                case "Warrior":
                    SliderStrength.Maximum = Warrior.strengthCharacteristic.Maximum;
                    SliderStrength.Minimum = Warrior.strengthCharacteristic.Minimum;

                    SliderIntellingence.Maximum = Warrior.intelligenceCharacteristic.Maximum;
                    SliderIntellingence.Minimum = Warrior.intelligenceCharacteristic.Minimum;

                    SliderConstitution.Maximum = Warrior.constitutionCharacteristic.Maximum;
                    SliderConstitution.Minimum = Warrior.constitutionCharacteristic.Minimum;

                    SliderDexterity.Maximum = Warrior.dexterityCharacteristic.Maximum;
                    SliderDexterity.Minimum = Warrior.dexterityCharacteristic.Minimum;
                    break;
                case "Wizard":
                    SliderStrength.Maximum = Warrior.strengthCharacteristic.Maximum;
                    SliderStrength.Minimum = Warrior.strengthCharacteristic.Minimum;

                    SliderIntellingence.Maximum = Warrior.intelligenceCharacteristic.Maximum;
                    SliderIntellingence.Minimum = Warrior.intelligenceCharacteristic.Minimum;

                    SliderConstitution.Maximum = Warrior.constitutionCharacteristic.Maximum;
                    SliderConstitution.Minimum = Warrior.constitutionCharacteristic.Minimum;

                    SliderDexterity.Maximum = Warrior.dexterityCharacteristic.Maximum;
                    SliderDexterity.Minimum = Warrior.dexterityCharacteristic.Minimum;
                    break;
            }
        }

        private void SliderStrength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextStrength.Text = (int) SliderStrength.Value + "";
            TextIntellingence.Text = (int)SliderIntellingence.Value + "";
            TextConstitution.Text = (int)SliderConstitution.Value + "";
            TextDexterity.Text = (int)SliderDexterity.Value + "";
        }
    }
}
