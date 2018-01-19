using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgendamentoCarro
{
    public class DetalheViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
        }
    }
}
