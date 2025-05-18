using desktop.Views;

namespace desktop
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public static void InitializeRouting()
        {
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("login", typeof(LoginView));
            Routing.RegisterRoute("register", typeof(RegisterView));
        }
    }
}
