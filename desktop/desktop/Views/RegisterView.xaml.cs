using System.Collections.ObjectModel;

namespace desktop.Views;

public partial class RegisterView : ContentPage
{
    public List<string> Roles { get; } = new() { "Admin", "Manager" };

    public RegisterView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void Register(object sender, EventArgs e)
    {
        var name = Name.Text;
        var email = Email.Text;
        var password = Password.Text;
        var role = (string)Role.SelectedItem;

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            role == null)
        {
            DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        DisplayAlert("Login efetuado!", String.Format(email, password), "Ok!");
    }


}

