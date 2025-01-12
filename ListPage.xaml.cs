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
        await App.Database.SaveTattooListAsync(tlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tlist = (TattooList)BindingContext;
        await App.Database.DeleteTattooListAsync(tlist);
        await Navigation.PopAsync();
    }
}