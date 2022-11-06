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
using CreateChar.Mongo;
using CreateChar.Units;

namespace CommandGeneration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Team1.Items.Clear();
            Team2.Items.Clear();
            int i = 0;
            List<int> indexes = new List<int>();
            List<Unit> unitsList = MongoExample.FindAllUnits();
            Random random = new Random();
            int amount = 5;
            i = 0;
            int num = random.Next(unitsList.Count);
            foreach (var unit in unitsList)
            {
                if (i == num)
                {
                    Team1.Items.Clear();
                    Team1.Items.Add(unitsList[num] as Unit);
                }
                i++;
            }
            indexes.Add(num);
            i = -1;
            bool IsCharacterAdded = false;
            foreach (var Unit in unitsList)
            {
                num = random.Next(unitsList.Count);
                int cycle = 0;
                while (indexes.Contains(num))
                {
                    cycle++;
                    num = random.Next(unitsList.Count);
                    if (cycle > unitsList.Count * 5)
                    {
                        MessageBox.Show($"Cannot create lobby for {(Team1.Items.GetItemAt(0) as Unit).ToString()}");
                    }
                }
                if (unitsList.ElementAt<Unit>(num).Level >= (Team1.Items.GetItemAt(0) as Unit).Level - 5 &&
                    unitsList.ElementAt<Unit>(num).Level <= (Team1.Items.GetItemAt(0) as Unit).Level + 5 &&
                    i % 2 != 0 && Team1.Items.Count < amount)
                {
                    Team1.Items.Add((unitsList.ElementAt<Unit>(num) as Unit));
                    indexes.Add(num);
                    IsCharacterAdded = true;
                }
                if (unitsList.ElementAt<Unit>(num).Level >= (Team1.Items.GetItemAt(0) as Unit).Level - 5 &&
                    unitsList.ElementAt<Unit>(num).Level <= (Team1.Items.GetItemAt(0) as Unit).Level + 5 &&
                    i % 2 == 0 && Team2.Items.Count < amount)
                {
                    Team2.Items.Add((unitsList.ElementAt<Unit>(num) as Unit));
                    indexes.Add(num);
                    IsCharacterAdded = true;
                }
                i++;
            }
            if (Team2.Items.Count < amount || Team1.Items.Count < amount)
            {
                MessageBox.Show($"Cannot create lobby for {(Team1.Items.GetItemAt(0) as Unit).ToString()}");
                Team1.Items.Clear();
                Team2.Items.Clear();
            }
        }
    }
}
