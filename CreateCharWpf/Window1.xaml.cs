using CreateChar;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace CreateCharWpf
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Field StrengthCharacteristic;
        Field DexterityCharacteristic;
        Field ConstitutionCharacteristic;
        Field IntelligenceCharacteristic;
        int MarginTopItem = 10;
        List<Item> items;
        Unit currentUnit;
        int currentPoints;

        public Window1()
        {
            InitializeComponent();
            panelUnitClassSelection.Children.Clear();
            foreach (var i in UnitMaker.UnitClassCode)
            {
                var radioButton = new RadioButton { Name = $"{i.Key}_RBtn", Content = $"{i.Key}" };
                radioButton.Checked += ClassChange_Checked;
                panelUnitClassSelection.Children.Add(radioButton);
            }
            (panelUnitClassSelection.Children[0] as RadioButton).IsChecked = true;
            var users = MongoExample.FindAll();
            ChangeUnit.Items.Clear();
            foreach (var i in users)
            {
                ChangeUnit.Items.Add(i.Name);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue != (sender as Slider).Minimum)
            {
                if (currentPoints != 0)
                {
                    var incresevalue = (int)e.OldValue - ((int)e.NewValue);
                    if (incresevalue < 0 && (currentPoints + incresevalue) < 0)
                    {
                        (sender as Slider).Value = e.OldValue;
                        return;
                    }
                    if (incresevalue > 0)
                    {
                        currentPoints += incresevalue;
                        return;
                    }
                    currentPoints += incresevalue;
                    /*
                        (sender as Slider).Value -= currentPoints;
                        currentPoints = 0;
                    */
                    if (currentPoints > currentUnit.SkillPoints)
                    {
                        (sender as Slider).Value -= currentPoints;
                        currentPoints = currentUnit.SkillPoints;
                    }
                }
                else
                {

                    return;
                }
            }
            RemainingPoints.Text = currentPoints.ToString();
            TextInfoUpdate();
        }

        private void ChangeValueButton_Click(object sender, RoutedEventArgs e)
        {
            int val = (sender as Button).Name.Split('_')[2] == "Down" ? -1 : 1;
            switch ((sender as Button).Name.Split('_')[0])
            {
                case "Strength": Strength_Slider.Value += val; break;
                case "Intelligence": Intelligence_Slider.Value += val; break;
                case "Constitution": Constitution_Slider.Value += val; break;
                case "Dexterity": Dexterity_Slider.Value += val; break;
            }
        }

        private void ChangeValueAttribute_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ChangeClass(string currentClass)
        {
            Field[] characteristics = UnitMaker.GetCharacteristics(currentClass);
            StrengthCharacteristic = characteristics[0];
            IntelligenceCharacteristic = characteristics[1];
            ConstitutionCharacteristic = characteristics[2];
            DexterityCharacteristic = characteristics[3];

            Strength_Slider.Maximum = StrengthCharacteristic.Maximum;
            Strength_Slider.Minimum = StrengthCharacteristic.Minimum;
            Strength_Slider.SmallChange = 1;
            Strength_Slider.Value = Strength_Slider.Minimum;

            Intelligence_Slider.Maximum = IntelligenceCharacteristic.Maximum;
            Intelligence_Slider.Minimum = IntelligenceCharacteristic.Minimum;
            Intelligence_Slider.SmallChange = 1;
            Intelligence_Slider.Value = Intelligence_Slider.Minimum;

            Constitution_Slider.Maximum = ConstitutionCharacteristic.Maximum;
            Constitution_Slider.Minimum = ConstitutionCharacteristic.Minimum;
            Constitution_Slider.SmallChange = 1;
            Constitution_Slider.Value = Constitution_Slider.Minimum;

            Dexterity_Slider.Maximum = DexterityCharacteristic.Maximum;
            Dexterity_Slider.Minimum = DexterityCharacteristic.Minimum;
            Dexterity_Slider.SmallChange = 1;
            Dexterity_Slider.Value = Dexterity_Slider.Minimum;

            RemainingPoints.Text = currentPoints.ToString();
        }

        private void TextInfoUpdate()
        {
            Strength_Text.Text = (int)Strength_Slider.Value + "";
            Intelligence_Text.Text = (int)Intelligence_Slider.Value + "";
            Constitution_Text.Text = (int)Constitution_Slider.Value + "";
            Dexterity_Text.Text = (int)Dexterity_Slider.Value + "";
        }

        private void ClassChange_Checked(object sender, RoutedEventArgs e)
        {
            currentUnit = UnitMaker.MakeTestUnit($"{(sender as RadioButton).Content}");
            ExperienceProgressBar.Value = currentUnit.CurrentExperience;
            currentPoints = currentUnit.SkillPoints;
            ChangeClass($"{(sender as RadioButton).Content}");
        }

        private void ChangeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unit = MongoExample.Find($"{ChangeUnit.SelectedValue}");
            ChangeClass(unit.GetType().Name);
            Inventory.Items.Clear();
            if (unit.Inventory != null)
            {
                foreach (var i in unit.Inventory)
                {
                    Inventory.Items.Add(new { Item = i.Key, Count = i.Value });
                }
            }
            InsertName.Text = unit.Name;
            foreach (var i in panelUnitClassSelection.Children)
            {
                if ($"{(i as RadioButton).Content}" == unit.GetType().Name)
                {
                    (i as RadioButton).IsChecked = true;
                    break;
                }
            }
            Strength_Slider.Value = unit.Strength;
            Intelligence_Slider.Value = unit.Intelligence;
            Constitution_Slider.Value = unit.Dexterity;
            Dexterity_Slider.Value = unit.Constitution;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertName.Text != "")
            {
                currentUnit.Name = InsertName.Text;
                currentUnit.Constitution = (int) Constitution_Slider.Value;
                currentUnit.Dexterity = (int) Dexterity_Slider.Value;
                currentUnit.Strength = (int) Strength_Slider.Value;
                currentUnit.Intelligence = (int)Intelligence_Slider.Value;
                /*foreach (var i in Inventory.Children)
                {
                    var j = i as CheckBox;
                    foreach (var item in items)
                    {
                        if (j.IsChecked == true)
                        {
                            if ($"{j.Content}" == item.ItemName)
                            {
                                newUnit.AddItemToInventory(item);
                                //newUnit.AddItem(item);
                            }
                        }
                    }
                }*/
                if (MongoExample.Find(currentUnit.Name) == null)
                {
                    MongoExample.AddToDB(currentUnit);
                    var users = MongoExample.FindAll();
                    ChangeUnit.Items.Clear();
                    foreach (var i in users)
                    {
                        ChangeUnit.Items.Add(i.Name);
                    }
                }
                else
                {
                    if (MessageBox.Show("You want overwrite this unit?",
                    "Overwrite unit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MongoExample.ReplaceUnit(currentUnit.Name, currentUnit);
                    }
                }
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentUnit.CurrentExperience = (int) (sender as ProgressBar).Value;
            //(sender as ProgressBar).Value = currentUnit.CurrentExperience;
            (sender as ProgressBar).Maximum = currentUnit.PointsToNextLevel;
            UnitLevel.Text = $"{currentUnit.Level} lvl. {currentUnit.CurrentExperience}/{currentUnit.PointsToNextLevel}";
            RemainingPoints.Text = currentPoints.ToString();

        }

        private void IncreaseExperience_Click(object sender, RoutedEventArgs e)
        {
            ExperienceProgressBar.Value += Convert.ToInt32((sender as Button).Name.Split('_')[1]);
        }

        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            CreateItemWindow createItemWindow = new CreateItemWindow();
            if (createItemWindow.ShowDialog() == true)
            {
                ItemStore.Items.Add(new { ItemName = createItemWindow.Item, Property = createItemWindow.Item.ItemPropery });
            }
        }
    }
}
