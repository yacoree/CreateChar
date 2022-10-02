using CreateChar;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
        List<Item> items;
        Unit currentUnit;

        public Window1()
        {
            currentUnit = UnitMaker.MakeTestUnit("Rogue");
            InitializeComponent();
            panelUnitClassSelection.Children.Clear();
            foreach (var i in UnitMaker.UnitClassCode)
            {
                var radioButton = new RadioButton { Name = $"{i.Key}_RBtn", Content = $"{i.Key}" };
                radioButton.Checked += ClassChange_Checked;
                panelUnitClassSelection.Children.Add(radioButton);
            }
            (panelUnitClassSelection.Children[0] as RadioButton).IsChecked = true;

            
            ChangeClass(currentUnit.GetType().Name);
            ChangeUnitUpdate();
            ItemStoreUpdate();
        }

        private void ChangeValueButton_Click(object sender, RoutedEventArgs e)
        {
            int val = (sender as Button).Name.Split('_')[2] == "Down" ? -1 : 1;
            switch ((sender as Button).Name.Split('_')[0])
            {
                case "Strength": Strength_Text.Text = $"{val + int.Parse(Strength_Text.Text)}"; break;
                case "Intelligence": Intelligence_Text.Text = $"{val + int.Parse(Intelligence_Text.Text)}"; break;
                case "Constitution": Constitution_Text.Text = $"{val + int.Parse(Constitution_Text.Text)}"; break;
                case "Dexterity": Dexterity_Text.Text = $"{val + int.Parse(Dexterity_Text.Text)}"; break;
            }
        }

        private void ChangeValueAttribute_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "0") return;
            int value;
            switch (textBox.Name.Split("_")[0])
            {
                case "Strength":
                    if (currentUnit.SkillPoints > 0)
                    {
                        if (StrengthCharacteristic.Minimum.ToString() == textBox.Text &&
                            currentUnit.Strength == StrengthCharacteristic.Minimum) return;
                        value = int.Parse(textBox.Text) - currentUnit.Strength;
                        if (currentUnit.Strength + value >= StrengthCharacteristic.Minimum
                            && currentUnit.Strength + value <= StrengthCharacteristic.Maximum)
                        {
                            currentUnit.Strength += value;
                            currentUnit.SkillPoints -= value;
                            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
                            return;
                        }
                    }
                    textBox.Text = currentUnit.Strength + "";
                    break;
                case "Intelligence":
                    if (currentUnit.SkillPoints > 0)
                    {
                        if (IntelligenceCharacteristic.Minimum.ToString() == textBox.Text &&
                            currentUnit.Intelligence == IntelligenceCharacteristic.Minimum) return;
                        value = int.Parse(textBox.Text) - currentUnit.Intelligence;
                        if (currentUnit.Intelligence + value >= IntelligenceCharacteristic.Minimum
                            && currentUnit.Intelligence + value <= IntelligenceCharacteristic.Maximum)
                        {
                            currentUnit.Intelligence += value;
                            currentUnit.SkillPoints -= value;
                            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
                            return;
                        }
                    }
                    textBox.Text = currentUnit.Intelligence + "";
                    break;
                case "Constitution":
                    if (currentUnit.SkillPoints > 0)
                    {
                        if (ConstitutionCharacteristic.Minimum.ToString() == textBox.Text &&
                            currentUnit.Constitution == ConstitutionCharacteristic.Minimum) return;
                        value = int.Parse(textBox.Text) - currentUnit.Constitution;
                        if (currentUnit.Constitution + value >= ConstitutionCharacteristic.Minimum
                            && currentUnit.Constitution + value <= ConstitutionCharacteristic.Maximum)
                        {
                            currentUnit.Constitution += value;
                            currentUnit.SkillPoints -= value;
                            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
                            return;
                        }
                    }
                    textBox.Text = currentUnit.Constitution + "";
                    break;
                case "Dexterity":
                    if (currentUnit.SkillPoints > 0)
                    {
                        if (DexterityCharacteristic.Minimum.ToString() == textBox.Text &&
                            currentUnit.Dexterity == DexterityCharacteristic.Minimum) return;
                        value = int.Parse(textBox.Text) - currentUnit.Dexterity;
                        if (currentUnit.Dexterity + value >= DexterityCharacteristic.Minimum
                            && currentUnit.Dexterity + value <= DexterityCharacteristic.Maximum)
                        {
                            currentUnit.Dexterity += value;
                            currentUnit.SkillPoints -= value;
                            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
                            return;
                        }
                    }
                    textBox.Text = currentUnit.Dexterity + "";
                    break;
            }
            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
        }

        private void ChangeClass(string currentClass)
        {
            Field[] characteristics = UnitMaker.GetCharacteristics(currentClass);
            StrengthCharacteristic = characteristics[0];
            IntelligenceCharacteristic = characteristics[1];
            ConstitutionCharacteristic = characteristics[2];
            DexterityCharacteristic = characteristics[3];
            RemainingPoints.Text = currentUnit.SkillPoints.ToString();

            Strength_Text.Text = currentUnit.Strength + "";
            Intelligence_Text.Text = currentUnit.Intelligence + "";
            Constitution_Text.Text = currentUnit.Constitution + "";
            Dexterity_Text.Text = currentUnit.Dexterity + "";
        }

        private void ClassChange_Checked(object sender, RoutedEventArgs e)
        {
            currentUnit = UnitMaker.MakeTestUnit($"{(sender as RadioButton).Content}");
            ExperienceProgressBar.Value = currentUnit.CurrentExperience;
            ChangeClass($"{(sender as RadioButton).Content}");
        }

        private void ChangeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentUnit = MongoExample.FindUnit($"{ChangeUnit.SelectedValue}");
            ChangeClass(currentUnit.GetType().Name);
            UnitsWornItemsUpdate();

            InsertName.Text = currentUnit.Name;
            foreach (var i in panelUnitClassSelection.Children)
            {
                if ($"{(i as RadioButton).Content}" == currentUnit.GetType().Name)
                {
                    (i as RadioButton).IsChecked = true;
                    break;
                }
            }
            Strength_Text.Text = currentUnit.Strength.ToString();
            Intelligence_Text.Text = currentUnit.Intelligence.ToString();
            Constitution_Text.Text = currentUnit.Dexterity.ToString();
            Dexterity_Text.Text = currentUnit.Constitution.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertName.Text != "")
            {
                currentUnit.Name = InsertName.Text;
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
                if (MongoExample.FindUnit(currentUnit.Name) == null)
                {
                    MongoExample.AddUnitTodataBase(currentUnit);
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
                ChangeUnitUpdate();
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((sender as ProgressBar).Value == (sender as ProgressBar).Maximum)
            {
                if ((currentUnit.Level + 1) % 3 == 0)
                {
                    currentUnit.CurrentExperience = (int)(sender as ProgressBar).Value;
                    (sender as ProgressBar).Maximum = currentUnit.PointsToNextLevel;
                    UnitLevel.Text = $"{currentUnit.Level} lvl. {currentUnit.CurrentExperience}/{currentUnit.PointsToNextLevel}";
                    RemainingPoints.Text = currentUnit.SkillPoints.ToString();
                    ChooseSkill chooseSkill = new ChooseSkill();
                    if (chooseSkill.ShowDialog() == true)
                    {
                    }
                    return;
                }
            }
            currentUnit.CurrentExperience = (int)(sender as ProgressBar).Value;
            (sender as ProgressBar).Maximum = currentUnit.PointsToNextLevel;
            UnitLevel.Text = $"{currentUnit.Level} lvl. {currentUnit.CurrentExperience}/{currentUnit.PointsToNextLevel}";
            RemainingPoints.Text = currentUnit.SkillPoints.ToString();

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
                if (MongoExample.Finditem(createItemWindow.Item.ItemName) == null)
                {
                    MongoExample.AddItemTodataBase(createItemWindow.Item);
                }
                else
                {
                    if (MessageBox.Show("You want overwrite this item?",
                    "Overwrite item",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MongoExample.ReplaceItem(createItemWindow.Item.ItemName, createItemWindow.Item);
                    }
                }
                ItemStoreUpdate();
            }
            foreach (var i in ItemStore.Items)
            {
                MessageBox.Show(i.GetType().Name);
            }
        }

        private void ItemStoreUpdate()
        {
            var items = MongoExample.FindAllItems();
            ItemStore.Items.Clear();
            foreach (var i in items)
            {
                ItemStore.Items.Add(i);
            }
        }

        private void UnitsWornItemsUpdate()
        {
            UnitsWornItems.Items.Clear();
            if (currentUnit.WornItems != null)
            {
                foreach (var i in currentUnit.WornItems)
                {
                    UnitsWornItems.Items.Add(new { Item = i, Count = 1 });
                }
            }
        }

        private void UnitsInventoryUpdate()
        {
            UnitsInventory.Items.Clear();
            if (currentUnit.Inventory != null)
            {
                foreach (var i in currentUnit.Inventory)
                {
                    UnitsInventory.Items.Add(i);
                }
            }
        }

        private void ChangeUnitUpdate()
        {
            var users = MongoExample.FindAllUnits();
            ChangeUnit.Items.Clear();
            foreach (var i in users)
            {
                ChangeUnit.Items.Add(i.Name);
            }
        }

        private void ItemStore_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as Item);
            if (item != null) currentUnit.AddItemToInventory(item);
            UnitsInventoryUpdate();
        }

        private void UnitsInventory_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem);
            if (item is CountOfItem)
            {
                currentUnit.PutOnItem(((CountOfItem)item).Item);
            }
            UnitsWornItemsUpdate();
            UnitsInventoryUpdate();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var item = UnitsInventory.SelectedItem;
            if (item is CountOfItem)
            {
                if ((bool)(sender as CheckBox).IsChecked)
                {
                    currentUnit.PutOnItem(((CountOfItem)item).Item);
                }
                else
                {
                    currentUnit.RemoveItem(((CountOfItem)item).Item);
                }
            }
            UnitsWornItemsUpdate();
        }

        private void UnitsInventory_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem);
            if (item is CountOfItem)
            {
                currentUnit.LayOutItemFromInventory(((CountOfItem)item).Item);
            }
            UnitsWornItemsUpdate();
            UnitsInventoryUpdate();
        }
    }
}

