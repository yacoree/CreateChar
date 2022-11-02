using System;
using System.Windows;
using System.Windows.Input;
using CreateChar.Items;
using CreateChar.PartsOfUnits;

namespace CreateCharWpf
{
    /// <summary>
    /// Логика взаимодействия для CreateItemWindow.xaml
    /// </summary>
    public partial class CreateItemWindow : Window
    {
        public Item Item { get; set; }

        public CreateItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            if (ItemName.Text != "")
            {
                switch (Convert.ToInt32(Type.Text))
                {
                    case 1: Item = new Helmet(ItemName.Text); break;
                    case 2: Item = new Armor(ItemName.Text); break;
                    case 3: Item = new Weapon(ItemName.Text); break;
                    default: Item = new Item(ItemName.Text); break;
                }
                Item.ItemWeight = Convert.ToInt32(Weight.Text);
                Item.ItemPropery = new UnitProperty(
                    Convert.ToInt32(PhysicalProtection.Text),
                    Convert.ToInt32(HealthPoint.Text),
                    Convert.ToInt32(ManaPool.Text),
                    Convert.ToInt32(PhysicalAttack.Text),
                    Convert.ToInt32(MagicalAttack.Text));
                Item.RequiredConstitution = Convert.ToInt32(RequiredConstitution.Text);
                Item.RequiredStrength = Convert.ToInt32(RequiredStrength.Text);
                Item.RequiredIntelligence = Convert.ToInt32(RequiredIntelligence.Text);
                Item.RequiredDexterity = Convert.ToInt32(RequiredDexterity.Text);
                this.DialogResult = true;
            }
        }

        private void ItemCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
