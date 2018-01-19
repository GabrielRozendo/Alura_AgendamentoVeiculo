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

        void Proximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoViewPage(Veiculo));
        }
    }
}
