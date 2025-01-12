using ProiectMAUI.Models;

namespace ProiectMAUI;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tlist = (TattooList)BindingContext;
        tlist.Date = DateTime.UtcNow;
        Parlor selectedParlor = (ParlorPicker.SelectedItem as Parlor);
        tlist.ParlorID = selectedParlor.ID;
        await App.Database.SaveTattooListAsync(tlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tlist = (TattooList)BindingContext;
        await App.Database.DeleteTattooListAsync(tlist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TattooPage((TattooList)
       this.BindingContext)
        {
            BindingContext = new Tattoo()
        });

    }

    async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        var selectedTattoo = listView.SelectedItem as Tattoo;

        if (selectedTattoo != null)
        {
            bool confirm = await DisplayAlert("Confirm", "Are you sure you want to delete this item?", "Yes", "No");

            if (confirm)
            {
                var tattooList = (TattooList)BindingContext;
                var listTattoo = await App.Database.GetListTattooByIdsAsync(tattooList.ID, selectedTattoo.ID);

                if (listTattoo != null)
                {
                    await App.Database.DeleteListTattooAsync(listTattoo);
                    listView.ItemsSource = await App.Database.GetListTattoosAsync(tattooList.ID);
                }
            }
        }
        else
        {
            await DisplayAlert("Error", "No product selected. Please select a tattoo to delete.", "OK");
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetParlorsAsync();
        ParlorPicker.ItemsSource = (System.Collections.IList)items;
        ParlorPicker.ItemDisplayBinding = new Binding("ParlorDetails");
        var shopl = (TattooList)BindingContext;

        listView.ItemsSource = await App.Database.GetListTattoosAsync(shopl.ID);
    }
}