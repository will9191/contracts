using System.Collections.ObjectModel;
using desktop.Models;
using desktop.Services.Auth;
using desktop.Services.Settings;

namespace desktop.Views;

public partial class RegisterView : ContentPage
{
    private readonly IAuthService _authService;
    private readonly ISettingsService _settingsService;
    public List<string> Roles { get; } = new() { "Admin", "Manager" };

    public RegisterView(IAuthService authService, ISettingsService settingsService)
    {
        _authService = authService;
        _settingsService = settingsService;
        InitializeComponent();
        BindingContext = this;
    }

    private async void Register(object sender, EventArgs e)
    {
        var register = new Register();
        register.Name = Name.Text;
        register.Email = Email.Text;
        register.Password = Password.Text;
        register.Role = (string)Role.SelectedItem;

        if (string.IsNullOrWhiteSpace(register.Name) ||
            string.IsNullOrWhiteSpace(register.Email) ||
            string.IsNullOrWhiteSpace(register.Password) ||
            register.Role == null)
        {
            DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        var response = await _authService.RegisterAsync(register);

        if (response == null)
        {
            DisplayAlert("Atenção", "Login ou senha inválidos.", "OK");
            return;
        }
        else
        {
            _settingsService.AccessToken = response.AccessToken;
            _settingsService.RefreshToken = response.RefreshToken;

            DisplayAlert("Sucesso!", "Cadastro efetuado", "OK");

            await Shell.Current.GoToAsync("//contracts");
        }
    }
}

