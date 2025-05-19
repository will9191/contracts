using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using desktop.Models;
using desktop.Services.Auth;
using desktop.Services.Settings;

namespace desktop.Views;

public partial class LoginView : ContentPage
{
    private readonly IAuthService _authService;
    private readonly ISettingsService _settingsService; 
    public LoginView(IAuthService authService, ISettingsService settingsService)
	{
        _authService = authService;
        _settingsService = settingsService;
		InitializeComponent();
	}

    private async void Login(object sender, EventArgs e)
    {
        var login = new Login();

        login.Email = Email.Text;
        login.Password = Password.Text;

        if (
          string.IsNullOrWhiteSpace(login.Email) ||
          string.IsNullOrWhiteSpace(login.Password))
        {
            DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
            return;
        }

         var response = await _authService.LoginAsync(login);

        if (response == null)
        {
            DisplayAlert("Atenção", "Login ou senha inválidos.", "OK");
            return;
        } else
        {
            _settingsService.AccessToken = response.AccessToken;
            _settingsService.RefreshToken = response.RefreshToken;

            DisplayAlert("Sucesso!", "Login efetuado", "OK");

            await Shell.Current.GoToAsync("//contracts");
        }
    }
}