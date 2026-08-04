using CommunityToolkit.Mvvm.ComponentModel;

namespace FileDirector.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
