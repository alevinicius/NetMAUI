using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel; 

//O segundo "Text" deve ser idêntico ao parâmetro que vem da URL
[QueryProperty("Text", "Text")]

public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync(".."); //esses pontos é para voltar a página. "../.." faria voltar 2 páginas
    }
}
