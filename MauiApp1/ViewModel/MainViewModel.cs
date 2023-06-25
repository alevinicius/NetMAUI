using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel;

public partial class MainViewModel: ObservableObject
{
    IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            //Exibe mensagem de que não há conexão com a internet
            await Shell.Current.DisplayAlert("Oh não!", "Sem Internet", "OK");
            return;
        }
        
        //Add our item
        Items.Add(Text);

        Text = string.Empty;

    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Change(string s)
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Delete(s);
        await Add();
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        //Faz abrir a página "DetailPage"
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }

}
