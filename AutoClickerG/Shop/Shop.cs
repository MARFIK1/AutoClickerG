using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickerG
{
    public partial class Shop : Form
    {
        private static Shop _instance;

        public static Shop Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shop();
                }
                return _instance;
            }
        }
        private List<Label> itemLabels = new List<Label>();
        private Dictionary<string, PictureBox> itemCostLabels = new Dictionary<string, PictureBox>();
        public static string SelectedItem { get; set; } = "Coin";
        public Shop()
        {
            InitializeComponent();

            Item0Info.Text = "Selected";
            Item1Info.Text = "Cost: 10";
            Item2Info.Text = "Cost: 20";
            Item3Info.Text = "Cost: 30";
            Item4Info.Text = "Cost: 40";
            Item5Info.Text = "Cost: 50";
            Item6Info.Text = "Cost: 60";
            Item7Info.Text = "Cost: 70";

            itemLabels.Add(Item0Info);
            itemLabels.Add(Item1Info);
            itemLabels.Add(Item2Info);
            itemLabels.Add(Item3Info);
            itemLabels.Add(Item4Info);
            itemLabels.Add(Item5Info);
            itemLabels.Add(Item6Info);
            itemLabels.Add(Item7Info);

            itemCostLabels.Add("SpinningStrawberry", Item1Cost);
            itemCostLabels.Add("SpinningCube", Item2Cost);
            itemCostLabels.Add("SpinningEarth", Item3Cost);
            itemCostLabels.Add("SpinningVinyl", Item4Cost);
            itemCostLabels.Add("SpinningDonut", Item5Cost);
            itemCostLabels.Add("SpinningBox", Item6Cost);
            itemCostLabels.Add("SpinningObject", Item7Cost);

            ShopItem0.Click += (s, e) => { HandleItemClick("Coin", 0, Item0Info); };
            ShopItem1.Click += (s, e) => { HandleItemClick("SpinningStrawberry", 10, Item1Info); };
            ShopItem2.Click += (s, e) => { HandleItemClick("SpinningCube", 20, Item2Info); };
            ShopItem3.Click += (s, e) => { HandleItemClick("SpinningEarth", 30, Item3Info); };
            ShopItem4.Click += (s, e) => { HandleItemClick("SpinningVinyl", 40, Item4Info); };
            ShopItem5.Click += (s, e) => { HandleItemClick("SpinningDonut", 50, Item5Info); };
            ShopItem6.Click += (s, e) => { HandleItemClick("SpinningBox", 60, Item6Info); };
            ShopItem7.Click += (s, e) => { HandleItemClick("SpinningObject", 70, Item7Info); };

            Item0Info.ForeColor = Color.Green;
            
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            DiamondBalance.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            this.VisibleChanged += Shop_VisibleChanged;
            BackToMenu.Click += BackToMenu_Click;
        }

        private void BuyItem(string itemId, int cost, Label itemLabel)
        {
            if (itemLabel.Text == "Owned")
            {
                SelectItem(itemId, itemLabel);
            }
            else if (GlobalVariables.DiamondBalance >= cost)
            {
                var result = MessageBox.Show($"Do you want to buy {itemId} for {cost} diamonds?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    GlobalVariables.DiamondBalance -= cost;
                    DiamondBalance.Text = ": " + GlobalVariables.DiamondBalance.ToString();

                    itemLabel.Text = "Owned";
                    itemLabel.ForeColor = Color.Orange;

                    GlobalVariables.PurchasedItems.Add(itemId);

                    if (itemCostLabels.ContainsKey(itemId))
                    {
                        itemCostLabels[itemId].Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show($"You do not have enough diamonds to buy {itemId}!", "Refusal to purchase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectItem(string itemId, Label itemLabel)
        {
            if (itemLabel.Text == "Owned")
            {
                foreach (var label in itemLabels)
                {
                    if (label != itemLabel && label.Text == "Selected")
                    {
                        label.Text = "Owned";
                        label.ForeColor = Color.Orange;
                    }
                }

                itemLabel.Text = "Selected";
                itemLabel.ForeColor = Color.Green;
                SelectedItem = itemId;
            }
            else
            {
                MessageBox.Show($"You do not own the {itemId} yet!");
            }
        }

        private void HandleItemClick(string itemId, int cost, Label itemLabel)
        {
            if (itemLabel.Text == "Selected")
            {
                MessageBox.Show($"You have already selected the {itemId}!");
            }
            else if (itemLabel.Text != "Owned")
            {
                BuyItem(itemId, cost, itemLabel);
            }
            else
            {
                SelectItem(itemId, itemLabel);
            }
        }
        
        private void Shop_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                DiamondBalance.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            }
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            GlobalVariables.SelectedItem = SelectedItem;
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
