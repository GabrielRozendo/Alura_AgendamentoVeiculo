using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo { get; set; }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get { return Agendamento.Telefone; }
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime DataHora => Data.Add(Hora);

        public ICommand AgendarCommand { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;

            this.Agendamento = new Agendamento();
            Veiculo = this.Agendamento.Veiculo = veiculo;
            Data = this.Agendamento.Data;
            Hora = this.Agendamento.Hora;

            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendar");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Nome)
                          && !string.IsNullOrEmpty(this.Telefone)
                          && !string.IsNullOrEmpty(this.Email);
            });
        }

        public async void SalvarAgendamento()
        {
            HttpClient cliente = new HttpClient();
            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = DataHora
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException($"{resposta.StatusCode.ToString()} {resposta.StatusCode.ToString()}"), "ErroAgendamento");
        }
    }
}
