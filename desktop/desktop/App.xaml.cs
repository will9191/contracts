namespace desktop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppShell.InitializeRouting();
            InitializeTheme();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        private void InitializeTheme()
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}