using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginViewPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
               (usuario) =>
            {
                //MainPage = new NavigationPage(new ListagemViewPage());
                MainPage = new MasterDetailView(usuario);  
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
