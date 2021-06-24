using BestOilWithDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOilWithDB.View
{
    public partial class MainView : Form, IMainView
    {
        public EventHandler<EventArgs> ComboboxIndexChange { get; set; }
        public EventHandler<EventArgs> CheckedChangedLiter { get; set; }
        public EventHandler<EventArgs> CheckedChangedAzn { get; set; }
        public EventHandler<EventArgs> CalculateButtonClicked { get; set; }
        public EventHandler<EventArgs> LoadButtonClicked { get; set; }
        public EventHandler<EventArgs> HotDogChechkBoxClicked { get; set; }
        public EventHandler<EventArgs> FreeChechkBoxClicked { get; set; }
        public EventHandler<EventArgs> HamburgerChechkBoxClicked { get; set; }
        public EventHandler<EventArgs> ColaChechkBoxClicked { get; set; }
        public List<Petrol> Petrols
        {
            set
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = value;
            }
        }
        public List<Payment> Payments
        {
            set
            {
                listBox1.DataSource = null;
                listBox1.DataSource = value;
            }
        }
        public string PriceText { get => priceLbl.Text; set => priceLbl.Text = value; }
        public bool IsLitr { get => litrRadiobtn.Checked; set => litrRadiobtn.Checked = value; }
        public string LitrText { get => maskedTextBox1.Text; set => maskedTextBox1.Text = value; }
        public string MoneyText { get => maskedTextBox2.Text; set => maskedTextBox2.Text = value; }
        public string TotalText { get => totalLbl.Text; set => totalLbl.Text = value; }
        public bool LitrEnabled { get => maskedTextBox1.Enabled; set => maskedTextBox1.Enabled = value; }
        public bool PriceEnabled { get => maskedTextBox2.Enabled; set => maskedTextBox2.Enabled = value; }
        public string HotDogPriceText { get => hotdogPriceTxtb.Text; set => hotdogPriceTxtb.Text = value; }
        public string HamburgerPriceText { get => hamburgerPriceTxtb.Text; set => hamburgerPriceTxtb.Text = value; }
        public string FreePriceText { get => freePriceTxtb.Text; set => freePriceTxtb.Text = value; }
        public string ColaPriceText { get => colaPriceTxtb.Text; set => colaPriceTxtb.Text = value; }
        public string HotDogCountText { get => hotdogCountTxtb.Text; set => hotdogCountTxtb.Text = value; }
        public string HamburgerCountText { get => hamburgerCountTxtb.Text; set => hamburgerCountTxtb.Text = value; }
        public string FreeCountText { get => freeCountTxtb.Text; set => freeCountTxtb.Text = value; }
        public string ColaCountText { get => colaCountTxtb.Text; set => colaCountTxtb.Text = value; }
        public string CafeTotalText { get => cafeTotalLbl.Text; set => cafeTotalLbl.Text = value; }
        public string Total { get => totalPriceLbl.Text; set => totalPriceLbl.Text = value; }
        public bool HotDogEnabled { get => hotdogCountTxtb.Enabled; set => hotdogCountTxtb.Enabled=value; }
        public bool FriEnabled { get => freeCountTxtb.Enabled; set => freeCountTxtb.Enabled = value; }
        public bool ColaEnabled { get => colaCountTxtb.Enabled; set => colaCountTxtb.Enabled = value; }
        public bool HamburgerEnabled { get => hamburgerCountTxtb.Enabled; set => hamburgerCountTxtb.Enabled = value; }

        public MainView()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxIndexChange.Invoke(sender, e);
        }
        private void litrRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChangedLiter.Invoke(sender, e);
        }
        private void aznRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChangedAzn.Invoke(sender, e);
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            CalculateButtonClicked.Invoke(sender, e);
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadButtonClicked.Invoke(sender, e);
        }

        private void hotdogCheckb_CheckedChanged(object sender, EventArgs e)
        {
            HotDogChechkBoxClicked.Invoke(sender,e);
        }

        private void freeChechkb_CheckedChanged(object sender, EventArgs e)
        {
            FreeChechkBoxClicked.Invoke(sender,e);
        }

        private void hamburgerCheckb_CheckedChanged(object sender, EventArgs e)
        {
            HamburgerChechkBoxClicked.Invoke(sender,e);
        }

        private void colaChechkb_CheckedChanged(object sender, EventArgs e)
        {
            ColaChechkBoxClicked.Invoke(sender,e);
        }
    }
}
