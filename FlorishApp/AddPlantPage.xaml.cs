using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorishApp;

public partial class AddPlantPage : ContentPage
{
    public AddPlantPage()
    {
        InitializeComponent();
    }
    private async void OnAddPlantClicked(object sender, EventArgs e)
    {
        errorLabel.IsVisible = false;

        if (string.IsNullOrWhiteSpace(nameEntry.Text)
            || artPicker.SelectedItem == null
            || standortPicker.SelectedItem == null)
        {
            errorLabel.Text = "Bitte alle Pflichtfelder ausfüllen.";
            errorLabel.IsVisible = true;
            return;
        }
        var plant = new Plant
        {
            Name = nameEntry.Text,
            Art = artPicker.SelectedItem?.ToString(),
            Standort = standortPicker.SelectedItem?.ToString(),
            WasserIntervall = (int)wasserStepper.Value,
            LetzteBewässerung = datePicker.Date!.Value
        };
        PlantRepository.Plants.Add(plant);

        await Shell.Current.GoToAsync(nameof(PlantInfoPage), new Dictionary<string, object>
        {
            { "Plant", plant }
        });
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}