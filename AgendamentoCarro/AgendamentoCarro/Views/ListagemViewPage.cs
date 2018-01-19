using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class ListagemViewPage : ContentPage
    {

        public ListagemViewPage()
        {
            InitializeComponent();
         }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            //DisplayAlert("Alura", $"O item {veiculo.Nome} foi tocado!{Environment.NewLine}{veiculo.PrecoFormatado}", "Blz");
            Navigation.PushAsync(new DetalheViewPage(veiculo));
        }
    }
}
