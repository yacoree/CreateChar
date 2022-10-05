using CreateChar;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
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
            //foreach (var i in panelUnitClassSelection.Children)
            //{
            //    if (((RadioButton) i).Content == currentUnit.GetType().Name)
            //    {
            //        ((RadioButton) i).IsChecked = true;
            //    }
            //}
            TextCharacteristicUpdate();
            ChangeUnitUpdate();
            ItemStoreUpdate();
        }

        private void ChangeValueButton_Click(object sender, RoutedEventArgs e)
        {
            int val = (sender as Button).Name.Split('_')[2] == "Down" ? -1 : 1;
            currentUnit.SetField((sender as Button).Name.Split('_')[0], val);
            TextCharacteristicUpdate();
        }

        private void ChangeValueAttribute_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "0") return;
            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
        }

        private void ClassChange_Checked(object sender, RoutedEventArgs e)
        {
            currentUnit = UnitMaker.MakeTestUnit((sender as RadioButton).Content.ToString());
            ExperienceProgressBar.Value = currentUnit.CurrentExperience;
            FullUpdateWindow();
        }

        private void ChangeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentUnit = MongoExample.FindUnit($"{ChangeUnit.SelectedValue}");
            FullUpdateWindow();
            InsertName.Text = currentUnit.Name;
            foreach (var i in panelUnitClassSelection.Children)
            {
                if ($"{(i as RadioButton).Content}" == currentUnit.GetType().Name)
                {
                    (i as RadioButton).IsChecked = true;
                    break;
                }
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertName.Text != "")
            {
                currentUnit.Name = InsertName.Text;
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
                        currentUnit.AddSkill(chooseSkill.chooseSkill);
                        RemainingPoints.Text = currentUnit.SkillPoints.ToString();
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

        private void TextCharacteristicUpdate()
        {
            Strength_Text.Text = currentUnit.Strength.ToString();
            Intelligence_Text.Text = currentUnit.Intelligence.ToString();
            Constitution_Text.Text = currentUnit.Constitution.ToString();
            Dexterity_Text.Text = currentUnit.Dexterity.ToString();
            RemainingPoints.Text = currentUnit.SkillPoints.ToString();
        }

        private void FullUpdateWindow()
        {
            UnitsWornItemsUpdate();
            UnitsWornItemsUpdate();
            ChangeUnitUpdate();
            TextCharacteristicUpdate();
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
            if (item is KeyValuePair<Item, int>)
            {
                currentUnit.PutOnItem(((KeyValuePair<Item, int>) item).Key);
            }
            UnitsWornItemsUpdate();
            UnitsInventoryUpdate();
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

