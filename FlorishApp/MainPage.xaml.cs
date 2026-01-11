using System.Collections.ObjectModel;
using FlorishApp;
using System.Collections.ObjectModel;


namespace FlorishApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        PlantsCollection.ItemsSource = PlantRepository.Plants;

    }
    private async void OnAddPlantClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddPlantPage));
    }

}