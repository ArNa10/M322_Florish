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
    private async void OnHelpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FaqPage));
    }
    private async void OnPlantSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Plant plant)
            return;

        int index = PlantRepository.Plants.IndexOf(plant);

        await Shell.Current.GoToAsync($"{nameof(PlantInfoPage)}?index={index}");

        ((CollectionView)sender).SelectedItem = null;
    }

}