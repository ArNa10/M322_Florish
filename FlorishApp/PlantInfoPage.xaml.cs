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
        
        var nextWateringDate = _plant.LetzteBewässerung
            .AddDays(_plant.WasserIntervall);

        nextWateringLabel.Text =
            $"Nächste Bewässerung: {nextWateringDate:dd.MM.yyyy}";
        
        if (nextWateringDate.Date <= DateTime.Today)
        {
            nextWateringLabel.Text += " ⚠️ Heute fällig";
            nextWateringLabel.TextColor = Colors.Red;
        }
        
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
    
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_plant == null)
            return;

        bool confirm = await DisplayAlert(
            "Pflanze löschen",
            "Möchtest du diese Pflanze wirklich löschen?",
            "Löschen",
            "Abbrechen");

        if (!confirm)
            return;

        PlantRepository.Plants.Remove(_plant);

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }


}