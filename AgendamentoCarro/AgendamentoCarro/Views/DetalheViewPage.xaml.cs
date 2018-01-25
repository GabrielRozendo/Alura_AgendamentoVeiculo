using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class DetalheViewPage : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public DetalheViewPage(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            BindingContext = new DetalheViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) =>
            {
                Navigation.PushAsync(new AgendamentoViewPage(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}
