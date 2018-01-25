using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class ListagemViewPage : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }

        public ListagemViewPage()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) =>
            {
                Navigation.PushAsync(new DetalheViewPage(msg));
            });

            await this.ViewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
