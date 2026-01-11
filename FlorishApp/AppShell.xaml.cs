namespace FlorishApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(AddPlantPage), typeof(AddPlantPage));
        Routing.RegisterRoute(nameof(PlantInfoPage), typeof(PlantInfoPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(FaqPage), typeof(FaqPage));
    }
}