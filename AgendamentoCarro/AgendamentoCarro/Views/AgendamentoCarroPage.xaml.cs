using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class AgendamentoCarroPage : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }


        public AgendamentoCarroPage()
        {

            InitializeComponent();

            Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 50000 },
                new Veiculo { Nome = "HB20 S", Preco = 40000}
            };

            listViewVeiculos.ItemsSource = Veiculos;

            this.BindingContext = this;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            DisplayAlert("Alura", $"O item {veiculo.Nome} foi tocado!{Environment.NewLine}{veiculo.PrecoFormatado}", "Blz");
        }
    }
}
