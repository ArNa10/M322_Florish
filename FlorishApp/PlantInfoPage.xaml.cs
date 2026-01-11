using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorishApp;

[QueryProperty(nameof(Plant), "Plant")]
public partial class PlantInfoPage : ContentPage
{ 
    private Plant _plant;
    
    public Plant Plant
    {
        set
        {
            _plant = value;
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

    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

}