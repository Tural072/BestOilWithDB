using BestOilWithDB.Data;
using BestOilWithDB.Model;
using BestOilWithDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOilWithDB.Presenter
{
    public class MainPresenter
    {
        private readonly PetrolContext _db;
        private IMainView _view;
        public double TotalPrice { get; set; }
        public MainPresenter(IMainView view)
        {
            _view = view;
            _db = new PetrolContext();
            //_db.Petrols.Add(new Petrol { Name = "AI95", Price = 1.4 });
            //_db.Petrols.Add(new Petrol { Name = "AI92", Price = 1 });
            //_db.Petrols.Add(new Petrol { Name = "DIZEL", Price = 0.8 });
            //_db.Cafes.Add(new Cafe { Name = "HotDog", Price = 2.10 });
            //_db.Cafes.Add(new Cafe { Name = "Cola", Price = 1 });
            //_db.Cafes.Add(new Cafe { Name = "KartofFree", Price = 3.20 });
            //_db.Cafes.Add(new Cafe { Name = "Hamburger", Price = 2.30 });
            _view.ComboboxIndexChange += ComboboxIndexCanged;
            _view.CheckedChangedLiter += LiterChechkedChanged;
            _view.CheckedChangedAzn += AznChechkedChanged;
            _view.CalculateButtonClicked += CalculateButtonClicked;
            _view.LoadButtonClicked += LoadButtonClicked;
            _view.HamburgerChechkBoxClicked += HamburgerChechkBoxClicked;
            _view.HotDogChechkBoxClicked += HotDogChechkBoxClicked;
            _view.ColaChechkBoxClicked += ColaChechkBoxClicked;
            _view.FreeChechkBoxClicked += FreeChechkBoxClicked;
            var data = _db.Cafe.ToArray();
            var hotdogPrice = data[0].Price;
            var hamburgerPrice = data[3].Price;
            var freePrice = data[2].Price;
            var colaPrice = data[1].Price;
            _db.SaveChanges();
            _view.HotDogPriceText = hotdogPrice.ToString();
            _view.HamburgerPriceText = hamburgerPrice.ToString();
            _view.ColaPriceText = colaPrice.ToString();
            _view.FreePriceText = freePrice.ToString();
            var list = _db.Petrols.ToList();

            _view.Petrols = list;
        }
        public string NameOfOil { get; set; }
        public double Result { get; set; }
        public void ComboboxIndexCanged(object sender, EventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            var petrol = item as Petrol;
            NameOfOil = petrol.Name;
            _view.PriceText = petrol.Price.ToString();
        }

        public void LiterChechkedChanged(object sender, EventArgs e)
        {
            var item = sender as RadioButton;
            if (item.Checked)
            {
                _view.LitrEnabled = true;
            }
            else
            {
                _view.LitrEnabled = false;
            }
        }
        public void AznChechkedChanged(object sender, EventArgs e)
        {
            var item = sender as RadioButton;
            if (item.Checked)
            {
                _view.PriceEnabled = true;
            }
            else
            {
                _view.PriceEnabled = false;
            }
        }
        public void CalculateButtonClicked(object sender, EventArgs e)
        {
            if (_view.LitrEnabled == true)
            {
                var money = double.Parse(_view.LitrText) * double.Parse(_view.PriceText);
                _view.TotalText = money.ToString();
            }
            else if (_view.PriceEnabled == true)
            {
                var money = double.Parse(_view.MoneyText) / double.Parse(_view.PriceText);
                _view.LitrText = String.Empty;
                var moneyFull = (int)money;
                _view.LitrText = moneyFull.ToString();
                _view.TotalText = _view.MoneyText;
            }
            if (_view.HotDogEnabled == true)
            {
                _view.CafeTotalText = string.Empty;
                Double result = double.Parse(_view.HotDogPriceText) * double.Parse(_view.HotDogCountText);
                Result += result;
                _view.CafeTotalText += Result.ToString();
            }
            if (_view.HamburgerEnabled == true)
            {
                _view.CafeTotalText = string.Empty;
                Double result = double.Parse(_view.HamburgerPriceText) * double.Parse(_view.HamburgerCountText);
                Result += result;
                _view.CafeTotalText += Result.ToString();
            }
            if (_view.ColaEnabled == true)
            {
                _view.CafeTotalText = string.Empty;

                Double result = double.Parse(_view.ColaPriceText) * double.Parse(_view.ColaCountText);
                Result += result;

                _view.CafeTotalText += Result.ToString();
            }
            if (_view.FriEnabled == true)
            {
                _view.CafeTotalText = string.Empty;
                Double result = double.Parse(_view.FreePriceText) * double.Parse(_view.FreeCountText);
                Result += result;
                _view.CafeTotalText += Result.ToString();
            }
            if (_view.LitrEnabled == true || _view.PriceEnabled == true)
            {
                Payment payment = new Payment
                {
                    Liter = int.Parse(_view.LitrText),
                    Oil = NameOfOil,
                    TotalPayment = double.Parse(_view.TotalText)
                };
                _db.Payments.Add(payment);
                _db.SaveChanges();
            }

            _view.HotDogEnabled = false;
            _view.ColaEnabled = false;
            _view.HamburgerEnabled = false;
            _view.FriEnabled = false;
            _view.LitrEnabled = false;
            _view.PriceEnabled = false;
            TotalPrice = double.Parse(_view.CafeTotalText) + double.Parse(_view.TotalText);
            _view.Total = TotalPrice.ToString();
        }

        public void LoadButtonClicked(object sender, EventArgs e)
        {
            var list = _db.Payments;
            _view.Payments = list.ToList();
        }

        public void HotDogChechkBoxClicked(object sender, EventArgs e)
        {
            var item = sender as CheckBox;
            if (item.Checked)
            {
                _view.HotDogEnabled = true;
            }
            else
            {
                _view.HotDogEnabled = false;
            }
            _view.CafeTotalText = string.Empty;
        }

        public void HamburgerChechkBoxClicked(object sender, EventArgs e)
        {
            var item = sender as CheckBox;
            if (item.Checked)
            {
                _view.HamburgerEnabled = true;
            }
            else
            {
                _view.HamburgerEnabled = false;
            }
            _view.CafeTotalText = string.Empty;
        }
        public void ColaChechkBoxClicked(object sender, EventArgs e)
        {
            var item = sender as CheckBox;
            if (item.Checked)
            {
                _view.ColaEnabled = true;
            }
            else
            {
                _view.ColaEnabled = false;
            }
            _view.CafeTotalText = string.Empty;
        }
        public void FreeChechkBoxClicked(object sender, EventArgs e)
        {
            var item = sender as CheckBox;
            if (item.Checked)
            {
                _view.FriEnabled = true;
            }
            else
            {
                _view.FriEnabled = false;
            }
            _view.CafeTotalText = string.Empty;
        }
    }
}
