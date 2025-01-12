using ProiectMAUI.Models;

namespace ProiectMAUI;

public partial class TattooPage : ContentPage
{
    TattooList tl;
    public TattooPage(TattooList tlist)
	{
		InitializeComponent();
        tl = tlist;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tattoo = (Tattoo)BindingContext;
        await App.Database.SaveTattooAsync(tattoo);
        listView.ItemsSource = await App.Database.GetTattoosAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tattoo = listView.SelectedItem as Tattoo;
        await App.Database.DeleteTattooAsync(tattoo);
        listView.ItemsSource = await App.Database.GetTattoosAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTattoosAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Tattoo t;
        if (listView.SelectedItem != null)
        {
            t = listView.SelectedItem as Tattoo;
            var lt = new ListTattoo()
            {
                TattooListID = tl.ID,
                TattooID = t.ID
            };
            await App.Database.SaveListTattooAsync(lt);
            t.ListTattoos = new List<ListTattoo> { lt };
            await Navigation.PopAsync();
        }
    }
}