using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace desktop.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
	}

    private void Login(object sender, EventArgs e)
    {
        var email = Email.Text;
        var password = Password.Text;

        if (
          string.IsNullOrWhiteSpace(email) ||
          string.IsNullOrWhiteSpace(password))
        {
            DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        DisplayAlert("Login efetuado!", String.Format(email, password), "Ok!");
    }
}