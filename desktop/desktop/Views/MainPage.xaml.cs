namespace desktop.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

    private async void GoToLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

    private async void GoToRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }
}
