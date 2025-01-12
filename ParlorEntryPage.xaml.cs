using ProiectMAUI.Models;

namespace ProiectMAUI;

public partial class ParlorEntryPage : ContentPage
{
	public ParlorEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetParlorsAsync();
    }
    async void OnParlorAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ParlorPage
        {
            BindingContext = new Parlor()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ParlorPage
            {
                BindingContext = e.SelectedItem as Parlor
            });
        }
    }
}