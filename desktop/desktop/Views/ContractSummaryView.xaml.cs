using desktop.Models;

namespace desktop.Views;

public partial class ContractSummaryView : ContentPage
{
    public ContractSummaryView(ContractSummaryResponse summary)
    {
        InitializeComponent();
        BindingContext = summary;
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}