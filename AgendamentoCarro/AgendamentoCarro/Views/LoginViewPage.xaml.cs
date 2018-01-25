using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class LoginViewPage : ContentPage
    {
        public LoginViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin",
            async (exc) =>
            {
               await DisplayAlert("Login", exc.Message, "Tentar novamente");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}
