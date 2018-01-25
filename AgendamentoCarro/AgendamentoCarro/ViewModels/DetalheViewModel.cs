using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class DetalheViewModel : BaseViewModel
    {
        public ICommand ProximoCommand { get; set; }


        public Veiculo Veiculo { get; set; }

        public string TextoValorTotal => Veiculo.TextoValorTotal;

        void Atualizar(decimal valor, bool somar)
        {
            Veiculo.AtualizarValor(valor, somar);
            OnPropertyChanged(nameof(TextoValorTotal));
        }

        public bool TemFreioAbs
        {
            get { return Veiculo.TemFreioAbs; }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                Atualizar(Veiculo.PrecoFreioAbs, value);
            }
        }

        public bool TemArCondicionado
        {
            get { return Veiculo.TemArCondicionado; }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                Atualizar(Veiculo.PrecoArCondicionado, value);
            }
        }

        public bool TemMP3Player
        {
            get { return Veiculo.TemMP3Player; }
            set
            {
                Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                Atualizar(Veiculo.PrecoMP3Player, value);
            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            this.Veiculo.ValorTotal = veiculo.Preco;

            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send<Veiculo>(this.Veiculo, "Proximo");
            });
        }
    }
}
