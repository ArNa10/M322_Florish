using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorishApp;

[QueryProperty(nameof(Index), "index")]
public partial class PlantInfoPage : ContentPage
{ 

    private Plant _plant;

    public int Index
    {
        set
        {
            _plant = PlantRepository.Plants[value];
            LoadData();
        }
    }
    public PlantInfoPage()
    {
        InitializeComponent();
    }
    
    private void LoadData()
    {
        nameLabel.Text = _plant.Name;
        artLabel.Text = _plant.Art;
        standortLabel.Text = _plant.Standort;
        wasserLabel.Text = $"{_plant.WasserIntervall} Tage";
        datumLabel.Text = _plant.LetzteBewässerung.ToShortDateString();
        giftigLabel.Text = _plant.IstGiftig ? "⚠️ Giftig" : "Ungiftig";


    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

}