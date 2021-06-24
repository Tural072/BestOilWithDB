using BestOilWithDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOilWithDB.View
{
    public interface IMainView
    {
        EventHandler<EventArgs> ComboboxIndexChange { get; set; }
        EventHandler<EventArgs> CheckedChangedLiter { get; set; }
        EventHandler<EventArgs> CheckedChangedAzn { get; set; }
        EventHandler<EventArgs> CalculateButtonClicked { get; set; }
        EventHandler<EventArgs> LoadButtonClicked { get; set; }
        EventHandler<EventArgs> HotDogChechkBoxClicked { get; set; }
        EventHandler<EventArgs> FreeChechkBoxClicked { get; set; }
        EventHandler<EventArgs> HamburgerChechkBoxClicked { get; set; }
        EventHandler<EventArgs> ColaChechkBoxClicked { get; set; }

        List<Petrol> Petrols { set; }
        List<Payment> Payments { set; }
        string PriceText { get; set; }
        bool IsLitr { get; set; }
        string LitrText { get; set; }
        string MoneyText { get; set; }
        string TotalText { get; set; }
        bool LitrEnabled { get; set; }
        bool PriceEnabled { get; set; }
        string HotDogPriceText { get; set; }
        string HamburgerPriceText { get; set; }
        string FreePriceText { get; set; }
        string ColaPriceText { get; set; }
        string HotDogCountText { get; set; }
        string HamburgerCountText { get; set; }
        string FreeCountText { get; set; }
        string ColaCountText { get; set; }
        string CafeTotalText { get; set; }
        string Total { get; set; }
        bool HotDogEnabled { get; set; }
        bool FriEnabled { get; set; }
        bool ColaEnabled { get; set; }
        bool HamburgerEnabled { get; set; }
    }
}
