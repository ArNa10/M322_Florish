using System.Collections.ObjectModel;
using FlorishApp;

namespace FlorishApp;

public static class PlantRepository
{
    public static ObservableCollection<Plant> Plants { get; } = new();

}