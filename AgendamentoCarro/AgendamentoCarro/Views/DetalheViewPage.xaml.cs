using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class DetalheViewPage : ContentPage
    {
        public Veiculo veiculo { get; set; }
        const decimal PrecoFreioAbs = 800;
        const decimal PrecoArCondicionado = 1000;
        const decimal PrecoMP3Player = 500;

        public string TextoFreioAbs => $"Freio ABS - {PrecoFreioAbs.ToMoeda()}";
        public string TextoArCondicionado => $"Ar Condicionado - {PrecoArCondicionado.ToMoeda()}";
        public string TextoMP3Player => $"MP3 Player - {PrecoMP3Player.ToMoeda()}";

        private bool temFreioAbs;
        public bool TemFreioAbs
        {
            get { return temFreioAbs; }
            set
            {
                temFreioAbs = value;
                OnPropertyChanged();

                AtualizarValor(PrecoFreioAbs, value);
            }
        }

        private bool temArCondicionado;
        public bool TemArCondicionado
        {
            get { return temArCondicionado; }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();

                AtualizarValor(PrecoArCondicionado, value);
            }
        }

        private bool temMP3Player;
        public bool TemMP3Player
        {
            get { return temMP3Player; }
            set
            {
                temMP3Player = value;
                OnPropertyChanged();

                AtualizarValor(PrecoMP3Player, value);
            }
        }

        public decimal ValorTotal { get; set; }
        public string TextoValorTotal => $"Valor total: {ValorTotal.ToMoeda()}";

        private void AtualizarValor(decimal valor, bool somar)
        {
            if (somar)
                ValorTotal += valor;
            else
                ValorTotal -= valor;
            
            OnPropertyChanged(nameof(TextoValorTotal));
        }

        public DetalheViewPage(Veiculo veiculo)
        {
            this.veiculo = veiculo;
            this.BindingContext = this;
            ValorTotal = veiculo.Preco;

            InitializeComponent();
        }

        void Proximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoViewPage(veiculo));
        }
    }
}
